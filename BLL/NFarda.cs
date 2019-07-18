using DAL;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NFarda
    {
        DFarda DFarda = new DFarda();
        public string Insert(Farda farda)
        {
            return DFarda.Insert(farda);
        }
        public string Update(Farda farda)
        {
            return DFarda.Update(farda);
        }
        public string Delete(Farda farda)
        {
            return DFarda.Delete(farda);
        }
        public DataTable Select(Farda farda)
        {
            return DFarda.Select(farda);
        }
        public Dictionary<string, int> ListarNomeID()
        {
            return DFarda.ListarNomeID();
        }
    }
}
