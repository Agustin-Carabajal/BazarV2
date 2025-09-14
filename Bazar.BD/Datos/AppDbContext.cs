using Bazar.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.BD.Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<HistorialDeAccion> HistorialDeAcciones { get; set; }
        public DbSet<NotaDePedido> NotasDePedido { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ArticuloPedido> ArticulosPedidos { get; set; }
        public DbSet<VentaArticulo> VentasArticulos { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticuloPedido>(entity =>
            {
                // Índice único en CodArtPedido
                entity.HasIndex(ap => ap.CodArtPedido)
                      .IsUnique()
                      .HasDatabaseName("ArticuloPedido_CodArtPedido_UQ");

                // Relación con NotaDePedido (Cascade)
                entity.HasOne(ap => ap.NotaDePedido)
                      .WithMany()
                      .HasForeignKey(ap => ap.NotaDePedidoId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación con Articulo (Restrict / NoAction)
                entity.HasOne(ap => ap.Articulo)
                      .WithMany()
                      .HasForeignKey(ap => ap.ArticuloId)
                      .OnDelete(DeleteBehavior.Restrict);
            }); // Aquí puedes configurar tus entidades, relaciones, etc.
            /* modelBuilder.Entity<Usuario>().Property(u => u.UsuarioTipo)
                .HasConversion<string>(); // Convierte el enum a string en la base de datos */
        }
    }
}
