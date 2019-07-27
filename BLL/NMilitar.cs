using DAL;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NMilitar
    {
        DMilitar DMilitar = new DMilitar();
        public string Insert(Militar militar)
        {
            return DMilitar.Insert(militar);
        }
        public string InsertNumero(NumeroMilitar numeroMilitar)
        {
            return DMilitar.InsertNumero(numeroMilitar);
        }
        public string Update(Militar militar)
        {
            return DMilitar.Update(militar);
        }
        public string Delete(Militar militar)
        {
            return DMilitar.Delete(militar);
        }
        public DataTable Select(Militar militar)
        {
            return DMilitar.Select(militar);
        }
        public Dictionary<string, int> ListarNomeID()
        {
            return DMilitar.ListarNomeID();
        }
        public List<NumeroMilitar> ListarNumeroMilitar(Militar militar)
        {
            return DMilitar.ListarNumeroMilitar(militar);
        }
    }
}
