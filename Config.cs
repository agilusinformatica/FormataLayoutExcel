using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormataLayoutExcel
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if ((servidorTextBox.Text == String.Empty || bancoDadosTextBox.Text == String.Empty ))
            {
                MessageBox.Show("Os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                Configuracao.GerarConfiguracao(servidorTextBox.Text, bancoDadosTextBox.Text);
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {
            string s, d;
            Configuracao.LerConfiguracao(out s, out d);
            servidorTextBox.Text = s;
            bancoDadosTextBox.Text = d;
        }
    }
}
