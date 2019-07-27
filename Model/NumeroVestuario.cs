using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NumeroVestuario
    {
        public int ID { get; set; }
        public Vestuario Vestuario { get; set; }
        public string Numero { get; set; }

        public NumeroVestuario()
        {

        }
        public NumeroVestuario(int id)
        {
            this.ID = id;
        }
        public NumeroVestuario(string numero)
        {
            this.Numero = numero;
        }
        public NumeroVestuario(int id, string numero)
        {
            this.ID = id;
            this.Numero = numero;
        }
        public NumeroVestuario(string numero, Vestuario vestuario)
        {
            this.Vestuario = vestuario;
            this.Numero = numero;
        }
        public NumeroVestuario(int id, Vestuario vestuario, string numero) : this(numero, vestuario)
        {
            this.ID = id;
        }
    }
}
