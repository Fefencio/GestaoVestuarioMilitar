using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Permissao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Permissao()
        {

        }
        public Permissao(int id, string nome, string descricao)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}
