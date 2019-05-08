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
        public int IdStockVestuarioFarda { get; set; }
        public string TipoMovimento { get; set; }
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public int IdMilitar { get; set; }

        public MovimentoStock()
        {

        }

        public MovimentoStock(int id, int idStockVestuarioFarda, string tipoMovimento, double quantidade, string descricao, int idMilitar)
        {
            this.ID = id;
            this.IdStockVestuarioFarda = idStockVestuarioFarda;
            this.TipoMovimento = tipoMovimento;
            this.Quantidade = quantidade;
            this.Descricao = descricao;
            this.IdMilitar = idMilitar;
        }
    }
}
