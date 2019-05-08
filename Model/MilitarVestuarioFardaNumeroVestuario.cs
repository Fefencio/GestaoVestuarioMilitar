using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MilitarVestuarioFardaNumeroVestuario
    {
        public int ID { get; set; }
        public int IdMilitar { get; set; }
        public int IdVestuarioFardaNumeroVestuario { get; set; }

        public MilitarVestuarioFardaNumeroVestuario()
        {

        }

        public MilitarVestuarioFardaNumeroVestuario(int id, int idMilitar, int idVestuarioFardaNumeroVestuario)
        {
            this.ID = ID;
            this.IdMilitar = idMilitar;
            this.IdVestuarioFardaNumeroVestuario = idVestuarioFardaNumeroVestuario;
        }
    }
}
