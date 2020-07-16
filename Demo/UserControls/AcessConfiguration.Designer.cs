namespace OpenNextOneDrive.UserControls
{
    partial class AcessConfiguration
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
            this.TxtCaminhoAccess = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtCaminhoPastaBkp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CbHoraBkp = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TxtCaminhoAccess
            // 
            this.TxtCaminhoAccess.Location = new System.Drawing.Point(23, 64);
            this.TxtCaminhoAccess.Multiline = true;
            this.TxtCaminhoAccess.Name = "TxtCaminhoAccess";
            this.TxtCaminhoAccess.ReadOnly = true;
            this.TxtCaminhoAccess.Size = new System.Drawing.Size(488, 30);
            this.TxtCaminhoAccess.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar Arquivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caminho para o Banco Access";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pasta de Backup";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(520, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Buscar Pasta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtCaminhoPastaBkp
            // 
            this.TxtCaminhoPastaBkp.Location = new System.Drawing.Point(23, 134);
            this.TxtCaminhoPastaBkp.Multiline = true;
            this.TxtCaminhoPastaBkp.Name = "TxtCaminhoPastaBkp";
            this.TxtCaminhoPastaBkp.ReadOnly = true;
            this.TxtCaminhoPastaBkp.Size = new System.Drawing.Size(488, 30);
            this.TxtCaminhoPastaBkp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Realizar Backup a cada: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CbHoraBkp
            // 
            this.CbHoraBkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbHoraBkp.FormattingEnabled = true;
            this.CbHoraBkp.Items.AddRange(new object[] {
            "3 Horas",
            "4 Horas",
            "5 Horas",
            "6 Horas",
            "7 Horas",
            "8 Horas"});
            this.CbHoraBkp.Location = new System.Drawing.Point(189, 187);
            this.CbHoraBkp.Margin = new System.Windows.Forms.Padding(4);
            this.CbHoraBkp.Name = "CbHoraBkp";
            this.CbHoraBkp.Size = new System.Drawing.Size(168, 24);
            this.CbHoraBkp.TabIndex = 21;
            this.CbHoraBkp.SelectedIndexChanged += new System.EventHandler(this.CbHoraBkp_SelectedIndexChanged);
            // 
            // AcessConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbHoraBkp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtCaminhoPastaBkp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtCaminhoAccess);
            this.Name = "AcessConfiguration";
            this.Size = new System.Drawing.Size(772, 520);
            this.Load += new System.EventHandler(this.AcessConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCaminhoAccess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtCaminhoPastaBkp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox CbHoraBkp;
    }
}
