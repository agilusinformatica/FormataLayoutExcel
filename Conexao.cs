using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FormataLayoutExcel
{
    public class Dados
    {
        string connectionString;
        public Dados ()
	    {
            string s, d;
            Configuracao.LerConfiguracao(out s, out d);
            if (s == String.Empty)
                throw new Exception("Configuração de acesso não encontrada!");
            connectionString = @"server=" + s + ";Database=" + d + ";User Id=;Password=;";
	    }

        private DataTable GeraLista(string comandoSql)
        {
            SqlConnection ConexaoSql = new SqlConnection(connectionString);
            DataTable resultado = new DataTable();

            try
            {
                ConexaoSql.Open();
                SqlCommand cmd = new SqlCommand(comandoSql, ConexaoSql);
                SqlDataReader tabela = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(tabela);
                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro: " + erro);
            }
            finally
            {
                ConexaoSql.Close();
            }
        }

        private void ExecutaComando(string comandoSql)
        {
            SqlConnection ConexaoSql = new SqlConnection(connectionString);

            try
            {
                ConexaoSql.Open();
                SqlCommand cmd = new SqlCommand(comandoSql, ConexaoSql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro: " + erro);
            }
            finally
            {
                ConexaoSql.Close();
            }
        }

        private void ExecutaComando(string comandoSql, List<SqlParameter> parametros)
        {
            SqlConnection ConexaoSql = new SqlConnection(connectionString);

            try
            {
                ConexaoSql.Open();
                SqlCommand cmd = new SqlCommand(comandoSql, ConexaoSql);
                foreach (var parametro in parametros)
                {
                    cmd.Parameters.Add(parametro);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro: " + erro);
            }
            finally
            {
                ConexaoSql.Close();
            }
        }

        public DataTable Layouts()
        {
            return GeraLista("select cim_codigo, cim_descricao from conector_importacao where cim_tipo_origem = 'E'");
        }

        public DataTable ColunasLayout(int CodLayout)
        {
            return GeraLista("select null as lim_codigo,'' as lim_nome_coluna  union select lim_codigo, lim_nome_coluna from layout_importacao where cim_codigo = " + CodLayout);
        }

        public void InserirVinculos(DataTable vinculos, int CodLayout)
        {

            int Sequencia = (int)GeraLista("begin transaction update parametro set par_sequencia = isnull(par_sequencia,0)+1 where par_padrao = 1 select par_sequencia from parametro commit").Rows[0][0];

            foreach (DataRow linha in vinculos.Rows)
            {
                ExecutaComando("insert into aux_vinculo_coluna_importacao( sequencia, cim_codigo, lim_codigo, vci_nome_coluna_excel) values(" +
                    Sequencia + "," +
                    linha[0] + "," +
                    linha[1] + "," +
                    "'" + linha[2] + "')"
                );

            }

            ExecutaComando("exec pr_fazer_vinculos_importacao @sequencia="+Sequencia);
        }

        public string PosicaoVinculada(int CodLayout, string NomeColuna)
        {
            string resultado;

            try
            {
                resultado = (string)GeraLista("select lim_posicao from layout_importacao a join vinculo_coluna_importacao b on a.lim_codigo=b.lim_codigo where a.cim_codigo=" + CodLayout + " and vci_nome_coluna_excel='" + NomeColuna + "'").Rows[0][0];
            }
            catch (IndexOutOfRangeException)
            {

                resultado = null;
            }

            return resultado;
        }

        public int? CodPosicaoVinculada(int CodLayout, string NomeColuna)
        {
            int? resultado;

            try
            {
                resultado = (int)GeraLista("select a.lim_codigo from layout_importacao a join vinculo_coluna_importacao b on a.lim_codigo=b.lim_codigo where a.cim_codigo=" + CodLayout + " and vci_nome_coluna_excel='" + NomeColuna + "'").Rows[0][0];
            }
            catch (IndexOutOfRangeException)
            {

                resultado = null;
            }

            return resultado;
        }
    }
}
