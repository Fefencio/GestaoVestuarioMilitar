using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ecomenda
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataChegada { get; set; }
        public Militar Militar { get; set; }
        public EnumList.AbertoFechadoCancelado Estado { get; set; }

        public List<EcomendaItens> EcomendaItens { get; set; }

        public Ecomenda()
        {

        }
        public Ecomenda(int id)
        {
            this.ID = id;
        }
        public Ecomenda(string codigo, string descricao, DateTime datacriacao, DateTime datachegada, 
            Militar militar, List<EcomendaItens> ecomendaItens, EnumList.AbertoFechadoCancelado estado)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.DataCriacao = datacriacao;
            this.DataChegada = datachegada;
            this.Militar = militar;
            this.EcomendaItens = ecomendaItens;
            this.Estado = estado;
        }
        public Ecomenda(int id, string codigo, string descricao, DateTime datacriacao,
            DateTime datachegada, Militar militar, List<EcomendaItens> ecomendaItens, EnumList.AbertoFechadoCancelado estado)
            : this(codigo, descricao, datacriacao, datachegada, militar, ecomendaItens, estado)
        {
            this.ID = id;
        }

    }
}
