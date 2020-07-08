using Ionic.Zip;
using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using Newtonsoft.Json;
using OpenNextOneDrive;
using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KoenZomers.OneDrive.AuthenticatorApp
{
    public partial class MainForm : Form
    {
        #region Properties

        private IniFile MyIni;

        private Configuracao _configuracao;

        private readonly Configuration _configuration;


        public OneDriveApi OneDriveApi;


        public string RefreshToken;

        #endregion


        public MainForm()
        {
            MyIni = new IniFile("Config.init");
            ConfigurationReceiver();
            InitializeComponent();
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            RefreshToken = _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value;

            RefreshTokenTextBox.Text = RefreshToken;
            OneDriveTypeCombo.SelectedIndex = 0;
        }


        private void InitiateOneDriveApi()
        {
            //Defini qual API vai iniciar
            switch (OneDriveTypeCombo.SelectedIndex)
            {
                case 0:
                    OneDriveApi = new OneDriveConsumerApi(_configuration.AppSettings.Settings["OneDriveConsumerApiClientID"].Value, _configuration.AppSettings.Settings["OneDriveConsumerApiClientSecret"].Value);
                    if (!string.IsNullOrEmpty(_configuration.AppSettings.Settings["OneDriveConsumerApiRedirectUri"].Value))
                    {
                        OneDriveApi.AuthenticationRedirectUrl = _configuration.AppSettings.Settings["OneDriveConsumerApiRedirectUri"].Value;
                    }
                    break;

                case 1:
                    OneDriveApi = new OneDriveForBusinessO365Api(_configuration.AppSettings.Settings["OneDriveForBusinessO365ApiClientID"].Value, _configuration.AppSettings.Settings["OneDriveForBusinessO365ApiClientSecret"].Value);
                    break;

                case 2:
                    OneDriveApi = new OneDriveGraphApi(_configuration.AppSettings.Settings["GraphApiApplicationId"].Value);
                    break;
            }

            OneDriveApi.ProxyConfiguration = UseProxyCheckBox.Checked ? System.Net.WebRequest.DefaultWebProxy : null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            OneDriveTypeCombo.SelectedIndex = OneDriveTypeCombo.Items.Count - 1;
            AccessTokenTextBox.Text = string.Empty;

            InitiateOneDriveApi();

            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
            ConfigurationReceiver();
        }
        private void AtivaWatecher()
        {
           

            ArrayList aFileWatcherInstance = new ArrayList();

            foreach (var cCliente in _configuracao.Cliente)
            {
                //Check if Directory Exisits
                if (Directory.Exists(cCliente.Configuracao.PastaBkp))
                {
                    FileSystemWatcher oFileWatcher = new FileSystemWatcher();

                    //Set the path that you want to monitor.
                    oFileWatcher.Path = cCliente.Configuracao.PastaBkp;

                    //Set the Filter Expression.
                    oFileWatcher.Filter = "*.*";

                  
                        oFileWatcher.Changed +=
                          new System.IO.FileSystemEventHandler(FileWatcher_Changed);
                   

                  
                        oFileWatcher.Created +=
                          new System.IO.FileSystemEventHandler(FileWatcher_Created);

                    oFileWatcher.Renamed  += FileWatcher_Renamed;

                    oFileWatcher.EnableRaisingEvents = true;

                    //Add a new instance of FileWatcher 
                    aFileWatcherInstance.Add(oFileWatcher);
                }
            }
        }
      
    private async void AuthenticationBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            CurrentUrlTextBox.Text = e.Url.ToString();

            AuthorizationCodeTextBox.Text = OneDriveApi.GetAuthorizationTokenFromUrl(e.Url.ToString());

            if (!string.IsNullOrEmpty(AuthorizationCodeTextBox.Text))
            {
                await OneDriveApi.GetAccessToken();
                if (OneDriveApi.AccessToken != null)
                {
                    AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                    RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                    AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";

                    _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value = RefreshTokenTextBox.Text;
                    _configuration.Save(ConfigurationSaveMode.Modified);
                    return;
                }
            }

            if (CurrentUrlTextBox.Text.StartsWith(OneDriveApi.SignoutUri))
            {
                var authenticateUri = OneDriveApi.GetAuthenticationUri();
                AuthenticationBrowser.Navigate(authenticateUri);
            }
        }


        private void Step1Button_Click(object sender, EventArgs e)
        {
            AccessTokenTextBox.Text = string.Empty;

            InitiateOneDriveApi();

            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
        }


        private async void RefreshTokenButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RefreshTokenTextBox.Text))
            {
                MessageBox.Show("You need to enter a refresh token first in the refresh token field in order to be able to retrieve a new access token based on a refresh token.", "OneDrive API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InitiateOneDriveApi();

            await OneDriveApi.AuthenticateUsingRefreshToken(RefreshTokenTextBox.Text);

            if (OneDriveApi.AccessToken != null)
            {
                AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";
            }
        }

        private void AccessTokenTextBox_TextChanged(object sender, EventArgs e)
        {
            var accessTokenAvailable = !string.IsNullOrEmpty(((TextBox)sender).Text);
            OneDriveCommandsPanel.Enabled = accessTokenAvailable;
            AuthenticationBrowser.Visible = !accessTokenAvailable;
            JsonResultTextBox.Visible = accessTokenAvailable;
            JsonResultTextBox.Text = "Connected";
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            var fileToUpload = SelectLocalFile();

            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            OneDriveApi.UploadProgressChanged += progressHandler;

            var data = await OneDriveApi.UploadFile(fileToUpload, await OneDriveApi.GetDriveRoot());

            OneDriveApi.UploadProgressChanged -= progressHandler;

            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private string SelectLocalFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Upload to OneDrive";
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.CheckFileExists = true;
            var response = dialog.ShowDialog();

            return response != DialogResult.OK ? null : dialog.FileName;
        }

        private async void CreateFolderButton_Click(object sender, EventArgs e)
        {
            var data = await OneDriveApi.GetFolderOrCreate("Test\\sub1\\sub2");
            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string command = @"C:\\PostgreSQL\\pg10\bin\\pg_dump.exe -h 127.0.0.1 -p 5432 -U postgres -F c -b -v -f C:\\temp\\BkpSql.sql SwitchDB";
            string saida = ExecutarCMD(command);
            string command2 = @"C:\\PostgreSQL\\pg10\bin\\pg_dump.exe -h 127.0.0.1 -p 5432 -U postgres -F c -b -v -f C:\\temp2\\BkpSql.sql SwitchDB";
            saida += ExecutarCMD(command2);
            File.WriteAllText("NomeArquivo.txt", saida);
        }

        public static string ExecutarCMD(string comando)
        {
            System.Diagnostics.Process.Start("CMD.exe", @"/C " + comando).WaitForExit();

            return "Foi";

        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string[] teste = e.FullPath.Split('\\');
            string nomeCOncatenado = string.Empty;
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = "BKP-" + DiaDaSemana() + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    if (File.Exists(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado))
                    {
                        File.Delete(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado);
                    }
                    try
                    {
                        zip.Save(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado);
                    }
                    catch
                    {


                    }


                }
            }
        }
        private ConfiguracaoCliente BuscaCliente(string PastaBkp)
        {
           return  _configuracao.Cliente.First(c => c.Configuracao.PastaBkp == PastaBkp);
        }
        private void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            string[] teste = e.FullPath.Split('\\');
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = "BKP-" + DiaDaSemana() + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    if(File.Exists(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado))
                    {
                        File.Delete(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado);
                    }
                    try
                    {
                        zip.Save(BuscaCliente(teste[0]).Configuracao.PastaBkp + nomeCOncatenado);
                    }
                    catch
                    {


                    }

                }
            }

        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            JsonResultTextBox.Text += Environment.NewLine + value;
        }
        private async void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.Name.Substring(e.Name.Length - 4, 4).ToString() == ".zip")
            {
                string[] teste = e.FullPath.Split('\\');
                var cliente = BuscaCliente(teste[0]);
                var data = await OneDriveApi.UploadFileAs(e.FullPath, e.Name, await OneDriveApi.GetDriveClient(cliente.Cnpj));

                EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

                OneDriveApi.UploadProgressChanged -= progressHandler;
                AppendTextBox("Upload Realizado com Sucesso Cliente: " + cliente.Cnpj + "Na Data:" + DateTime.Now.ToString());
            }
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void AccessTokenValidTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AccessTokenValidTextBox.Text != "")
            {
                var MyIni = new IniFile("Settings.ini");
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                JsonResultTextBox.Text = "Conectado com Sucesso...";
                Notificacao.BalloonTipTitle = "OneDrive OpenNext";
                Notificacao.BalloonTipText = "Conectado com Sucesso...";
                Notificacao.ShowBalloonTip(20000);
                //await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO"));
                VerificarOuCriarPasta();
                AtivaWatecher();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Notificacao.Visible = true;
        }

        private void Notificacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            Notificacao.Visible = false;
        }

        private void ConfigurationReceiver()
        {

            _configuracao = JsonConvert.DeserializeObject<Configuracao>(File.ReadAllText(@"config.json"));

        }
        private async void VerificarOuCriarPasta()
        {
            foreach (var item in _configuracao.Cliente.Where(x => x.Configuracao != null))
            {
                await OneDriveApi.GetFolderOrCreate(item.Cnpj);
            }
        }
        public string DiaDaSemana()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string data = dtfi.GetDayName(DateTime.Now.DayOfWeek);
            return data.ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var config = JsonConvert.DeserializeObject<Configuracao>(File.ReadAllText(@"config.json"));
            FrmConfgiuracao frm = new FrmConfgiuracao(config);
            frm.Show();
        }
    }
}