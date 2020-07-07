﻿using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using KoenZomers.OneDrive.Api.Enums;
using System.Linq;
using Ionic.Zip;

namespace KoenZomers.OneDrive.AuthenticatorApp
{
    public partial class MainForm : Form
    {
        #region Properties

        private IniFile MyIni;

        private readonly Configuration _configuration;

      
        public OneDriveApi OneDriveApi;

      
        public string RefreshToken;

        #endregion

      
        public MainForm()
        {
           
            InitializeComponent();
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            RefreshToken = _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value;

            RefreshTokenTextBox.Text = RefreshToken;
            OneDriveTypeCombo.SelectedIndex = 0;
        }

     
        private void InitiateOneDriveApi()
        {
            // Define the type of OneDrive API to instantiate based on the dropdown list selection    
            switch (OneDriveTypeCombo.SelectedIndex)
            {
                case 0:
                    OneDriveApi = new OneDriveConsumerApi(_configuration.AppSettings.Settings["OneDriveConsumerApiClientID"].Value, _configuration.AppSettings.Settings["OneDriveConsumerApiClientSecret"].Value);
                    if(!string.IsNullOrEmpty(_configuration.AppSettings.Settings["OneDriveConsumerApiRedirectUri"].Value))
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
          
            MyIni = new IniFile("Settings.ini");
            MyIni.Write("CNPJ", "88888888888888", "USUARIO");
            MyIni.Write("NOME", "Teste", "USUARIO");

            MyIni.Write("PASTABKP", "C:/temp", "CONFIG");
            MyIni.Write("NOMEARQUIVOBKP", "BKP", "CONFIG");

            MyIni.Write("CLIID", "51afccd5-ac7c-4513-951f-94fa5c0d6ece", "CONFIG");
            MyIni.Write("SECRET", "84HQx9rc6~_kfB~UI4vM2TwCmArQ.xS7cF", "CONFIG");
            MyIni.Write("URLREDIRECT", "https://apps.zomers.eu", "CONFIG");
            FileWatcher.Path = MyIni.Read("PASTABKP", "CONFIG");

            // Make the Graph API the default choice
            OneDriveTypeCombo.SelectedIndex = OneDriveTypeCombo.Items.Count - 1;
            // Reset any possible access tokens we may already have
            AccessTokenTextBox.Text = string.Empty;

            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // First sign the current user out to make sure he/she needs to authenticate again
            var signoutUri = OneDriveApi.GetSignOutUri();
            AuthenticationBrowser.Navigate(signoutUri);
        }

        private async void AuthenticationBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Get the currently displayed URL and show it in the textbox
            CurrentUrlTextBox.Text = e.Url.ToString();            

            // Check if the current URL contains the authorization token
            AuthorizationCodeTextBox.Text = OneDriveApi.GetAuthorizationTokenFromUrl(e.Url.ToString());

            // Verify if an authorization token was successfully extracted
            if (!string.IsNullOrEmpty(AuthorizationCodeTextBox.Text))
            {
                // Get an access token based on the authorization token that we now have
                await OneDriveApi.GetAccessToken();
                if (OneDriveApi.AccessToken != null)
                {
                    // Show the access token information in the textboxes
                    AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                    RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                    AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";
                    
                    // Store the refresh token in the AppSettings so next time you don't have to log in anymore
                    _configuration.AppSettings.Settings["OneDriveApiRefreshToken"].Value = RefreshTokenTextBox.Text;
                    _configuration.Save(ConfigurationSaveMode.Modified);
                    return;
                }
            }

            // If we're on this page, but we didn't get an authorization token, it means that we just signed out, proceed with signing in again
            if (CurrentUrlTextBox.Text.StartsWith(OneDriveApi.SignoutUri))
            {
                var authenticateUri = OneDriveApi.GetAuthenticationUri();
                AuthenticationBrowser.Navigate(authenticateUri);
            }
        }

       
        private void Step1Button_Click(object sender, EventArgs e)
        {
            // Reset any possible access tokens we may already have
            AccessTokenTextBox.Text = string.Empty;

            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // First sign the current user out to make sure he/she needs to authenticate again
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

            // Create a new instance of the OneDriveApi framework
            InitiateOneDriveApi();

            // Get a new access token based on the refresh token entered in the textbox
            await OneDriveApi.AuthenticateUsingRefreshToken(RefreshTokenTextBox.Text);

            if (OneDriveApi.AccessToken != null)
            {
                // Display the information of the new access token in the textboxes
                AccessTokenTextBox.Text = OneDriveApi.AccessToken.AccessToken;
                RefreshTokenTextBox.Text = OneDriveApi.AccessToken.RefreshToken;
                AccessTokenValidTextBox.Text = OneDriveApi.AccessTokenValidUntil.HasValue ? OneDriveApi.AccessTokenValidUntil.Value.ToString("dd-MM-yyyy HH:mm:ss") : "Not valid";
            }
        }

