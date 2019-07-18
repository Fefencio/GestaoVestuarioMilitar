using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Unidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contacto> Contactos { get; set; }

        public Unidade()
        {

        }
        public Unidade(string nome)
        {
            this.Nome = nome;
        }
    }
}
