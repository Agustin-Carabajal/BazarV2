using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.DTO
{
    public class VentaResumenDTO
    {
        //public int Id { get; set; }
        //public string CodVenta { get; set; } = "";
        //public DateTime FechaVenta { get; set; }
        //public decimal MontoTotal { get; set; }
        //public string DniUsuario { get; set; } = "";
        //public List<ArticuloListadoDTO> ArticulosVendidos { get; set; } = new();

        public DateTime Fecha { get; set; }
        public List<string> LineasResumen { get; set; } = new();
        public decimal TotalDia { get; set; }
    }
}
