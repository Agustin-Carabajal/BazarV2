using Bazar.BD.Datos;
using Bazar.BD.Datos.Entity;
using Bazar.shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Repositorio.Repositorios
{
    public class VentaArticuloRepositorio : Repositorio<VentaArticulo>, IVentaArticuloRepositorio
    {
        private readonly AppDbContext context;
        public VentaArticuloRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<VentaArticulo?> SelectByVentaCod(string cod)
        {
            try
            {
                VentaArticulo? entidad = await context.VentasArticulos
                    .Include(x => x.Venta)
                    .FirstOrDefaultAsync(x => x.CodVentaArticulo == cod);
                return entidad;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<VentaArticuloMostrarDTO?> SelecMostrarVentaArticulos(string cod)
        {
            var entidad = await context.VentasArticulos
                                    .Where(x => x.CodVentaArticulo == cod)
                                    .Select(v => new VentaArticuloMostrarDTO
                                    {
                                        Id = v.Id,
                                        VentaArticuloCod = v.CodVentaArticulo,
                                        CodVenta = v.Venta!.CodVenta,
                                        FechaVenta = v.Venta!.FechaVenta,
                                        ArticuloCod = v.Articulo!.CodigoBarras,
                                        ArticuloNombre = v.Articulo!.DescripcionArticulo,
                                        CantidadArt = v.CantidadArt,
                                        PrecioUnitarioArt = v.PrecioUnitarioArt,
                                        SubtotalArt = (v.CantidadArt * v.PrecioUnitarioArt)
                                    })
                                    .FirstOrDefaultAsync();
            return entidad;
        }
    }
}
