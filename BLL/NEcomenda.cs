using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NEcomenda
    {
        DEcomenda DEcomenda = new DEcomenda();
        public string Insert(Ecomenda ecomenda)
        {
            return DEcomenda.Insert(ecomenda);
        }
        public string Update(Ecomenda ecomenda)
        {
            return DEcomenda.Update(ecomenda);
        }
        public string Delete(Ecomenda ecomenda)
        {
            return DEcomenda.Delete(ecomenda);
        }
        public DataTable Select(Ecomenda ecomenda)
        {
            return DEcomenda.Select(ecomenda);
        }
        public Dictionary<string, int> ListarCodigoID()
        {
            return DEcomenda.ListarCodigoID();
        }
        public List<EcomendaItens> SelectTotalEncomendar(EcomendaItens ecomendaItens)
        {
            return DEcomenda.SelectTotalEncomendar(ecomendaItens);
        }
        public List<EcomendaItens> SelectItemsEncomenda(Ecomenda ecomenda)
        {
            return DEcomenda.SelectItemsEncomenda(ecomenda);
        }
    }
}
