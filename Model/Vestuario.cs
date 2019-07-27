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
        public List<NumeroVestuario> Numeros { get; set; }

        public Vestuario()
        {

        }
        public Vestuario(int id)
        {
            this.ID = id;
        }
        public Vestuario(int id, string nome)
        {
            this.ID = id;
            this.Nome = nome;
        }
        public Vestuario(int id, string nome, string descricao, List<NumeroVestuario> numeros)
            : this(nome, descricao, numeros)
        {
            this.ID = id;
        }

        public Vestuario(string nome, string descricao, List<NumeroVestuario> numeros)
        {
            Nome = nome;
            Descricao = descricao;
            this.Numeros = numeros;
        }
    }
}
