using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    [Index(nameof(CodVentaArticulo), Name = "VentaArticulo_CodVentaArticulo_UQ", IsUnique = true)]
    public class VentaArticulo : EntityBase
    {
        [Required(ErrorMessage = "El Id de Articulo es obligatorio.")]
        public required int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }

        [Required(ErrorMessage = "El Id de Venta es obligatorio.")]
        public required int VentaId { get; set; }
        public Venta? Venta { get; set; }

        
        [Required(ErrorMessage = "El Código es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El Código no puede exceder los 20 caracteres.")]
        public required string CodVentaArticulo { get; set; }
        [Required(ErrorMessage = "La Cantidad  es obligatoria.")]
        public required int CantidadArt { get; set; }
        [Required(ErrorMessage = "El Precio es obligatorio.")]
        public required decimal PrecioUnitarioArt { get; set; }

        [Required(ErrorMessage = "El Subtotal es obligatorio.")]
        public required decimal SubtotalArt { get; set; }
    }
}
