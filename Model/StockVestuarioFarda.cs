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
        public Farda Farda { get; set; }
        public Serie Serie { get; set; }
        public NumeroVestuario NumeroVestuario { get; set; }
        public int Quantidade { get; set; }
        public int UltimaContagem { get; set; }
        public DateTime DataContagem { get; set; }

        public StockVestuarioFarda()
        {

        }
        public StockVestuarioFarda(int id)
        {
            this.ID = id;
        }
        public StockVestuarioFarda(Serie serie, Farda farda, NumeroVestuario numeroVestuario, int quantidade)
        {
            this.Serie = serie;
            this.Farda = farda;
            this.NumeroVestuario = numeroVestuario;
            this.Quantidade = quantidade;
        }
        public StockVestuarioFarda(int id, Serie serie, Farda farda, NumeroVestuario numeroVestuario, int quantidade)
            : this(serie, farda, numeroVestuario, quantidade)
        {
            this.ID = id;
        }
        public StockVestuarioFarda(Serie serie, Farda farda, NumeroVestuario numeroVestuario, int quantidade, int ultimaContagem, DateTime dataUltimaContagem)
         : this(serie, farda, numeroVestuario, quantidade)
        {
            this.UltimaContagem = ultimaContagem;
            this.DataContagem = dataUltimaContagem;
        }
        public StockVestuarioFarda(int id, Serie serie, Farda farda, NumeroVestuario numeroVestuario, int quantidade, int ultimaContagem, DateTime dataUltimaContagem)
            : this(serie, farda, numeroVestuario, quantidade, ultimaContagem, dataUltimaContagem)
        {
            this.ID = id;
        }
    }
}
