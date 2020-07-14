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
using System.Threading;
using System.Windows.Forms;

namespace KoenZomers.OneDrive.AuthenticatorApp
{
    public partial class MainForm : Form
    {
        #region Properties


        private Configuracao _configuracao;

        private readonly Configuration _configuration;
        ConfiguracaoCliente cliente = new ConfiguracaoCliente();

        public OneDriveApi OneDriveApi;


        public string RefreshToken;

        #endregion


        public MainForm()
        {
         
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
            //if ((Control.ModifierKeys & Keys.Shift) != 0)
            //{
            //    MessageBox.Show("jkhjkhjkhjkhjk");
            //}
                OneDriveTypeCombo.SelectedIndex = OneDriveTypeCombo.Items.Count - 1;
            IniciaOneDrive();
        }
        private void IniciaOneDrive()
        {
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
                 if (cCliente.Configuracao.TipoConfig == 1)
                {
                    AgendarTarefaAccess(
                        "TarefaAccess" + cCliente.Cnpj,
                        cCliente.Configuracao.PastaBkp,
                        cCliente.Configuracao.CaminhoDump
                        );
                }
                else
                {
                    AgendarTarefaPostgeSQL(
                         "TarefaPostgreSQL" + cCliente.Cnpj,
                        cCliente.Configuracao.PastaBkp + "/Bkp.sql",
                        cCliente.Configuracao.CaminhoDump
                        );
                }
               
                if (Directory.Exists(cCliente.Configuracao.PastaBkp))
                {
                 
                    FileSystemWatcher oFileWatcher = new FileSystemWatcher();
                    DirectoryInfo dir = new DirectoryInfo(cCliente.Configuracao.PastaBkp);
                    oFileWatcher.Path = dir.FullName; 

                  
                    oFileWatcher.Filter = "*.*";


                    oFileWatcher.Created +=
                      new System.IO.FileSystemEventHandler(FileWatcher_Created);

                  

                    oFileWatcher.EnableRaisingEvents = true;

                  
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
            IniciaOneDrive();
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
            AgendarTarefaPostgeSQL("TarefaTestePostgres", "C:/temp/BkpSql.sql", "C:/PostgreSQL/pg10/bin/pg_dump.exe");
            AgendarTarefaAccess("TesteTarefaAcess", @"C:\temp", @"C:\temp2\BkpSql.mdb");
        }
        private void AgendarTarefaPostgeSQL(string NomeTarefa, string PastaBkp, string CaminhoDump)
        {
            char quote = '"';
            string doubleQuotedPath = quote + PastaBkp + quote;
            string comandoFormatado =
            String.Format(@"schtasks /create /sc hourly /mo 1 /sd 03/01/2002 /tn  {0} /tr "+quote+" {2} -h 127.0.0.1 -p 5432 -U postgres -F c -b -v -f {1} SwitchDB "+ quote+" ",
            NomeTarefa,
            PastaBkp,
            CaminhoDump
            );
            ExecutarCMD(comandoFormatado);
        }

        private void AgendarTarefaAccess(string NomeTarefa, string PastaBkp, string CaminhoArquivo)
        {
            char quote = '"';
            string comandoFormatado =
            String.Format(@"schtasks /create /sc hourly /mo 1 /sd 03/01/2002 /tn  {0} /tr " + quote + "cmd /c  copy {2} {1}" + quote + " ",
            NomeTarefa,
            PastaBkp,
            CaminhoArquivo
            );
            ExecutarCMD(comandoFormatado);
        }


        public static string ExecutarCMD(string comando)
        {
            System.Diagnostics.Process.Start("CMD.exe", @"/C " + comando).WaitForExit();

            return "Foi";

        }

      
        private ConfiguracaoCliente BuscaCliente(string PastaBkp)
        {
            
            return _configuracao.Cliente.First(c => c.Configuracao.PastaBkp == PastaBkp);
        }
        private void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            string[] teste = e.FullPath.Split('\\');

            if (e.Name.Contains(".sql") || e.Name.Contains(".mdb"))
            {
                Thread.Sleep(3000);
                nomeCOncatenado = "BKP-" + DiaDaSemana() + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    
                    if (e.Name.Contains(".sql"))
                    {
                      cliente = BuscaCliente(teste[0] + "\\" + teste[1]);

                    }
                    if (e.Name.Contains(".mdb"))
                    {
                        cliente = BuscaCliente(teste[0] + "\\" + teste[1]);

                    }
                    zip.SaveProgress += Zip_SaveProgress;
                    zip.CompressionMethod = Ionic.Zip.CompressionMethod.Deflate;
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                    zip.AddFile(e.FullPath, "");
                    if (!File.Exists(cliente.Configuracao.PastaBkp +"\\"+ nomeCOncatenado))
                        zip.Save(cliente.Configuracao.PastaBkp + "\\" + nomeCOncatenado);


                }
            }

        }
        private void Zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
                AppendTextBox("Proccesso de Compressao Iniciado.");
            if (e.EventType == ZipProgressEventType.Saving_AfterSaveTempArchive)
            {
                AppendTextBox("Proccesso de Compressao Realizado com Sucesso. " + e.ArchiveName);
                UploadDoArquivo(e.ArchiveName);
            }



