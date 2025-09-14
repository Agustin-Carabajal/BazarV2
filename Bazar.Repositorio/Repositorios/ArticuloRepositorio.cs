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
    public class ArticuloRepositorio : Repositorio<Articulo>,
                                        IRepositorio<Articulo>,
                                        IArticuloRepositorio
    {
        private readonly AppDbContext context;

        public ArticuloRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Articulo?> SelectByCod(string cod)
        {
            try
            {
                Articulo? entidad = await context.Articulos
                                            .FirstOrDefaultAsync(x => x.CodigoBarras == cod);
                return entidad;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<ArticuloListadoDTO>> SelecListaArticulo()
        {
            var lista = await context.Articulos
                                    .Select(x => new ArticuloListadoDTO
                                    {
                                        Id = x.Id,
                                        Articulo = $"{x.CodigoBarras} - {x.DescripcionArticulo} ({x.MarcaArticulo})"
                                    })
                                    .ToListAsync();
            return lista;
        }

    }


}


