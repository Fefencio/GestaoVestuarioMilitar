using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VestuarioDistribuicao
    {
        public int ID { get; set; }
        public int IdDistribuicaoFarda { get; set; }
        public int IdVestuario { get; set; }
        public double Quantidade { get; set; }
        public string Numero { get; set; }
        public DateTime DataDistribuicao { get; set; }
        public int IdMilitarBeneficiado { get; set; }
        public int IdMilitarResponsavel { get; set; }

        public VestuarioDistribuicao()
        {

        }
        public VestuarioDistribuicao(int id, int idDistribuicaiFarda, int idVestuario, double quantidade,
           string numero, DateTime dataDistribuicao, int idMilitarBeneficiado, int idMilitarResponsavel)
        {
            this.ID = id;
            this.IdDistribuicaoFarda = idDistribuicaiFarda;
            this.IdVestuario = idVestuario;
            this.Quantidade = quantidade;
            this.Numero = numero;
            this.DataDistribuicao = dataDistribuicao;
            this.IdMilitarBeneficiado = idMilitarBeneficiado;
            this.IdMilitarResponsavel = idMilitarResponsavel;
        }
    }
}
