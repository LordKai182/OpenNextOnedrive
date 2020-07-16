using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenNextOneDrive.UserControls
{
    public partial class AcessConfiguration : UserControl
    {
        public ConfiguracaoClienteConfiguracao _configuracaoAcess;
        public AcessConfiguration(ConfiguracaoClienteConfiguracao configuracaoClienteConfiguracao)
        {
            InitializeComponent();
            _configuracaoAcess = configuracaoClienteConfiguracao;
            CbHoraBkp.SelectedIndex = 0;
          
        }

        public bool VerificaArquivo()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arquivo = openFileDialog1.FileName;
                if (File.Exists(arquivo) && arquivo.Contains(".mdb"))
                {
                    TxtCaminhoAccess.Text = arquivo;
                    _configuracaoAcess.CaminhoDump = arquivo; 
                   

                    return true;
                }

            }
            return false;
        }
        public bool VarificaPasta()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtCaminhoPastaBkp.Text = folderDlg.SelectedPath;
                return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VerificaArquivo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VarificaPasta();
        }

        private void AcessConfiguration_Load(object sender, EventArgs e)
        {
            CbHoraBkp.SelectedIndex = 0;
        }

        private void CbHoraBkp_SelectedIndexChanged(object sender, EventArgs e)
        {
            _configuracaoAcess.HoraBkp = CbHoraBkp.SelectedItem.ToString().Substring(0, 1);
        }
    }
}
