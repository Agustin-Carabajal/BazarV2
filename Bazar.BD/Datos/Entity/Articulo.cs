using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    [Index(nameof(CodigoBarras), Name = "Articulo_CodigoBarras_UQ", IsUnique = true)]
    public class Articulo : EntityBase
    {
        [Required(ErrorMessage = "El Código de Barras es obligatorio.")]
        [StringLength(13, MinimumLength = 13,ErrorMessage = "El Código de Barras debe ser de 13 caracteres.")]
        public required string CodigoBarras { get; set; }

        [Required(ErrorMessage = "Una Descripción del artículo es obligatoria.")]
        public required string DescripcionArticulo { get; set; } = string.Empty;    
        public string MarcaArticulo { get; set; } = "";

        [Required(ErrorMessage = "El Stock es obligatorio.")]
        public required int StockArticulo { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio.")]
        public required decimal PrecioArticulo { get; set; }

        [Required(ErrorMessage = "El Id del Proveedor es obligatorio.")]
        public required int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }


    }
    
}
