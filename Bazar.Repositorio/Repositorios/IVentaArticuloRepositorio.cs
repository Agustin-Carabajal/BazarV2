using Bazar.BD.Datos.Entity;
using Bazar.shared.DTO;

namespace Bazar.Repositorio.Repositorios
{
    public interface IVentaArticuloRepositorio : IRepositorio<VentaArticulo>
    {

        Task<VentaArticuloMostrarDTO?> SelecMostrarVentaArticulos(string cod);
        Task<VentaArticulo?> SelectByVentaCod(string cod);
    }
}