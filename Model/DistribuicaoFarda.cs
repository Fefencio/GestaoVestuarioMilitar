using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DistribuicaoFarda
    {
        public int ID { get; set; }
        public int IdFarda { get; set; }
        public int IdMilitarResponsavel { get; set; }
        public DateTime DataDistribuicao { get; set; }

        public DistribuicaoFarda()
        {
            this.DataDistribuicao = DateTime.Now;
        }
        public DistribuicaoFarda(int id, int idFarda, int idMilitarResponsavel, DateTime dataDistribuicao)
        {
            this.ID = id;
            this.IdFarda = idFarda;
            this.IdMilitarResponsavel = idMilitarResponsavel;
            this.DataDistribuicao = dataDistribuicao;
        }
        public DistribuicaoFarda(int idFarda, int idMilitarResponsavel)
        {
            this.IdFarda = idFarda;
            this.IdMilitarResponsavel = idMilitarResponsavel;
            this.DataDistribuicao = DateTime.Now;
        }
    }
}
