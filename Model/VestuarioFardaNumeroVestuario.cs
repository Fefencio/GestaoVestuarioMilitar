using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VestuarioFardaNumeroVestuario
    {
        public int ID { get; set; }
        public int IdVestuarioFarda { get; set; }
        public int IdNumeroVestuario { get; set; }

        public VestuarioFardaNumeroVestuario()
        {

        }
        public VestuarioFardaNumeroVestuario(int id, int idVestuarioFarda, int idNumeroVestuario)
        {
            this.ID = id;
            this.IdVestuarioFarda = idVestuarioFarda;
            this.IdNumeroVestuario = idNumeroVestuario;
        }
    }
}
