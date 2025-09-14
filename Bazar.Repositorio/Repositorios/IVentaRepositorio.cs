using Bazar.BD.Datos.Entity;
using Bazar.shared.DTO;

namespace Bazar.Repositorio.Repositorios
{
    public interface IVentaRepositorio : IRepositorio<Venta>
    {
        Task<VentaResumenDTO?> SelecResumenVentas(string cod);
        Task<Venta?> SelectByVentaCod(string cod);
        Task<VentaResumenDTO?> SelecVentasDelDia(DateTime dia);
    }
}