using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    
    public class Proveedor : EntityBase
    {
        [Required(ErrorMessage = "El Código es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe tener 11 caracteres.")]
        public required string CUITProveedor { get; set; }
        [Required(ErrorMessage = "El Nombre del proveedor es obligatorio.")]
        public required string NombreProveedor { get; set; } 
        [Required(ErrorMessage = "El Teléfono del proveedor es obligatorio.")]
        public required string TelefonoProveedor { get; set; }
        [Required(ErrorMessage = "La Dirección del proveedor es obligatoria.")]
        public required string DireccionProveedor { get; set; }

        public string ContactoProveedor { get; set; } = string.Empty;
    }
}
