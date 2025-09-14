using Bazar.BD.Datos;
using Bazar.BD.Datos.Entity;
using Bazar.Repositorio.Repositorios;
using Bazar.shared.DTO;
using Bazar.shared.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bazar.Server.Controllers
{
    [ApiController]
    [Route("api/Articulo")]
    public class ArticuloController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IArticuloRepositorio repositorio;

        public ArticuloController(AppDbContext context,
                                 
                                  IArticuloRepositorio repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<Articulo>>> GetArticulo()
        {
            var articulos = await repositorio.Select();
            //var articulos = await context.Articulos.ToListAsync();
            if (articulos == null)
            {
                return NotFound("No se encontraron artículos, VERIFICAR.");
            }
            if (articulos.Count == 0)
            {
                return Ok("No existen artículos en este momento.");
            }

            return Ok(articulos);
        }

        [HttpGet("listaarticulo")] //api/listaarticulo

        public async Task<ActionResult<List<ArticuloListadoDTO>>> ListaArticulo()
        {
            var articulos = await repositorio.SelecListaArticulo();
            //var articulos = await context.Articulos.ToListAsync();
            if (articulos == null)
            {
                return NotFound("No se encontraron artículos, VERIFICAR.");
            }
            if (articulos.Count == 0)
            {
                return Ok("No existen artículos en este momento.");
            }

            return Ok(articulos);
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(ArticuloDTO DTO)
        {
            try
            {
                Articulo entidad = new Articulo()
                {
                    CodigoBarras = DTO.CodigoBarras,
                    DescripcionArticulo = DTO.DescripcionArticulo,
                    MarcaArticulo = DTO.MarcaArticulo,
                    StockArticulo = DTO.StockArticulo,
                    PrecioArticulo = DTO.PrecioArticulo,
                    ProveedorId = DTO.ProveedorId,
                    EstadoRegistro = EstadoRegistro.activo
                };
                var id = await repositorio.Insert(entidad);
                return Ok(entidad.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar guardar el artículo: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, Articulo DTO)
        {
            //if (id!= DTO.Id)
            //{
            //    return BadRequest("Datos no válidos.");
            //}
            //var existe = await repositorio.Existe(id);
            //var existe = await context.Articulos.AnyAsync(x => x.Id == id);
            //if (!existe)
            //{
            //    return NotFound($"No se encontró el artículo con el id: {id}.");
            //}
            //context.Update(DTO);
            //await context.SaveChangesAsync();
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no válidos o el artículo no existe.");
            }
            return Ok($"Artículo con el id: {id} actualizado correctamente");
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Articulo>> GetById(int id)
        {
            var articulo = await repositorio.SelectById(id);
            //var articulo = await context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
            if (articulo is null)
            {
                return NotFound($"No existe el artículo con el id: {id}.");
            }

            return Ok(articulo);
        }

        [HttpGet("{cod}")]

        public async Task<ActionResult<Articulo>> GetByCod(string cod)
        {
            var articulo = await repositorio.SelectByCod(cod);
            if (articulo is null)
            {
                return NotFound($"No existe el artículo con el Código de barras: {cod}.");
            }

            return Ok(articulo);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            ///var existe = await context.Articulos.AnyAsync(x => x.Id == id);
            ///if (existe == false)
            ///{
            ///    return NotFound($"No se encontró el artículo con el id: {id}.");
            ///   ;
            ///}   
            var articulo = await context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
            if (articulo is null)
            {
                return NotFound($"No existe el artículo con el id: {id}.");
            }
            context.Articulos.Remove(articulo);
            await context.SaveChangesAsync();
            return Ok($"El artículo con id: {id}, fue eliminado correctamente.");

        }

    }
}
