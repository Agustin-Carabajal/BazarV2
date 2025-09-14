using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.DTO
{
    public class ArticuloDTO
    {
        [Required(ErrorMessage = "El Código de Barras es obligatorio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El Código de Barras debe ser de 13 caracteres.")]
        public string CodigoBarras { get; set; } = "";

        [Required(ErrorMessage = "Una Descripción del artículo es obligatoria.")]
        public string DescripcionArticulo { get; set; } = string.Empty;
        public string MarcaArticulo { get; set; } = "";

        [Required(ErrorMessage = "El Stock es obligatorio.")]
        public int StockArticulo { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio.")]
        public decimal PrecioArticulo { get; set; }

        [Required(ErrorMessage = "El Id del Proveedor es obligatorio.")]
        public int ProveedorId { get; set; }
    }
}
