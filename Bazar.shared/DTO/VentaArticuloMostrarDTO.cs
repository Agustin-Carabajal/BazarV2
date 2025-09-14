using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.DTO
{
    public class VentaArticuloMostrarDTO
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public string CodVenta { get; set; } = "";
        public string VentaArticuloCod { get; set; } = "";
        public string ArticuloCod { get; set; } = "";
        public string ArticuloNombre { get; set; } = "";
        public int CantidadArt { get; set; }
        public decimal PrecioUnitarioArt { get; set; }
        public decimal SubtotalArt { get; set; }
    }
}
