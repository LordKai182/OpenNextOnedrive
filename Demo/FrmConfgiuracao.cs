using Newtonsoft.Json;
using OpenNextOneDrive.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenNextOneDrive
{
    public partial class FrmConfgiuracao : Form
    {
        Configuracao _configuracao = new Configuracao();
        ConfiguracaoCliente _cliente = new ConfiguracaoCliente();
        ClienteControll myUserControlCli;
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
                PostgreConfiguration myUserControl;
                myUserControl = new PostgreConfiguration();
                myUserControl.Dock = DockStyle.Fill;
                tabPostgre.Controls.Add(myUserControl);
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
                myUserControlCli._configuracao.Configuracao = myUserControlAccess._configuracaoAcess;
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
           

            File.WriteAllText("config.json", JsonConvert.SerializeObject(_configuracao));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
