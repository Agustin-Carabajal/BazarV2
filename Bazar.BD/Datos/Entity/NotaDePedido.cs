using Bazar.shared.ENUM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    [Index(nameof(CodNotaPedido), Name = "NotaDePedido_CodNotaPedido_UQ", IsUnique = true)]
    public class NotaDePedido : EntityBase
    {
        [Required(ErrorMessage = "El Código es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El Código no puede exceder los 20 caracteres.")]
        public required string CodNotaPedido { get; set; }

        [Required(ErrorMessage = "La Fecha es obligatoria.")]
        public required DateTime FechaNotaPedido { get; set; }

        [Required(ErrorMessage = "El Tipo del usuario es obligatorio.")]
        public required TipoNotaPedido TipoNotaPedido { get; set; }

        [Required(ErrorMessage = "El Id de Usuario es obligatorio.")]
        public required int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "El Id de Proveedor es obligatorio.")]
        public required int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}