            if (e.BytesTransferred > 0 && e.TotalBytesToTransfer > 0)
            {
                int progress = (int)Math.Floor((decimal)((e.BytesTransferred * 100) / e.TotalBytesToTransfer));
                AppendTextBoxProgress("Compressao em :" + Convert.ToString(progress) + "%");
                Application.DoEvents();
            }

           
        }

        public void AppendTextBoxProgress(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBoxProgress), new object[] { value });
                return;
            }
            JsonResultTextBox.Text = value;
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

        private async void UploadDoArquivo(string arquivo)
        {

            EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { AppendTextBox( $"Uploading - {a.BytesSent} bytes enviados / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"); };

            string[] teste = arquivo.Split('/');
          

            var sharedWithMe = await OneDriveApi.GetSharedWithMe();


            if (sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }

            AppendTextBox($"Iniciando  upload{Environment.NewLine}");



            OneDriveApi.UploadProgressChanged += progressHandler;


            var sharedWithMeItem = sharedWithMe.Collection.First(item => item.RemoteItem.Folder != null);
            var datas = await OneDriveApi.GetChildrenFromDriveByFolderId(sharedWithMeItem.RemoteItem.ParentReference.DriveId, sharedWithMeItem.Id);
            var fg = datas.Collection.First(c => c.Name == cliente.Cnpj);
            var data = await OneDriveApi.UploadFile(arquivo, fg);
            OneDriveApi.UploadProgressChanged -= progressHandler;

            AppendTextBox(data != null ? data.OriginalJson : "Not available");

            DirectoryInfo diretorio = new DirectoryInfo(cliente.Configuracao.PastaBkp);
            foreach (FileInfo item in diretorio.GetFiles())
            {
                File.Delete(item.FullName);
            }

        }

        private void AccessTokenValidTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AccessTokenValidTextBox.Text != "")
            {
             
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                JsonResultTextBox.Text = "Conectado com Sucesso...";
                Notificacao.BalloonTipTitle = "OneDrive OpenNext";
                Notificacao.BalloonTipText = "Conectado com Sucesso...";
                Notificacao.ShowBalloonTip(20000);
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
               
                var sharedWithMe = await OneDriveApi.GetSharedWithMe();


                if (sharedWithMe.Collection.Length == 0)
                {
                    JsonResultTextBox.Text = "No items are shared with this user";
                    return;
                }



                var sharedWithMeItem = sharedWithMe.Collection.First(v => v.RemoteItem.Folder != null);
                var tt = await OneDriveApi.CreateFolderBanco(sharedWithMeItem.RemoteItem.ParentReference.DriveId, item.Cnpj);
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

        private async void button3_Click(object sender, EventArgs e)
        {
            var retorno = await OneDriveApi.GetSharedWithMe();
            JsonResultTextBox.Text = retorno == null ? "Nao gerou um retorno" : retorno.OriginalJson;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var sharedWithMe = await OneDriveApi.GetSharedWithMe();


            if (sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }



            var sharedWithMeItem = sharedWithMe.Collection.First(item => item.RemoteItem.Folder != null);
            var data = await OneDriveApi.GetChildrenFromDriveByFolderId(sharedWithMeItem.RemoteItem.ParentReference.DriveId, sharedWithMeItem.Id);

            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var retorno = await OneDriveApi.GetDriveRoot();
            JsonResultTextBox.Text = retorno != null ? retorno.OriginalJson : "Not available";
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var sharedWithMe = await OneDriveApi.GetSharedWithMe();


            if (sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }



            var sharedWithMeItem = sharedWithMe.Collection.First(item => item.RemoteItem.Folder != null);
            var tt = await OneDriveApi.CreateFolderBanco(sharedWithMeItem.RemoteItem.ParentReference.DriveId, "PastaBkp");
            JsonResultTextBox.Text = tt == null ? "Nao gerou um retorno" : tt.OriginalJson;
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var fileToUpload = SelectLocalFile();

            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            OneDriveApi.UploadProgressChanged += progressHandler;
            var sharedWithMe = await OneDriveApi.GetSharedWithMe();


            if (sharedWithMe.Collection.Length == 0)
            {
                JsonResultTextBox.Text = "No items are shared with this user";
                return;
            }



            var sharedWithMeItem = sharedWithMe.Collection.First(item => item.RemoteItem.Folder != null);
            var datas = await OneDriveApi.GetChildrenFromDriveByFolderId(sharedWithMeItem.RemoteItem.ParentReference.DriveId, sharedWithMeItem.Id);
            var fg = datas.Collection.First(c => c.Name == "PastaBkp");
            var data = await OneDriveApi.UploadFileViaSimpleUploadBkp2(fileToUpload, sharedWithMeItem, fg.Id);

            OneDriveApi.UploadProgressChanged -= progressHandler;

            JsonResultTextBox.Text = data != null ? data.OriginalJson : "Not available";
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {

                panelLogo.Visible = !panelLogo.Visible;
            }
        }

      

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}