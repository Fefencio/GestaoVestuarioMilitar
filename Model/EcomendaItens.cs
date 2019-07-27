using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EcomendaItens
    {
        public int ID { get; set; }
        public Farda Farda { get; set; }
        public Serie Serie { get; set; }
        public NumeroVestuario NumeroVestuario { get; set; }
        public int Quantidade { get; set; }
        public Ecomenda Ecomenda { get; set; }

        public EcomendaItens()
        {

        }
        public EcomendaItens(Farda farda, Serie serie, NumeroVestuario numeroVestuario, int quantidade)
        {
            this.Farda = farda;
            this.Serie = serie;
            this.NumeroVestuario = numeroVestuario;
            this.Quantidade = quantidade;
        }
        public EcomendaItens(Farda farda, Serie serie, NumeroVestuario numeroVestuario, int quantidade, Ecomenda ecomenda)
        {
            this.Farda = farda;
            this.Serie = serie;
            this.NumeroVestuario = numeroVestuario;
            this.Quantidade = quantidade;
            this.Ecomenda = ecomenda;
        }
        public EcomendaItens(int id, Farda farda, Serie serie, NumeroVestuario numeroVestuario, int quantidade, Ecomenda ecomenda)
            : this(farda, serie, numeroVestuario, quantidade, ecomenda)
        {
            this.ID = id;
        }
    }
}
