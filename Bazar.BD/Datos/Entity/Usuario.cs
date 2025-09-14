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
    [Index(nameof(DniUsuario), IsUnique = true, Name = "Usuario_DniUsuario_UQ")]
    public class Usuario : EntityBase
    {  

        [Required(ErrorMessage = "El DNI del usuario es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El DNI no puede exceder los 20 caracteres.")]
        public required string DniUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Nombre del usuario es obligatorio.")]
        public required string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Apellido del usuario es obligatorio.")] 
        public required string ApellidoUsuario { get; set; }
        public string TelefonoUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Tipo del usuario es obligatorio.")]
        public required TipoUsuario UsuarioTipo { get; set; }

        [Required(ErrorMessage = "El nombre del Perfil del usuario es obligatorio.")]
        public required string PerfilUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Contraseña es obligatorio.")]
        public required string ContraseniaUsuario { get; set; } = string.Empty;
    }
}
