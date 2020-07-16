using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Vencimentos_GM
{
    public class Conexao
    {
        public String enderecocon;
        public String enderecoconpost;
        public string enderecoconpedido;
        public String servidor_fotos;
        public String servidor_principal_modelo;
        public String banco_rnc;
        public String banco_backup;
        public String banco_planejamento;

        public Conexao()
        {
            //   enderecocon = "server=192.168.1.199; port=3306;User Id=root;database=usinagem; password=root;convert zero datetime=True";
            //   servidor_principal_modelo = "server=192.168.1.199; port=3306;User Id=root;database=banco; password=root;convert zero datetime=True";
            //   enderecocon = "server=191.252.220.230; port=3306;User Id=root;database=usinagem; password=g5a7b9t3;convert zero datetime=True";
            //  enderecocon = "server=192.168.2.48; port=3306;User Id=root;database=usinagem; password=root;convert zero datetime=True";

            banco_rnc = "server=192.168.2.12; port=3306;User Id=root;database=backcharge; password=root;convert zero datetime=True";
            enderecocon = "server=192.168.2.12; port=3306;User Id=root;database=usinagem; password=root;convert zero datetime=True";
            enderecoconpost = "server=192.168.2.2; port=5432;Username=adriano;database=gmetal; password=Etf8gX;";
            servidor_fotos = "server=fotos_gm.mysql.dbaas.com.br; port=3306;User Id=fotos_gm;database=fotos_gm; password=g5a7b9t3;convert zero datetime=True";
            servidor_principal_modelo = "server=192.168.2.12; port=3306;User Id=root;database=banco; password=root;convert zero datetime=True";
            banco_backup = "server=192.168.2.12; port=3306;User Id=root;database=backups; password=root;convert zero datetime=True";
            banco_planejamento = "server=192.168.2.12; port=3306;User Id=root;database=planejamento_cargas; password=root;convert zero datetime=True";

        }
    }
}
