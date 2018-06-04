using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FormataLayoutExcel
{
    static class Configuracao
    {
        
        public static void GerarConfiguracao(string Servidor, string BD)
        {
            // Pasta aonde está o arquivo + nome do arquivo a ser gerado.
            string arquivo = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + Path.DirectorySeparatorChar + "conexao.xml";

            // Criação do Xml com os dados
            XmlDocument xml = new XmlDocument();
            XmlDeclaration declaracaoXml = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement noRaiz = xml.CreateElement("Configuracao");
            xml.InsertBefore(declaracaoXml, xml.DocumentElement);
            xml.AppendChild(noRaiz);
            
            XmlElement noPai = xml.CreateElement("Servidor");
            xml.DocumentElement.PrependChild(noPai);

            XmlElement endereco= xml.CreateElement("Endereco");
            XmlElement database  = xml.CreateElement("Database");

            // Inserir Texto
            XmlText enderecoText = xml.CreateTextNode(Servidor);
            XmlText databaseText= xml.CreateTextNode(BD);
            
            // append the nodes to the parentNode without the value
            noPai.AppendChild(endereco);
            noPai.AppendChild(database);

            // save the value of the fields into the nodes
            endereco.AppendChild(enderecoText);
            database.AppendChild(databaseText);

            // Save to the XML file
            xml.Save(arquivo.Substring(6,arquivo.Length - 6));
        }

        public static void LerConfiguracao(out string Servidor, out string BD)
        {
            string arquivo = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + Path.DirectorySeparatorChar + "conexao.xml";
            arquivo = arquivo.Substring(6, arquivo.Length - 6);
            if (!File.Exists(arquivo))
            {
                Servidor = String.Empty;
                BD = String.Empty;
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(arquivo);
                Servidor = xml.SelectSingleNode("/Configuracao/Servidor/Endereco").InnerText;
                BD = xml.SelectSingleNode("/Configuracao/Servidor/Database").InnerText;
            }
        }

    }
}
