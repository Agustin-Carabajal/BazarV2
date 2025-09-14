using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    [Index(nameof(CodVenta), Name = "Venta_CodVenta_UQ", IsUnique = true)]
    public class Venta : EntityBase
    {
        [Required(ErrorMessage = "El Codigo es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El Código no puede exceder los 20 caracteres.")]
        public required string CodVenta { get; set; } = "";

        [Required(ErrorMessage = "La fecha de venta es obligatoria.")]
        public required DateTime FechaVenta { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        public required decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "El Id de Usuario es obligatorio.")]
        public required int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
