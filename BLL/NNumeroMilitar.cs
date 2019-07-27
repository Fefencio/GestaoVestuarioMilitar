using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NNumeroMilitar
    {
        DNumeroMilitar DNumeroMilitar = new DNumeroMilitar();
        public string Insert(NumeroMilitar numeroMilitar)
        {
            return DNumeroMilitar.Insert(numeroMilitar);
        }
        public string Update(NumeroMilitar numeroMilitar)
        {
            return DNumeroMilitar.Update(numeroMilitar);

        }
        public string Delete(NumeroMilitar numeroMilitar)
        {
            return DNumeroMilitar.Delete(numeroMilitar);
        }
        public List<NumeroMilitar> Select()
        {
            return DNumeroMilitar.Select();
        }
    }
}
