namespace OpenNextOneDrive
{
    partial class FrmConfgiuracao
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
            this.CbTipoConfiguracao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabPostgre = new System.Windows.Forms.TabPage();
            this.tabAccess = new System.Windows.Forms.TabPage();
            this.tabCliente = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbTipoConfiguracao
            // 
            this.CbTipoConfiguracao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTipoConfiguracao.FormattingEnabled = true;
            this.CbTipoConfiguracao.Items.AddRange(new object[] {
            "PostgerSQL",
            "Access"});
            this.CbTipoConfiguracao.Location = new System.Drawing.Point(13, 36);
            this.CbTipoConfiguracao.Margin = new System.Windows.Forms.Padding(4);
            this.CbTipoConfiguracao.Name = "CbTipoConfiguracao";
            this.CbTipoConfiguracao.Size = new System.Drawing.Size(257, 24);
            this.CbTipoConfiguracao.TabIndex = 20;
            this.CbTipoConfiguracao.SelectedIndexChanged += new System.EventHandler(this.CbTipoConfiguracao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tipo de Configuracao";
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Controls.Add(this.tabPostgre);
            this.tabControlConfig.Controls.Add(this.tabAccess);
            this.tabControlConfig.Controls.Add(this.tabCliente);
            this.tabControlConfig.Location = new System.Drawing.Point(13, 99);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(781, 413);
            this.tabControlConfig.TabIndex = 22;
            // 
            // tabPostgre
            // 
            this.tabPostgre.Location = new System.Drawing.Point(4, 25);
            this.tabPostgre.Name = "tabPostgre";
            this.tabPostgre.Padding = new System.Windows.Forms.Padding(3);
            this.tabPostgre.Size = new System.Drawing.Size(773, 384);
            this.tabPostgre.TabIndex = 0;
            this.tabPostgre.Text = "Configuracao PostgreSQL";
            this.tabPostgre.UseVisualStyleBackColor = true;
            // 
            // tabAccess
            // 
            this.tabAccess.Location = new System.Drawing.Point(4, 25);
            this.tabAccess.Name = "tabAccess";
            this.tabAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccess.Size = new System.Drawing.Size(773, 384);
            this.tabAccess.TabIndex = 1;
            this.tabAccess.Text = "Configuracao Access";
            this.tabAccess.UseVisualStyleBackColor = true;
            // 
            // tabCliente
            // 
            this.tabCliente.Location = new System.Drawing.Point(4, 25);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.Size = new System.Drawing.Size(773, 384);
            this.tabCliente.TabIndex = 2;
            this.tabCliente.Text = "Configuracao Cliente";
            this.tabCliente.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(669, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 46);
            this.button1.TabIndex = 23;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmConfgiuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(806, 524);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControlConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbTipoConfiguracao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmConfgiuracao";
            this.Text = "Configracoes";
            this.Load += new System.EventHandler(this.FrmConfgiuracao_Load);
            this.tabControlConfig.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbTipoConfiguracao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabPostgre;
        private System.Windows.Forms.TabPage tabAccess;
        private System.Windows.Forms.TabPage tabCliente;
        private System.Windows.Forms.Button button1;
    }
}