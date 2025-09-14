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
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IUsuarioRepositorio repositorio;

        public UsuarioController(AppDbContext context, IUsuarioRepositorio repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet] //api/Usuario

        public async Task<ActionResult<List<Usuario>>> GetFull()
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


        [HttpGet("{id:int}")] //api/Usuario/3

        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(entidad);
        }


        [HttpGet("{dni}")] //api/Usuario/12345678

        public async Task<ActionResult<Usuario>> GetByDni(string dni)
        {
            var entidad = await repositorio.SelectByDni(dni);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con el DNI: {dni}.");
            }

            return Ok(entidad);
        }

        [HttpGet("listausuario")] //api/listausuario

        public async Task<ActionResult<List<UsuarioMostrarDTO>>> ListaUsuario()
        {
            var entidad = await repositorio.SelecListaUsuario();
            //var articulos = await context.Articulos.ToListAsync();
            if (entidad == null)
            {
                return NotFound("No se encontraron usuarios, VERIFICAR.");
            }
            if (entidad.Count == 0)
            {
                return Ok("No existen usuarios en este momento.");
            }

            return Ok(entidad);
        }

        [HttpGet("usuariomostrar")] //api/usuariomostrar

        public async Task<ActionResult<UsuarioMostrarDTO>> MostrarUsuario(string dni)
        {
            var entidad = await repositorio.SelecUsuarioMostrar(dni);
            //var articulos = await context.Articulos.ToListAsync();
            if (entidad == null)
            {
                return NotFound($"No existe el usuario con el DNI: {dni}.");
            }

            return Ok(entidad);
        }


        [HttpPost] 

        public async Task<ActionResult<int>> Post(Usuario DTO)
        {
            try
            {
                await context.Usuarios.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el registro: {e.Message}");
            }
        }


        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, Usuario DTO)
        {
            if (id!= DTO.Id)
            {
                return BadRequest("Datos no válidos.");
            }
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Update(DTO);
            await context.SaveChangesAsync();
            return Ok($"Registro con el id: {id} actualizado correctamente");
        }



        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            ///var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            ///if (existe == false)
            ///{
            ///    return NotFound($"No se encontró el artículo con el id: {id}.");
            ///   ;
            ///}   
            var articulo = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (articulo is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Usuarios.Remove(articulo);
            await context.SaveChangesAsync();
            return Ok($"El registro con id: {id}, fue eliminado correctamente.");

        }

    }
}
