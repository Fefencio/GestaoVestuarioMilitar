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
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public NumeroVestuario()
        {

        }
        public NumeroVestuario(int id, string numero, string descricao)
        {
            this.ID = id;
            this.Numero = numero;
            this.Descricao = descricao;
        }
    }
}
