using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovimentoStock
    {
        public int ID { get; set; }
        public StockVestuarioFarda StockVestuarioFarda { get; set; }
        public EnumList.TipoMovimento TipoMovimento { get; set; }
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public Militar Militar { get; set; }
        public DateTime DataMovimento { get; set; }

        public MovimentoStock()
        {

        }
        public MovimentoStock(StockVestuarioFarda stockVestuarioFarda, EnumList.TipoMovimento tipoMovimento, double quantidade, string descricao, DateTime dataMovimento, Militar militar)
        {
            this.StockVestuarioFarda = stockVestuarioFarda;
            this.TipoMovimento = tipoMovimento;
            this.Quantidade = quantidade;
            this.Descricao = descricao;
            this.DataMovimento = dataMovimento;
            this.Militar = militar;
        }
        public MovimentoStock(int id, StockVestuarioFarda stockVestuarioFarda, EnumList.TipoMovimento tipoMovimento, double quantidade, 
            string descricao,DateTime dataMovimento, Militar militar)
            : this(stockVestuarioFarda, tipoMovimento, quantidade, descricao, dataMovimento, militar)
        {
            this.ID = id;
        }
    }
}
