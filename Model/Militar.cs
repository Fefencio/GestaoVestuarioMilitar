using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Militar
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime  DataNascimento { get; set; }
        public string BI { get; set; }
        public string Telefone { get; set; }
        public string Morada { get; set; }

        public Militar()
        {

        }
        public Militar(int id, string nome, DateTime dataNascimento, string bi, string telefone, string morada)
        {
            this.ID = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.BI = bi;
            this.Telefone = telefone;
            this.Morada = morada;
        }
    }
}
