using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EnumList
    {
        public enum AbertoFechadoCancelado
        {
            Aberto,
            Fechado,
            Cancelado
        };
        public enum TipoMovimento
        {
            Entrada,
            Saida
        };
    }
}
