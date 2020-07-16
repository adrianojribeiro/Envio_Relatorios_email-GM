using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vencimentos_GM
{
    public class Exportacao
    {

        Conexao conecta = new Conexao();

        public DataTable Faturas_Aberto()
        {
            DataTable tabela = new DataTable();

            string data_inicial = Convert.ToDateTime("01/01/2010").ToString("yyyy/MM/dd",null);
            string data_atual = Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd",null);

            string sql = "SELECT nro_invoice AS Invoice,SUM(preco_total_item) AS Valor,data_embarque AS Embarque,vencimento_invoice AS Vencimento FROM invoice_itens WHERE DATE(vencimento_invoice) between '"+data_inicial+"' and '"+ data_atual + "' and pagamento_item = 0 GROUP BY nro_invoice ";
            
           
            using (MySqlConnection con = new MySqlConnection(conecta.enderecocon))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            tabela.Load(reader);              
                        }
                    }
                }
            }
            return tabela;
        }
    }
}
