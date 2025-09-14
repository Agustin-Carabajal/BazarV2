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
    public class VentaRepositorio : Repositorio<Venta>, IVentaRepositorio
    {

        private readonly AppDbContext context;

        public VentaRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Venta?> SelectByVentaCod(string cod)
        {
            try
            {
                Venta? entidad = await context.Ventas
                    .Include(x => x.Usuario)
                    .FirstOrDefaultAsync(x => x.CodVenta == cod);
                return entidad;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<VentaResumenDTO?> SelecResumenVentas(string cod)
        {
            var entidad = await context.Ventas
                                    .Where(x => x.CodVenta == cod)
                                    .Select(v => new VentaResumenDTO
                                    {
                                        Id = v.Id,
                                        CodVenta = v.CodVenta!,
                                        FechaVenta = v.FechaVenta,
                                        MontoTotal = v.MontoTotal,
                                        DniUsuario = v.Usuario!.DniUsuario,

                                        ArticulosVendidos = context.Set<VentaArticulo>().Where(va => va.VentaId == v.Id)
                                        .Select(va => new ArticuloListadoDTO
                                        {
                                            Id = va.Articulo!.Id,
                                            Articulo = va.Articulo!.DescripcionArticulo,
                                            Cantidad = va.CantidadArt,
                                            Precio = va.PrecioUnitarioArt
                                        }).ToList()
                                    })
                                    .FirstOrDefaultAsync();
            return entidad;
        }

        public async Task<VentaResumenDTO?> SelecVentasDelDia(DateTime dia)
        {
            var entidad = await context.Ventas
                                    .Where(x => x.FechaVenta == dia)
                                    .Select(v => new VentaResumenDTO
                                    {
                                        Id = v.Id,
                                        CodVenta = v.CodVenta!,
                                        FechaVenta = v.FechaVenta,
                                        MontoTotal = v.MontoTotal,
                                        DniUsuario = v.Usuario!.DniUsuario,

                                        ArticulosVendidos = context.Set<VentaArticulo>().Where(va => va.VentaId == v.Id)
                                        .Select(va => new ArticuloListadoDTO
                                        {
                                            Id = va.Articulo!.Id,
                                            Articulo = va.Articulo!.DescripcionArticulo,
                                            Cantidad = va.CantidadArt,
                                            Precio = va.PrecioUnitarioArt
                                        }).ToList()
                                    })
                                    .FirstOrDefaultAsync();
            return entidad;
        }
    }
}
