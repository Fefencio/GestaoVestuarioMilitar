using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Farda
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Vestuario> Vestuarios { get; set; }

        public Farda()
        {

        }
        public Farda(int id)
        {
            this.ID = id;
        }
        public Farda(string nome, string descricao, List<Vestuario> vestuarios)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Vestuarios = vestuarios;
        }
        public Farda(int id, string nome, string descricao, List<Vestuario> vestuarios)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Vestuarios = vestuarios;
        }
    }
}
