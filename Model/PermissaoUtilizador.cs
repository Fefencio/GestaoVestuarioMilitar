using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermissaoUtilizador
    {
        public int ID { get; set; }
        public int IdPermissao { get; set; }
        public int IdUtilizador { get; set; }

        public PermissaoUtilizador()
        {

        }
        public PermissaoUtilizador(int id, int idPermissao, int idUtilizador)
        {
            this.ID = id;
            this.IdPermissao = idPermissao;
            this.IdUtilizador = idUtilizador;
        }
    }
}
