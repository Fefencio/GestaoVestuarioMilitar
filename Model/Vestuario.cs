using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vestuario
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Vestuario()
        {

        }
        public Vestuario(int id)
        {
            this.ID = id;
        }
        public Vestuario(int id, string nome, string descricao)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public Vestuario(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
