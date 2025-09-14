using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.shared.ENUM
{
    public enum TipoAccion
    {
        CargarArticulo = 1, // Cargar Artículo
        ModificarPrecioArticulo = 2, // Modificar Artículo
        ModificarStockArticulo = 3, // Modificar Stock del Artículo
        EliminarArticulo = 4, // Eliminar Artículo
        ModificarDescripcionArticulo = 5, // Modificar Descripción del Artículo
    }
}
