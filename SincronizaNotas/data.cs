using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;



namespace SincronizaNotas
{
    class data
    {
        public void verificaPDF(FbConnection conexao, string pdf, string caminhoPdf)
        {

            try
            {
                string query = "select a.vendedor, a.dataefe from tvenpedido a where a.numerodunfe = @chave";
                FbCommand cmd = new FbCommand(query, conexao);
                cmd.Parameters.AddWithValue("@chave", pdf.Substring(0, 44));
                FbDataReader reader = cmd.ExecuteReader();
                string[] dataVenda = new string[2];
                while (reader.Read())
                {
                    dataVenda[0] = reader["vendedor"].ToString();
                    dataVenda[1] = reader["dataefe"].ToString();
                }

                string vendedor = dataVenda[0];
                string mesPasta = Convert.ToDateTime(dataVenda[1]).ToString("MM");
                string anoPasta = Convert.ToDateTime(dataVenda[1]).ToString("yyyy");
                string dirDestino =Properties.Settings.Default.dirDestino;
                string dirOrigem = Properties.Settings.Default.dirOrigem;
                string dirDestinoFinal = dirDestino + @"\"+ vendedor + @"\" + anoPasta + @"\" + mesPasta;

                if (string.IsNullOrWhiteSpace(vendedor))
                {
                    return;
                }
                if (File.Exists(Path.Combine(dirDestinoFinal, pdf)))
                {
                    return;
                }
                if (!Directory.Exists(dirDestinoFinal))
                {
                    Directory.CreateDirectory(dirDestinoFinal);
                }

                File.Copy(caminhoPdf, Path.Combine(dirDestinoFinal, pdf));

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
