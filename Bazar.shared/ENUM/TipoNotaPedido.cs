using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.ENUM
{
    public enum TipoNotaPedido
    {
        NoEnviada = 1, // Nota de Pedido no enviada
        Pendiente = 2, // Nota de Pedido pendiente
        Completada = 3, // Nota de Pedido completada
        Cancelada = 4 // Nota de Pedido cancelada
    }
}
