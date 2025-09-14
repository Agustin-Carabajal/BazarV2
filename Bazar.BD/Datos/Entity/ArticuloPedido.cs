using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos.Entity
{
    [Index(nameof(CodArtPedido), IsUnique = true, Name = "ArticuloPedido_CodArtPedido_UQ")]
    public class ArticuloPedido : EntityBase
    {
        [Required(ErrorMessage = "El Id del Artículo es obligatorio.")]
        public required int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }

        [Required(ErrorMessage = "El Id de la Nota de Pedido es obligatorio.")]
        public required int NotaDePedidoId { get; set; }
        public NotaDePedido? NotaDePedido { get; set; }

        [Required(ErrorMessage = "El Código es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El Código no puede exceder los 20 caracteres.")]
        public required string CodArtPedido { get; set; }

        [Required(ErrorMessage = "La Cantidad Pedida es obligatoria.")]
        public required int CantidadPedido { get; set; }
        [Required(ErrorMessage = "La Cantidad Recibida es obligatoria.")]
        public required int CantidadRecibida { get; set; }
    }
}
