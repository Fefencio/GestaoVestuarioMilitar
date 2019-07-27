using DAL;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NVestuario
    {
        DVestuario DVestuario = new DVestuario();
        public string Insert(Vestuario vestuario)
        {
            return DVestuario.Insert(vestuario);
        }
        public string Update(Vestuario vestuario)
        {
            return DVestuario.Update(vestuario);
        }
        public string Delete(Vestuario vestuario)
        {
            return DVestuario.Delete(vestuario);
        }
        public DataTable Select(Vestuario vestuario)
        {
            return DVestuario.Select(vestuario);
        }
        public Vestuario SelectID(Vestuario vestuario)
        {
            return DVestuario.SelectID(vestuario);
        }
        public Dictionary<string, int> ListarNomeID()
        {
            return DVestuario.ListarNomeID();
        }
        public Dictionary<string, int> ListarNumerosNomeID(Vestuario vestuario)
        {
            return DVestuario.ListarNumerosNomeID(vestuario);
        }
    }
}
