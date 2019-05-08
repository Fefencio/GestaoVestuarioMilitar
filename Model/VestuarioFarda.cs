using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VestuarioFarda
    {
        public int ID { get; set; }
        public int IdVestuario { get; set; }
        public int IdFarda { get; set; }

        public VestuarioFarda()
        {

        }
        public VestuarioFarda(int id, int idVestuario, int idFarda)
        {
            this.ID = id;
            this.IdVestuario = idVestuario;
            this.IdFarda = idFarda;
        }
    }
}