        private void AccessTokenTextBox_TextChanged(object sender, EventArgs e)
        {
            var accessTokenAvailable = !string.IsNullOrEmpty(((TextBox) sender).Text);
            OneDriveCommandsPanel.Enabled = accessTokenAvailable;
            AuthenticationBrowser.Visible = !accessTokenAvailable;
            JsonResultTextBox.Visible = accessTokenAvailable;
            JsonResultTextBox.Text = "Connected";
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            var fileToUpload = SelectLocalFile();

            // Reset the output field
            JsonResultTextBox.Text = $"Starting upload{Environment.NewLine}";

            // Define the anonynous method to respond to the file upload progress events
            EventHandler <OneDriveUploadProgressChangedEventArgs> progressHandler = delegate(object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

            // Subscribe to the upload progress event
            OneDriveApi.UploadProgressChanged += progressHandler;

            // Upload the file to the root of the OneDrive
            var data = await OneDriveApi.UploadFile(fileToUpload, await OneDriveApi.GetDriveRoot());

            // Unsubscribe from the upload progress event
            OneDriveApi.UploadProgressChanged -= progressHandler;

            // Display the result of the upload
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
            File.WriteAllText("NomeArquivo.txt", saida);
        }

        public static string ExecutarCMD(string comando)
        {
            System.Diagnostics.Process.Start("CMD.exe", @"/C " + comando).WaitForExit();

            return "Foi";

        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = e.Name.Substring(0, e.Name.Length - 4) + DateTime.Now.ToString("ddMMyyyy") + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    zip.Save(@"C:/temp/" + nomeCOncatenado);

                }
            }
        }

        private void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string nomeCOncatenado = string.Empty;
            if (e.Name.Contains(".sql"))
            {
                nomeCOncatenado = e.Name.Substring(0, e.Name.Length - 4) + DateTime.Now.ToString("ddMMyyyy") + ".zip";
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(e.FullPath, "");
                    zip.Save(@"C:/temp/" + nomeCOncatenado);

                }
            }

        }

        private async void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.Name.Substring(e.Name.Length - 4, 4).ToString() == ".zip")
            {
                var data = await OneDriveApi.UploadFileAs(e.FullPath, e.Name, await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO")));

                EventHandler<OneDriveUploadProgressChangedEventArgs> progressHandler = delegate (object s, OneDriveUploadProgressChangedEventArgs a) { JsonResultTextBox.Text += $"Uploading - {a.BytesSent} bytes sent / {a.TotalBytes} bytes total ({a.ProgressPercentage}%){Environment.NewLine}"; };

                OneDriveApi.UploadProgressChanged -= progressHandler;

                JsonResultTextBox.Text = "Upload Realizado com Sucesso"; //data != null ? data.OriginalJson : "Not available";
            }
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private async void AccessTokenValidTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AccessTokenValidTextBox.Text != "")
            {
                var MyIni = new IniFile("Settings.ini");
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                JsonResultTextBox.Text = "Conectado com Sucesso...";
                Notificacao.BalloonTipTitle = "OneDrive OpenNext";
                Notificacao.BalloonTipText = "Conectado com Sucesso...";
                Notificacao.ShowBalloonTip(20000);
                await OneDriveApi.GetFolderOrCreate(MyIni.Read("CNPJ", "USUARIO"));
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
    }
}