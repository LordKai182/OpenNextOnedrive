using System;
using System.Windows.Forms;

namespace OpenNextOneDrive.UserControls
{
    public partial class ClienteControll : UserControl
    {
        public ConfiguracaoCliente _configuracao;
        public ClienteControll(ConfiguracaoCliente _config, int id)
        {
            _configuracao = _config;
            InitializeComponent();

            TxtCnpj.Text = _configuracao.Cnpj;
            TxtEmail.Text = _configuracao.Email;
            TxtNome.Text = _configuracao.RazaoSocial;
            TxtTelefone.Text = _configuracao.Telefone;
            _configuracao.id = (byte)id;

        }

        private void TxtCnpj_TextChanged(object sender, EventArgs e)
        {
            _configuracao.Cnpj = TxtCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", ""); ;
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            _configuracao.RazaoSocial = TxtNome.Text;
        }

        private void TxtTelefone_TextChanged(object sender, EventArgs e)
        {
            _configuracao.Telefone = TxtNome.Text;
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            _configuracao.Email = TxtEmail.Text;
        }
    }
}
