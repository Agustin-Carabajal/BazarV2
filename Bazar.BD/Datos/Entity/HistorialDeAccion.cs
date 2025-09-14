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
    [Index(nameof(CodAccion), Name = "HistorialDeAccion_CodAccion_UQ", IsUnique = true)]
    public class HistorialDeAccion : EntityBase
    {
        [Required(ErrorMessage = "El Codigo es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El Código no puede exceder los 20 caracteres.")]
        public required int CodAccion { get; set; }

        [Required(ErrorMessage = "El Tipo de Acción es obligatorio.")]
        public required TipoAccion TipoAccion { get; set; }

        [Required(ErrorMessage = "El Id de Usuario es obligatorio.")]
        public required int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        [Required(ErrorMessage = "El Id de Artículo es obligatorio.")]
        public required int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }
    }
}
