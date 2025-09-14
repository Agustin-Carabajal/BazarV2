using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazar.BD.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUITProveedor = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactoProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTipo = table.Column<int>(type: "int", nullable: false),
                    PerfilUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseniaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarras = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockArticulo = table.Column<int>(type: "int", nullable: false),
                    PrecioArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasDePedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodNotaPedido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNotaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoNotaPedido = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasDePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasDePedido_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasDePedido_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodVenta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialDeAcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodAccion = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TipoAccion = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialDeAcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialDeAcciones_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialDeAcciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    NotaDePedidoId = table.Column<int>(type: "int", nullable: false),
                    CodArtPedido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CantidadPedido = table.Column<int>(type: "int", nullable: false),
                    CantidadRecibida = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticulosPedidos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticulosPedidos_NotasDePedido_NotaDePedidoId",
                        column: x => x.NotaDePedidoId,
                        principalTable: "NotasDePedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasArticulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    CodVentaArticulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CantidadArt = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioArt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubtotalArt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasArticulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasArticulos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasArticulos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Articulo_CodigoBarras_UQ",
                table: "Articulos",
                column: "CodigoBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ProveedorId",
                table: "Articulos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "ArticuloPedido_CodArtPedido_UQ",
                table: "ArticulosPedidos",
                column: "CodArtPedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosPedidos_ArticuloId",
                table: "ArticulosPedidos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosPedidos_NotaDePedidoId",
                table: "ArticulosPedidos",
                column: "NotaDePedidoId");

            migrationBuilder.CreateIndex(
                name: "HistorialDeAccion_CodAccion_UQ",
                table: "HistorialDeAcciones",
                column: "CodAccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialDeAcciones_ArticuloId",
                table: "HistorialDeAcciones",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialDeAcciones_UsuarioId",
                table: "HistorialDeAcciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasDePedido_ProveedorId",
                table: "NotasDePedido",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasDePedido_UsuarioId",
                table: "NotasDePedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "NotaDePedido_CodNotaPedido_UQ",
                table: "NotasDePedido",
                column: "CodNotaPedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Usuario_DniUsuario_UQ",
                table: "Usuarios",
                column: "DniUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Venta_CodVenta_UQ",
                table: "Ventas",
                column: "CodVenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentasArticulos_ArticuloId",
                table: "VentasArticulos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasArticulos_VentaId",
                table: "VentasArticulos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "VentaArticulo_CodVentaArticulo_UQ",
                table: "VentasArticulos",
                column: "CodVentaArticulo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosPedidos");

            migrationBuilder.DropTable(
                name: "HistorialDeAcciones");

            migrationBuilder.DropTable(
                name: "VentasArticulos");

            migrationBuilder.DropTable(
                name: "NotasDePedido");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
