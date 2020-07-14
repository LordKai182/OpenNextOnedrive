namespace KoenZomers.OneDrive.AuthenticatorApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AuthenticationBrowser = new System.Windows.Forms.WebBrowser();
            this.Step1Button = new System.Windows.Forms.Button();
            this.CurrentUrlTextBox = new System.Windows.Forms.TextBox();
            this.CurrentUrlLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeLabel = new System.Windows.Forms.Label();
            this.AuthorizationCodeTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.JsonResultTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTokenButton = new System.Windows.Forms.Button();
            this.RefreshTokenLabel = new System.Windows.Forms.Label();
            this.RefreshTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenValidLabel = new System.Windows.Forms.Label();
            this.AccessTokenValidTextBox = new System.Windows.Forms.TextBox();
            this.OneDriveCommandsPanel = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.UseProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.OneDriveTypeCombo = new System.Windows.Forms.ComboBox();
            this.Notificacao = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.OneDriveCommandsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthenticationBrowser
            // 
            this.AuthenticationBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthenticationBrowser.Location = new System.Drawing.Point(11, 202);
            this.AuthenticationBrowser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AuthenticationBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.AuthenticationBrowser.Name = "AuthenticationBrowser";
            this.AuthenticationBrowser.ScriptErrorsSuppressed = true;
            this.AuthenticationBrowser.Size = new System.Drawing.Size(778, 526);
            this.AuthenticationBrowser.TabIndex = 0;
            this.AuthenticationBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.AuthenticationBrowser_Navigated);
            // 
            // Step1Button
            // 
            this.Step1Button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Step1Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Step1Button.Location = new System.Drawing.Point(12, 146);
            this.Step1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Step1Button.Name = "Step1Button";
            this.Step1Button.Size = new System.Drawing.Size(107, 41);
            this.Step1Button.TabIndex = 1;
            this.Step1Button.Text = "Autorizar";
            this.Step1Button.UseVisualStyleBackColor = false;
            this.Step1Button.Click += new System.EventHandler(this.Step1Button_Click);
            // 
            // CurrentUrlTextBox
            // 
            this.CurrentUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentUrlTextBox.Location = new System.Drawing.Point(12, 256);
            this.CurrentUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CurrentUrlTextBox.Name = "CurrentUrlTextBox";
            this.CurrentUrlTextBox.Size = new System.Drawing.Size(777, 22);
            this.CurrentUrlTextBox.TabIndex = 4;
            this.CurrentUrlTextBox.Visible = false;
            // 
            // CurrentUrlLabel
            // 
            this.CurrentUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentUrlLabel.AutoSize = true;
            this.CurrentUrlLabel.Location = new System.Drawing.Point(14, 234);
            this.CurrentUrlLabel.Name = "CurrentUrlLabel";
            this.CurrentUrlLabel.Size = new System.Drawing.Size(36, 17);
            this.CurrentUrlLabel.TabIndex = 5;
            this.CurrentUrlLabel.Text = "URL";
            this.CurrentUrlLabel.Visible = false;
            // 
            // AuthorizationCodeLabel
            // 
            this.AuthorizationCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthorizationCodeLabel.AutoSize = true;
            this.AuthorizationCodeLabel.Location = new System.Drawing.Point(12, 286);
            this.AuthorizationCodeLabel.Name = "AuthorizationCodeLabel";
            this.AuthorizationCodeLabel.Size = new System.Drawing.Size(151, 17);
            this.AuthorizationCodeLabel.TabIndex = 7;
            this.AuthorizationCodeLabel.Text = "Codigo de Autorizacao";
            this.AuthorizationCodeLabel.Visible = false;
            // 
            // AuthorizationCodeTextBox
            // 
            this.AuthorizationCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorizationCodeTextBox.Location = new System.Drawing.Point(11, 306);
            this.AuthorizationCodeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AuthorizationCodeTextBox.Name = "AuthorizationCodeTextBox";
            this.AuthorizationCodeTextBox.Size = new System.Drawing.Size(777, 22);
            this.AuthorizationCodeTextBox.TabIndex = 6;
            this.AuthorizationCodeTextBox.Visible = false;
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.Location = new System.Drawing.Point(12, 419);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(118, 17);
            this.AccessTokenLabel.TabIndex = 9;
            this.AccessTokenLabel.Text = "Token de Acesso";
            this.AccessTokenLabel.Visible = false;
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenTextBox.Location = new System.Drawing.Point(11, 440);
            this.AccessTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.Size = new System.Drawing.Size(777, 22);
            this.AccessTokenTextBox.TabIndex = 8;
            this.AccessTokenTextBox.Visible = false;
            this.AccessTokenTextBox.TextChanged += new System.EventHandler(this.AccessTokenTextBox_TextChanged);
            // 
            // JsonResultTextBox
            // 
            this.JsonResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JsonResultTextBox.Location = new System.Drawing.Point(17, 202);
            this.JsonResultTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JsonResultTextBox.Multiline = true;
            this.JsonResultTextBox.Name = "JsonResultTextBox";
            this.JsonResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.JsonResultTextBox.Size = new System.Drawing.Size(769, 516);
            this.JsonResultTextBox.TabIndex = 10;
            this.JsonResultTextBox.Visible = false;
            // 
            // RefreshTokenButton
            // 
            this.RefreshTokenButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RefreshTokenButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RefreshTokenButton.Location = new System.Drawing.Point(124, 146);
            this.RefreshTokenButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshTokenButton.Name = "RefreshTokenButton";
            this.RefreshTokenButton.Size = new System.Drawing.Size(107, 41);
            this.RefreshTokenButton.TabIndex = 12;
            this.RefreshTokenButton.Text = "Refresh";
            this.RefreshTokenButton.UseVisualStyleBackColor = false;
            this.RefreshTokenButton.Click += new System.EventHandler(this.RefreshTokenButton_Click);
            // 
            // RefreshTokenLabel
            // 
            this.RefreshTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshTokenLabel.AutoSize = true;
            this.RefreshTokenLabel.Location = new System.Drawing.Point(13, 333);
            this.RefreshTokenLabel.Name = "RefreshTokenLabel";
            this.RefreshTokenLabel.Size = new System.Drawing.Size(102, 17);
            this.RefreshTokenLabel.TabIndex = 14;
            this.RefreshTokenLabel.Text = "Refresh Token";
            this.RefreshTokenLabel.Visible = false;
            // 
            // RefreshTokenTextBox
            // 
            this.RefreshTokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshTokenTextBox.Location = new System.Drawing.Point(12, 352);
            this.RefreshTokenTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshTokenTextBox.Name = "RefreshTokenTextBox";
            this.RefreshTokenTextBox.Size = new System.Drawing.Size(777, 22);
            this.RefreshTokenTextBox.TabIndex = 13;
            this.RefreshTokenTextBox.Visible = false;
            // 
            // AccessTokenValidLabel
            // 
            this.AccessTokenValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccessTokenValidLabel.AutoSize = true;
            this.AccessTokenValidLabel.Location = new System.Drawing.Point(12, 375);
            this.AccessTokenValidLabel.Name = "AccessTokenValidLabel";
            this.AccessTokenValidLabel.Size = new System.Drawing.Size(127, 17);
            this.AccessTokenValidLabel.TabIndex = 16;
            this.AccessTokenValidLabel.Text = "Validade do Token";
            this.AccessTokenValidLabel.Visible = false;
            // 
            // AccessTokenValidTextBox
            // 
            this.AccessTokenValidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenValidTextBox.Location = new System.Drawing.Point(11, 396);
            this.AccessTokenValidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AccessTokenValidTextBox.Name = "AccessTokenValidTextBox";
            this.AccessTokenValidTextBox.Size = new System.Drawing.Size(777, 22);
            this.AccessTokenValidTextBox.TabIndex = 15;
            this.AccessTokenValidTextBox.Visible = false;
            this.AccessTokenValidTextBox.TextChanged += new System.EventHandler(this.AccessTokenValidTextBox_TextChanged);
            // 
            // OneDriveCommandsPanel
            // 
            this.OneDriveCommandsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OneDriveCommandsPanel.Controls.Add(this.button7);
            this.OneDriveCommandsPanel.Controls.Add(this.button6);
            this.OneDriveCommandsPanel.Controls.Add(this.button5);
            this.OneDriveCommandsPanel.Controls.Add(this.button4);
            this.OneDriveCommandsPanel.Controls.Add(this.button3);
            this.OneDriveCommandsPanel.Controls.Add(this.button2);
            this.OneDriveCommandsPanel.Controls.Add(this.button1);
            this.OneDriveCommandsPanel.Controls.Add(this.CreateFolderButton);
            this.OneDriveCommandsPanel.Controls.Add(this.UploadButton);
            this.OneDriveCommandsPanel.Enabled = false;
            this.OneDriveCommandsPanel.Location = new System.Drawing.Point(258, 9);
            this.OneDriveCommandsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OneDriveCommandsPanel.Name = "OneDriveCommandsPanel";
            this.OneDriveCommandsPanel.Size = new System.Drawing.Size(531, 190);
            this.OneDriveCommandsPanel.TabIndex = 17;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(293, 48);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(238, 64);
            this.button7.TabIndex = 32;
            this.button7.Text = "Upload Compartilhado";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(292, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(236, 41);
            this.button6.TabIndex = 31;
            this.button6.Text = "Criar Pasta Compartilhada";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(147, 48);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 64);
            this.button5.TabIndex = 30;
            this.button5.Text = "Ver Meu Drive";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(292, 118);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(236, 64);
            this.button4.TabIndex = 29;
            this.button4.Text = "Itens Compartilhados";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(147, 118);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 64);
            this.button3.TabIndex = 28;
            this.button3.Text = "Driver Compartilhado";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(0, 118);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 64);
            this.button2.TabIndex = 27;
            this.button2.Text = "Adicionar Usuario";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(3, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 64);
            this.button1.TabIndex = 26;
            this.button1.Text = "Executar POSTGRES";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CreateFolderButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateFolderButton.Location = new System.Drawing.Point(146, 3);
            this.CreateFolderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(140, 41);
            this.CreateFolderButton.TabIndex = 25;
            this.CreateFolderButton.Text = "Criar Pasta";
            this.CreateFolderButton.UseVisualStyleBackColor = false;
            this.CreateFolderButton.Click += new System.EventHandler(this.CreateFolderButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UploadButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UploadButton.Location = new System.Drawing.Point(3, 3);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(137, 41);
            this.UploadButton.TabIndex = 19;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // UseProxyCheckBox
            // 
            this.UseProxyCheckBox.AutoSize = true;
            this.UseProxyCheckBox.Location = new System.Drawing.Point(17, 112);
            this.UseProxyCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UseProxyCheckBox.Name = "UseProxyCheckBox";
            this.UseProxyCheckBox.Size = new System.Drawing.Size(99, 21);
            this.UseProxyCheckBox.TabIndex = 18;
            this.UseProxyCheckBox.Text = "Usar Proxy";
            this.UseProxyCheckBox.UseVisualStyleBackColor = true;
            // 
            // OneDriveTypeCombo
            // 
            this.OneDriveTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OneDriveTypeCombo.FormattingEnabled = true;
            this.OneDriveTypeCombo.Items.AddRange(new object[] {
            "Consumer OneDrive",
            "OneDrive for Business O365",
            "Graph API (Consumer & Business)"});
            this.OneDriveTypeCombo.Location = new System.Drawing.Point(15, 12);
            this.OneDriveTypeCombo.Margin = new System.Windows.Forms.Padding(4);
            this.OneDriveTypeCombo.Name = "OneDriveTypeCombo";
            this.OneDriveTypeCombo.Size = new System.Drawing.Size(216, 24);
            this.OneDriveTypeCombo.TabIndex = 19;
            // 
            // Notificacao
            // 
            this.Notificacao.Icon = ((System.Drawing.Icon)(resources.GetObject("Notificacao.Icon")));
            this.Notificacao.Text = "OpenNext OneDrive";
            this.Notificacao.Visible = true;
            this.Notificacao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Notificacao_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, -90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Location = new System.Drawing.Point(258, 9);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(531, 192);
            this.panelLogo.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(801, 761);
            this.Controls.Add(this.panelLogo);
            this.Controls.Add(this.OneDriveTypeCombo);
            this.Controls.Add(this.UseProxyCheckBox);
            this.Controls.Add(this.RefreshTokenButton);
            this.Controls.Add(this.JsonResultTextBox);
            this.Controls.Add(this.Step1Button);
            this.Controls.Add(this.AuthenticationBrowser);
            this.Controls.Add(this.OneDriveCommandsPanel);
            this.Controls.Add(this.AccessTokenValidLabel);
            this.Controls.Add(this.AccessTokenValidTextBox);
            this.Controls.Add(this.RefreshTokenLabel);
            this.Controls.Add(this.RefreshTokenTextBox);
            this.Controls.Add(this.AccessTokenLabel);
            this.Controls.Add(this.AccessTokenTextBox);
            this.Controls.Add(this.AuthorizationCodeLabel);
            this.Controls.Add(this.AuthorizationCodeTextBox);
            this.Controls.Add(this.CurrentUrlLabel);
            this.Controls.Add(this.CurrentUrlTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(381, 309);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OneDrive API OpenNext";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.OneDriveCommandsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser AuthenticationBrowser;
        private System.Windows.Forms.Button Step1Button;
        private System.Windows.Forms.TextBox CurrentUrlTextBox;
        private System.Windows.Forms.Label CurrentUrlLabel;
        private System.Windows.Forms.Label AuthorizationCodeLabel;
        private System.Windows.Forms.TextBox AuthorizationCodeTextBox;
        private System.Windows.Forms.Label AccessTokenLabel;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.TextBox JsonResultTextBox;
        private System.Windows.Forms.Button RefreshTokenButton;
        private System.Windows.Forms.Label RefreshTokenLabel;
        private System.Windows.Forms.TextBox RefreshTokenTextBox;
        private System.Windows.Forms.Label AccessTokenValidLabel;
        private System.Windows.Forms.TextBox AccessTokenValidTextBox;
        private System.Windows.Forms.Panel OneDriveCommandsPanel;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.CheckBox UseProxyCheckBox;
        private System.Windows.Forms.ComboBox OneDriveTypeCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon Notificacao;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLogo;
    }
}

