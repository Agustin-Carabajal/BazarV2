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
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly AppDbContext context;

        public UsuarioRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Usuario?> SelectByDni(string dni)
        {
            try
            {
                Usuario? entidad = await context.Usuarios
                                            .FirstOrDefaultAsync(x => x.DniUsuario == dni);
                return entidad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UsuarioMostrarDTO>> SelecListaUsuario()
        {
            var lista = await context.Usuarios
                                    .Select(x => new UsuarioMostrarDTO
                                    {
                                        Id = x.Id,
                                        Nombre = $"{x.NombreUsuario} - {x.ApellidoUsuario}",
                                        tipoUsuario = x.UsuarioTipo
                                    })
                                    .ToListAsync();
            return lista;
        }

        public async Task<UsuarioMostrarDTO?> SelecUsuarioMostrar(string dni)
        {
            var entidad = await context.Usuarios
                                   .Where(x => x.DniUsuario == dni)
                                   .Select(v => new UsuarioMostrarDTO
                                   {
                                       Id = v.Id,
                                       Dni = v.DniUsuario!,
                                       Nombre = v.NombreUsuario,
                                       Apellido = v.ApellidoUsuario,
                                       tipoUsuario = v.UsuarioTipo
                                   })
                                    .FirstOrDefaultAsync();
            return entidad;
        }
    }
}
