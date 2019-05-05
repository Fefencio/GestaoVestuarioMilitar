using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Utilizador
    {
        public int ID { get; set; }
        public int IdMilitar { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int IdNivel { get; set; }

        public Militar Militar { get; set; }

        public Utilizador()
        {

        }
        public Utilizador(int id, int idMilitar,  string usuario, string senha, int idNivel)
        {
            this.ID = id;
            this.IdMilitar = idMilitar;
            this.Usuario = usuario;
            this.Senha = senha;
            this.IdNivel = idNivel;
        }

        public Utilizador(int id, int idMilitar, string usuario, string senha, int idNivel, Militar militar)
        {
            this.ID = id;
            this.IdMilitar = idMilitar;
            this.Usuario = usuario;
            this.Senha = senha;
            this.IdNivel = idNivel;
            this.Militar = militar;
        }
    }
}
