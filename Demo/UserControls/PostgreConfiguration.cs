using System.IO;
using System.Windows.Forms;

namespace OpenNextOneDrive.UserControls
{
    public partial class PostgreConfiguration : UserControl
    {
        public ConfiguracaoClienteConfiguracao _configuracaoAcess;
        public PostgreConfiguration()
        {
            InitializeComponent();
         
        }

        public PostgreConfiguration(ConfiguracaoClienteConfiguracao configuracaoAcess)
        {
            InitializeComponent();
            _configuracaoAcess = configuracaoAcess;
        }

        public bool VerificaArquivo()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arquivo = openFileDialog1.FileName;
                if (File.Exists(arquivo) && openFileDialog1.SafeFileName == "pg_dump.exe")
                {
                    TxtCaminhoDump.Text = arquivo;
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
                TxtPastaBkp.Text = folderDlg.SelectedPath;
                _configuracaoAcess.PastaBkp = folderDlg.SelectedPath;
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            VerificaArquivo();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            VarificaPasta();
        }
    }
}
