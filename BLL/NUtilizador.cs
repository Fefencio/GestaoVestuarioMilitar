using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NUtilizador
    {
        DUtilizador DUtilizador = new DUtilizador();
        public Militar Login(Utilizador utilizador)
        {
            return DUtilizador.Login(utilizador);
        }
    }
}
