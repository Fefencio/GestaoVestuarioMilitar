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
    public class NSerie
    {
        DSerie DSerie = new DSerie(); 
        public string Insert(Serie serie)
        {
            return DSerie.Insert(serie);
        }
        public string Update(Serie serie)
        {
            return DSerie.Update(serie);
        }
        public string Delete(Serie serie)
        {
            return DSerie.Delete(serie);
        }
        public DataTable Select(Serie serie)
        {
            return DSerie.Select(serie);
        }
    }

}
