using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNextOneDrive
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Configuracao
    {

        private string clientIDField;

        private string clientSecretField;

        private string redirectUriField;

        private List<ConfiguracaoCliente> clienteField;

        /// <remarks/>
        public string ClientID
        {
            get
            {
                return this.clientIDField;
            }
            set
            {
                this.clientIDField = value;
            }
        }

        /// <remarks/>
        public string ClientSecret
        {
            get
            {
                return this.clientSecretField;
            }
            set
            {
                this.clientSecretField = value;
            }
        }

        /// <remarks/>
        public string RedirectUri
        {
            get
            {
                return this.redirectUriField;
            }
            set
            {
                this.redirectUriField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cliente")]
        public List<ConfiguracaoCliente> Cliente
        {
            get
            {
                return this.clienteField;
            }
            set
            {
                this.clienteField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfiguracaoCliente
    {

        private string cnpjField;

        private string razaoSocialField;

        private string telefoneField;

        private string emailField;

        private ConfiguracaoClienteConfiguracao configuracaoField;

        private byte idField;

        /// <remarks/>
        public string Cnpj
        {
            get
            {
                return this.cnpjField;
            }
            set
            {
                this.cnpjField = value;
            }
        }

        /// <remarks/>
        public string RazaoSocial
        {
            get
            {
                return this.razaoSocialField;
            }
            set
            {
                this.razaoSocialField = value;
            }
        }

        /// <remarks/>
        public string Telefone
        {
            get
            {
                return this.telefoneField;
            }
            set
            {
                this.telefoneField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public ConfiguracaoClienteConfiguracao Configuracao
        {
            get
            {
                return this.configuracaoField;
            }
            set
            {
                this.configuracaoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfiguracaoClienteConfiguracao
    {

        private byte tipoConfigField;

        private string caminhoDumpField;

        private string nomeBkpField;

        private string pastaBkpField;

        private string horaBkpField;

        /// <remarks/>
        public byte TipoConfig
        {
            get
            {
                return this.tipoConfigField;
            }
            set
            {
                this.tipoConfigField = value;
            }
        }

        /// <remarks/>
        public string CaminhoDump
        {
            get
            {
                return this.caminhoDumpField;
            }
            set
            {
                this.caminhoDumpField = value;
            }
        }

        /// <remarks/>
        public string NomeBkp
        {
            get
            {
                return this.nomeBkpField;
            }
            set
            {
                this.nomeBkpField = value;
            }
        }

        /// <remarks/>
        public string PastaBkp
        {
            get
            {
                return this.pastaBkpField;
            }
            set
            {
                this.pastaBkpField = value;
            }
        }

        /// <remarks/>
        public string HoraBkp
        {
            get
            {
                return this.horaBkpField;
            }
            set
            {
                this.horaBkpField = value;
            }
        }
    }


}
