namespace OpenNextOneDrive.UserControls
{
    partial class PostgreConfiguration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtCaminhoDump = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtPastaBkp = new System.Windows.Forms.TextBox();
            this.CbTipoConfiguracao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Caminho para o arquido de Dump PostgreSQL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar Arquivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtCaminhoDump
            // 
            this.TxtCaminhoDump.Location = new System.Drawing.Point(26, 68);
            this.TxtCaminhoDump.Multiline = true;
            this.TxtCaminhoDump.Name = "TxtCaminhoDump";
            this.TxtCaminhoDump.ReadOnly = true;
            this.TxtCaminhoDump.Size = new System.Drawing.Size(488, 30);
            this.TxtCaminhoDump.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pasta de Backup";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(523, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar Pasta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtPastaBkp
            // 
            this.TxtPastaBkp.Location = new System.Drawing.Point(26, 129);
            this.TxtPastaBkp.Multiline = true;
            this.TxtPastaBkp.Name = "TxtPastaBkp";
            this.TxtPastaBkp.ReadOnly = true;
            this.TxtPastaBkp.Size = new System.Drawing.Size(488, 30);
            this.TxtPastaBkp.TabIndex = 6;
            // 
            // CbTipoConfiguracao
            // 
            this.CbTipoConfiguracao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTipoConfiguracao.FormattingEnabled = true;
            this.CbTipoConfiguracao.Items.AddRange(new object[] {
            "3 Horas",
            "4 Horas",
            "5 Horas",
            "6 Horas",
            "7 Horas",
            "8 Horas"});
            this.CbTipoConfiguracao.Location = new System.Drawing.Point(195, 171);
            this.CbTipoConfiguracao.Margin = new System.Windows.Forms.Padding(4);
            this.CbTipoConfiguracao.Name = "CbTipoConfiguracao";
            this.CbTipoConfiguracao.Size = new System.Drawing.Size(168, 24);
            this.CbTipoConfiguracao.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Realizar Backup a cada: ";
            // 
            // PostgreConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbTipoConfiguracao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtPastaBkp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtCaminhoDump);
            this.Name = "PostgreConfiguration";
            this.Size = new System.Drawing.Size(837, 560);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtCaminhoDump;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtPastaBkp;
        private System.Windows.Forms.ComboBox CbTipoConfiguracao;
        private System.Windows.Forms.Label label3;
    }
}
