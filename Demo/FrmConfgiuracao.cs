using KoenZomers.OneDrive.AuthenticatorApp;
using Newtonsoft.Json;
using OpenNextOneDrive.UserControls;
using OpenNextOneDrive.Validacao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenNextOneDrive
{
    public partial class FrmConfgiuracao : Form
    {
        Configuracao _configuracao = new Configuracao();
        ConfiguracaoCliente _cliente = new ConfiguracaoCliente();    
        List<string> listaErros = new List<string>();
        ClienteControll myUserControlCli;
        PostgreConfiguration myUserControlPostgre;
        AcessConfiguration myUserControlAccess;
        ConfiguracaoClienteConfiguracao _configAmbiente = new ConfiguracaoClienteConfiguracao();
        bool jsonprecarregado = false;
        public FrmConfgiuracao()
        {
            InitializeComponent();

        }

        public FrmConfgiuracao(Configuracao configuracao)
        {
             jsonprecarregado = true;
            _configuracao = configuracao;
            InitializeComponent();

        }

        
        private void FrmConfgiuracao_Load(object sender, EventArgs e)
        {
            tabControlConfig.Visible = false;
           

        }

        private void CbTipoConfiguracao_SelectedIndexChanged(object sender, EventArgs e)
        {
                HabilitaTabControlETab(CbTipoConfiguracao.SelectedIndex);
            
        }

        private void HabilitaTabControlETab(int tab)
        {
            if(tab == 0)
            {
                tabControlConfig.Visible = true;
                tabControlConfig.TabPages.Remove(tabAccess);
                tabControlConfig.TabPages.Remove(tabPostgre);
                tabControlConfig.TabPages.Remove(tabCliente);
                
                myUserControlPostgre = new PostgreConfiguration(_configAmbiente);
                myUserControlPostgre.Dock = DockStyle.Fill;
                tabPostgre.Controls.Add(myUserControlPostgre);
                tabControlConfig.TabPages.Add(tabPostgre);
               
                myUserControlCli = new ClienteControll(_cliente, 1);
                myUserControlCli.Dock = DockStyle.Fill;
                tabCliente.Controls.Add(myUserControlCli);
                tabControlConfig.TabPages.Add(tabCliente);
            }
            if (tab == 1)
            {
                tabControlConfig.Visible = true;
                tabControlConfig.TabPages.Remove(tabAccess);
                tabControlConfig.TabPages.Remove(tabPostgre);
                tabControlConfig.TabPages.Remove(tabCliente);

                myUserControlAccess = new AcessConfiguration(_configAmbiente);
                myUserControlAccess.Dock = DockStyle.Fill;
                tabAccess.Controls.Add(myUserControlAccess);
                tabControlConfig.TabPages.Add(tabAccess);
                myUserControlCli = new ClienteControll(_cliente,  1);
                myUserControlCli.Dock = DockStyle.Fill;
                tabCliente.Controls.Add(myUserControlCli);
                tabControlConfig.TabPages.Add(tabCliente);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {    
            if(CbTipoConfiguracao.SelectedIndex == 1)
            {
                myUserControlAccess._configuracaoAcess.TipoConfig = 1;
                myUserControlCli._configuracao.Configuracao = myUserControlAccess._configuracaoAcess;
            }
            if (CbTipoConfiguracao.SelectedIndex == 0)
            {
                myUserControlPostgre._configuracaoAcess.TipoConfig = 2;
                myUserControlCli._configuracao.Configuracao = myUserControlPostgre._configuracaoAcess;
            }

            _configuracao.ClientID = "51afccd5-ac7c-4513-951f-94fa5c0d6ece";
            _configuracao.ClientSecret = "84HQx9rc6~_kfB~UI4vM2TwCmArQ.xS7cF";
            if (jsonprecarregado)
            {
                _configuracao.Cliente.Add(myUserControlCli._configuracao);
            }
            if (!jsonprecarregado)
            {
                _configuracao.Cliente = new List<ConfiguracaoCliente>();
                _configuracao.Cliente.Add(myUserControlCli._configuracao);
            }

            if (carregaValidacao())
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(_configuracao));
                if (File.Exists("config.json"))
                {
                    MainForm frm = new MainForm();
                    frm.ShowDialog();
                    this.Close();
                }

               
            }
            else
            {
                string Msg = string.Empty;
                foreach (var item in listaErros)
                {
                    Msg += item + Environment.NewLine;
                }

                MessageBox.Show(this, Msg, "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public bool carregaValidacao() {

            ValidacaoEntrada valida = new ValidacaoEntrada();
            listaErros = new List<string>();
            foreach (var item in _configuracao.Cliente)
            {
                if ( item.Cnpj == null || !valida.IsCnpj(item.Cnpj))
                {
                    listaErros.Add(
                        String.Format(" Cliente: {0} Erro: {1}", item.RazaoSocial, "CNPJ invalido")
                        );
                }
                if(item.RazaoSocial == null)
                {
                    listaErros.Add(
                       String.Format(" Cliente: {0} Erro: {1}", item.RazaoSocial, "Razao Social invalida")
                       );
                }
                if(item.Email == null || !item.Email.Contains("@"))
                {
                    listaErros.Add(
                      String.Format(" Cliente: {0} Erro: {1}", item.RazaoSocial, "E-mail Invalido")
                      );
                }
                if (item.Telefone == string.Empty)
                {
                    listaErros.Add(
                      String.Format(" Cliente: {0} Erro: {1}", item.RazaoSocial, "Telefone Invalido")
                      );
                }
                if(item.Configuracao == null || item.Configuracao.CaminhoDump == null || item.Configuracao.PastaBkp == null)
                {
                    listaErros.Add(
                     String.Format(" Cliente: {0} Erro: {1}", item.RazaoSocial, "Configuracao de Backup Invalida")
                     );
                }
            }
            if(listaErros.Count() > 0)
            {
                return false;
            }
            return true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
