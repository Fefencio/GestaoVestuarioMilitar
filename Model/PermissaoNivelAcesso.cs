using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermissaoNivelAcesso
    {
        public int ID { get; set; }
        public int IdPermissao { get; set; }
        public int IdNivel { get; set; }

        public PermissaoNivelAcesso()
        {

        }
        public PermissaoNivelAcesso(int id, int idPermissao, int idNivel)
        {
            this.ID = id;
            this.IdPermissao = idPermissao;
            this.IdNivel = idNivel;
        }
    }
}
