using Bazar.shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.DTO
{
    public class UsuarioMostrarDTO
    {
        public int Id { get; set; }
        public string Dni { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public TipoUsuario tipoUsuario { get; set; }

    }
}
