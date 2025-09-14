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
    [Route("api/Venta")]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IVentaRepositorio repositorio;

        public VentaController(AppDbContext context,
                                  
                                  IVentaRepositorio repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<Venta>>> GetVenta()
        {
            var lista = await repositorio.Select();
            //var articulos = await context.Articulos.ToListAsync();
            if (lista == null)
            {
                return NotFound("No se encontraron artículos, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("No existen artículos en este momento.");
            }

            return Ok(lista);
        }

        [HttpGet("resumenventa")] //api/resumenventa

        public async Task<ActionResult<VentaResumenDTO>> ResumenVenta(string cod)
        {
            var entidad = await repositorio.SelecResumenVentas(cod);
            //var articulos = await context.Articulos.ToListAsync();
            if (entidad == null)
            {
                return NotFound($"No existe la venta con el Código: {cod}.");
            }

            return Ok(entidad);
        }

        [HttpGet("ventadeldia")] //api/ventadeldia

        public async Task<ActionResult<VentaResumenDTO>> VentaDelDia(DateTime dia)
        {
            var entidad = await repositorio.SelecVentasDelDia(dia);
            //var articulos = await context.Articulos.ToListAsync();
            if (entidad == null)
            {
                return NotFound($"No existen ventas en el día: {dia}.");
            }

            return Ok(entidad);
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult<Venta>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            //var articulo = await context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null)
            {
                return NotFound($"No existe la venta con el id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpGet("{cod}")]

        public async Task<ActionResult<Venta>> GetByCod(string cod)
        {
            var entidad = await repositorio.SelectByVentaCod(cod);
            if (entidad is null)
            {
                return NotFound($"No existe la venta con el Código: {cod}.");
            }

            return Ok(entidad);
        }


    }
}
