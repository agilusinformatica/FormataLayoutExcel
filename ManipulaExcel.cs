using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using FlexCel;
using FlexCel.XlsAdapter;
using FlexCel.Core;
using System.Windows.Forms;

namespace FormataLayoutExcel
{
    class ManipulaExcel
    {
        public List<DataTable> LerExcel(string caminho, XlsFile excel)
        {
            List<DataTable> abas = new List<DataTable>();

            //ABRINDO XLSX
            excel.Open(caminho);
            //VARRER TODAS WORKSHEETS EXISTENTES
            for (int i = 1; i <= excel.SheetCount; i++)
            {
                excel.ActiveSheet = i;

                DataTable tabela = LerTitulosAba(excel);
                if (tabela.Columns.Count > 0)
                    abas.Add(tabela);
            }

            return abas;
        }


        public List<string> ListarAbas(string caminho)
        {
            List<string> abas = new List<string>();

            //ABRINDO XLSX
            var excel = new XlsFile();
            excel.Open(caminho);
            //VARRER TODAS WORKSHEETS EXISTENTES
            for (int i = 1; i <= excel.SheetCount; i++)
            {
                excel.ActiveSheet = i;
                abas.Add(excel.SheetName);
            }

            return abas;
        }

        public static DataTable LerTitulosAba(XlsFile excel)
        {
            DataTable tabela = new DataTable();
            int qtdeColunas = excel.ColCountOnlyData;
            for (int cont = 1; cont <= qtdeColunas; cont++)
            {
                Object coluna = excel.GetCellValue(1, cont);

                if (coluna != null)
                {
                    try
                    {
                        tabela.Columns.Add(coluna.ToString());
                    }
                    catch (DuplicateNameException)
                    {
                        string nomeArquivo = excel.ActiveFileName.Split('\\')[excel.ActiveFileName.Split('\\').Length - 1],
                               aba = excel.ActiveSheetByName;

                        throw new Exception("O arquivo \"" + nomeArquivo + "\""  + ", na aba \"" + aba + "\", está com o nome de coluna \"" + coluna.ToString() + "\" duplicada. \n\n Por favor renomeie a coluna e salve o arquivo antes de prosseguir.");
                    }
                }
            }
            return tabela;
        }

        public void GerarExcel(string Nome_Arquivo_Origem,string Nome_Arquivo_Destino, int CodLayout, Dados d, ProgressBar statusGeracaoArquivo)
        {
            // Criando Aplicação
            XlsFile excelDestino = new XlsFile();
            XlsFile excelOrigem = new XlsFile();

            excelOrigem.Open(Nome_Arquivo_Origem);
            int QtdeLinhas = excelOrigem.RowCount;

            //Gerando arquivo de saída
            for (int i = 1; i <= excelOrigem.SheetCount; i++)
            {
                excelOrigem.ActiveSheet = i;
                excelDestino.NewFile(1);

                //LEITURA DOS DADOS ABAS
                int qtdeColunas = excelOrigem.ColCountOnlyData;

                if (qtdeColunas > 0)
                {
                    for (int cont = 1; cont <= qtdeColunas; cont++)
                    {
                        Object titulo = excelOrigem.GetCellValue(1, cont);

                        if (titulo != null)
                        {
                            string LetraColuna = d.PosicaoVinculada(CodLayout, titulo.ToString());
                            int numeroColuna;

                            try
                            {
                                numeroColuna = Convert.ToInt16(LetraColuna);
                            }
                            catch (Exception)
                            {
                                numeroColuna = LetrasParaNumero(LetraColuna);
                            }

                            if (LetraColuna != null)
                            {
                                excelDestino.InsertAndCopyRange(
                                    new TXlsCellRange(1, cont, QtdeLinhas, cont),
                                    1,
                                    numeroColuna,
                                    1,
                                    TFlxInsertMode.NoneRight,
                                    TRangeCopyMode.All,
                                    excelOrigem,
                                    i
                                );
                            }
                        }
                    }
                    int c = 0;

                    string novoNomeArquivo = Path.GetDirectoryName(Nome_Arquivo_Destino) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(Nome_Arquivo_Destino) + "_" + excelOrigem.SheetName + Path.GetExtension(Nome_Arquivo_Destino);
                    
                    while (File.Exists(novoNomeArquivo))
                    {
                        c++;
                        novoNomeArquivo = Path.GetDirectoryName(Nome_Arquivo_Destino) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(Nome_Arquivo_Destino) + "_" + excelOrigem.SheetName + i + Path.GetExtension(Nome_Arquivo_Destino);
                    }

                    excelDestino.Save(novoNomeArquivo);
                }
                statusGeracaoArquivo.Value = statusGeracaoArquivo.Value + 1;
            }
        }

        private int IndiceLetra(string letra)
        {
            return Encoding.ASCII.GetBytes(letra)[0] - 64;
        }

        private int LetrasParaNumero(string letras)
        {
            int i, o, p, Fator, resultado = 0;

            letras = letras.ToUpper();
            Fator = letras.Length;

            for (i = 0; i < letras.Length; i++)
            {
                o = IndiceLetra(letras.Substring(i, 1));
                p = Convert.ToInt16(Math.Floor(Math.Pow(26, Fator - 1)));

                resultado += o * p;
                Fator--;
            }
            return resultado;
        }

        public int contarAbas(string arquivo)
        {
            XlsFile tempExcel = new XlsFile();
            tempExcel.Open(arquivo);

            return tempExcel.SheetCount;
        }
    }
}


