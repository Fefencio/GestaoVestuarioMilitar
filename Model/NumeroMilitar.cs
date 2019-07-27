using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NumeroMilitar
    {
        public int ID { get; set; }
        public Militar Militar { get; set; }
        public NumeroVestuario NumeroVestuario { get; set; }
        public Farda Farda { get; set; }

        public NumeroMilitar()
        {

        }
        public NumeroMilitar(int id)
        {
            this.ID = id;
        }
        public NumeroMilitar(Militar militar, NumeroVestuario numeroVestuario, Farda farda)
        {
            this.Militar = militar;
            this.NumeroVestuario = numeroVestuario;
            this.Farda = farda;
        }
        public NumeroMilitar(int id, Militar militar, NumeroVestuario numeroVestuario, Farda farda)
            : this(militar, numeroVestuario, farda)
        {
            this.ID = ID;
        }
    }
}
