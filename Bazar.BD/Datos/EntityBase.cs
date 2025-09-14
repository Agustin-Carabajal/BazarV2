using Bazar.shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public EstadoRegistro EstadoRegistro { get; set; }
        public string Observacion { get; set; } = "";
    }
}
