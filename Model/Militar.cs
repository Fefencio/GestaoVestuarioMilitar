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
        public string Email { get; set; }
        public string Morada { get; set; }
        public bool Estado { get; set; }

        public Militar()
        {

        }
        public Militar(string nome, DateTime dataNascimento, string bi, string telefone, string email, string morada, bool estado)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.BI = bi;
            this.Telefone = telefone;
            this.Email = email;
            this.Morada = morada;
            this.Estado = estado;
        }
        public Militar(int id, string nome, DateTime dataNascimento, string bi, string telefone, string email, string morada, bool estado)
        {
            this.ID = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.BI = bi;
            this.Telefone = telefone;
            this.Email = email;
            this.Morada = morada;
            this.Estado = estado;
        }
    }
}
