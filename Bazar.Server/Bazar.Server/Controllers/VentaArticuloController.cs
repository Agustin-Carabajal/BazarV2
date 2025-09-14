using Bazar.BD.Datos;
using Bazar.BD.Datos.Entity;
using Bazar.Repositorio.Repositorios;
using Bazar.shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bazar.Server.Controllers
{
    [ApiController]
    [Route("api/VentaArticulo")]
    public class VentaArticuloController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IVentaArticuloRepositorio repositorio;

        public VentaArticuloController(AppDbContext context, IVentaArticuloRepositorio repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet] //api/VentaArticulo

        public async Task<ActionResult<List<VentaArticulo>>> GetFull()
        {
            var lista = await repositorio.Select();
            if (lista == null)
            {
                return NotFound("No se encontró elementos de la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista sin registros.");
            }

            return Ok(lista);
        }


        [HttpGet("{id:int}")] //api/VentaArticulo/3

        public async Task<ActionResult<VentaArticulo>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(entidad);
        }


        [HttpGet("{cod}")] //api/VentaArticulo/12345678

        public async Task<ActionResult<VentaArticulo>> GetByCodSelectByVentaCod(string cod)
        {
            var entidad = await repositorio.SelectByVentaCod(cod);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el código: {cod}.");
            }

            return Ok(entidad);
        }


        [HttpGet("ventaarticulomostrar")] //ventaarticulomostrar

        public async Task<ActionResult<VentaArticuloMostrarDTO>> MostrarVentaArticulo(string cod)
        {
            var entidad = await repositorio.SelecMostrarVentaArticulos(cod);
            //var articulos = await context.Articulos.ToListAsync();
            if (entidad == null)
            {
                return NotFound($"No existen ventas con el código: {cod}.");
            }

            return Ok(entidad);
        }

    }
}
