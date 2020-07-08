﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenNextOneDrive.UserControls
{
    public partial class AcessConfiguration : UserControl
    {
        public ConfiguracaoClienteConfiguracao _configuracaoAcess;
        public AcessConfiguration(ConfiguracaoClienteConfiguracao configuracaoClienteConfiguracao)
        {
            InitializeComponent();
            _configuracaoAcess = configuracaoClienteConfiguracao;

            DateTimePicker TimerPiker = new DateTimePicker();
            TimerPiker.Format = DateTimePickerFormat.Custom;
            TimerPiker.CustomFormat = "HH:mm tt";
            TimerPiker.ShowUpDown = true;
            TimerPiker.Location = new Point(20, 160);
            TimerPiker.Width = 100;
            Controls.Add(TimerPiker);
        }
    }
}
