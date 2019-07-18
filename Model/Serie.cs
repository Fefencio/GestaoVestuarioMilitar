using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Serie
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Estado { get; set; }

        public Serie()
        {

        }
        public Serie(int id)
        {
            this.ID = id;
        }
        public Serie(string nome, string descricao, DateTime dataCriacao, DateTime dataInicial, 
            DateTime dataValidade, bool estado)
        {
            
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataCriacao = dataCriacao;
            this.DataInicial = dataInicial;
            this.DataValidade = dataValidade;
            this.Estado = estado;
        }
        public Serie(int id, string nome, string descricao, DateTime dataCriacao, DateTime dataInicial,
            DateTime dataValidade, bool estado)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataCriacao = dataCriacao;
            this.DataInicial = dataInicial;
            this.DataValidade = dataValidade;
            this.Estado = estado;
        }
    }
}
