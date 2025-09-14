using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.DTO
{
    public class ArticuloListadoDTO
    {
        public int Id { get; set; }
        public string Articulo { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
