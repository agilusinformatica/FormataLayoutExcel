using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FlexCel.XlsAdapter;
using System.Diagnostics;

namespace FormataLayoutExcel
{
    public partial class AbreExcel : Form
    {
        Dados d;

        public AbreExcel()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            Grid.Rows.Clear();
            List<string> colunasExcel = new List<string>();

            if (Ofd_OpenFile.ShowDialog() == DialogResult.OK)
            {
                ManipulaExcel excelAtivo = new ManipulaExcel();
                XlsFile excel = new XlsFile();

                //Conta quantas abas tem em todos os arquivos
                progressBar.Value = 0;
                progressBar.Maximum = 0;

                foreach (string file in Ofd_OpenFile.FileNames)
                    progressBar.Maximum += excelAtivo.contarAbas(file);

                foreach (string file in Ofd_OpenFile.FileNames)
                {
                    try
                    {
                        List<DataTable> abas = excelAtivo.LerExcel(file, excel);
                        foreach (var aba in abas)
                        {
                            ColunaLayout.DataSource = d.ColunasLayout((int)layoutsComboBox.SelectedValue);
                            ColunaLayout.DisplayMember = "lim_nome_coluna";
                            ColunaLayout.ValueMember = "lim_codigo";

                            foreach (DataColumn coluna in aba.Columns)
                            {
                                if (colunasExcel.IndexOf(coluna.ColumnName) == -1)
                                {
                                    Grid.Rows.Add();
                                    DataGridViewRow novaLinha = Grid.Rows[Grid.RowCount - 1];
                                    novaLinha.Cells[0].Value = coluna.ColumnName;
                                    colunasExcel.Add(coluna.ColumnName);

                                    // Preencher valor default do combobox com PosicaoVinculada
                                    novaLinha.Cells[1].Value = d.CodPosicaoVinculada((int)layoutsComboBox.SelectedValue, coluna.ColumnName);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AbreExcel_Load(object sender, EventArgs e)
        {
            loadFile();
            //Carregando layouts de a conexão for bem sucedida
            layoutsComboBox.DataSource = d.Layouts();
            layoutsComboBox.ValueMember = "cim_codigo";
            layoutsComboBox.DisplayMember = "cim_descricao";
        }

        private void loadFile()
        {
            //Obtendo nós do xml de conexão, para verificar se está vazio
            string Servidor, BD;
            Configuracao.LerConfiguracao(out Servidor, out BD);

            if (Servidor == String.Empty || BD == String.Empty)
            {
                using (Config form = new Config())
                {
                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            d = new Dados();
            layoutsComboBox.DataSource = d.Layouts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar.Value > 0)
            {
                progressBar.Value = 0;
            }

            DataTable GridInfo = new DataTable();
            GridInfo.Columns.Add("cim_codigo");
            GridInfo.Columns.Add("lim_codigo");
            GridInfo.Columns.Add("coluna_excel");

            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells[1].Value != null)
                {
                    DataRow tabelaRow = GridInfo.NewRow();
                    tabelaRow[0] = layoutsComboBox.SelectedValue;
                    tabelaRow[1] = linha.Cells[1].Value;
                    tabelaRow[2] = linha.Cells[0].Value;
                    GridInfo.Rows.Add(tabelaRow); // ADICIONA OS DADOS NA TABELA.
                }
            }

            d.InserirVinculos(GridInfo, (int)layoutsComboBox.SelectedValue);

            ManipulaExcel excel = new ManipulaExcel();
            string diretorioArquivos = Ofd_OpenFile.FileNames[0].Replace(Path.GetFileName(Ofd_OpenFile.FileNames[0]), "");
            string novaPasta = String.Empty;

            //Criando a pasta com arquivos processados (receberá os arquivos de saída)
            if (!Directory.Exists(diretorioArquivos + "Arquivos processados"))
            {
                Directory.CreateDirectory(diretorioArquivos + "Arquivos processados");
                novaPasta = "Arquivos processados";
            }
            else
            {
                int cont = 0;
                while (Directory.Exists(Path.GetDirectoryName(diretorioArquivos) + Path.DirectorySeparatorChar + novaPasta))
                {
                    cont++;
                    novaPasta = "Arquivos processados(" + cont.ToString() + ")";
                }
                Directory.CreateDirectory(diretorioArquivos + novaPasta);
            }

            //Lendo arquivos para geração do resultado organizado
            foreach (string file in Ofd_OpenFile.FileNames)
            {
                try
                {
                    excel.GerarExcel(file, file.Replace(Path.GetFileName(file), "") + novaPasta + Path.DirectorySeparatorChar + Path.GetFileName(file),
                    (int)layoutsComboBox.SelectedValue, d, progressBar);
                }
                catch (Exception ex)
                {
                    if (!novaPasta.Equals(String.Empty))
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(diretorioArquivos + novaPasta);

                        //Apagando arquivos da pasta nova que será apagada, caso existam
                        foreach (FileInfo fileDi in di.GetFiles())
                        {
                            fileDi.Delete();
                        }
                    }

                    //Apagando diretório criado para os arquivos processados
                    Directory.Delete(diretorioArquivos + novaPasta);
                    MessageBox.Show("Erro durante o processamento do arquivo " + file + ".\n\nDetalhe: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Processamento efetuado com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Process.Start(diretorioArquivos + novaPasta);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Config form = new Config())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    d = new Dados();
                    layoutsComboBox.DataSource = d.Layouts();
                }
            }
        }
    }
}
