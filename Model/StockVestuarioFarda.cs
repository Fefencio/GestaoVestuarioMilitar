using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StockVestuarioFarda
    {
        public int ID { get; set; }
        public int IdVestuarioFardaNumeroVestuario { get; set; }
        public double Quantidade { get; set; }
        public double UltimaContagem { get; set; }
        public DateTime DataContagem { get; set; }

        public StockVestuarioFarda()
        {

        }
        public StockVestuarioFarda(int id, int idVestuarioFardaNumeroVestuario, double quantidade, double ultimaContagem, DateTime dataContagem)
        {
            this.ID = id;
            this.IdVestuarioFardaNumeroVestuario = idVestuarioFardaNumeroVestuario;
            this.Quantidade = quantidade;
            this.UltimaContagem = ultimaContagem;
            this.DataContagem = dataContagem;
        }
    }
}
