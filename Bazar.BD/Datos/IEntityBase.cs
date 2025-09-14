using Bazar.shared.ENUM;

namespace Bazar.BD.Datos
{
    public interface IEntityBase
    {
        EstadoRegistro EstadoRegistro { get; set; }
        int Id { get; set; }
        string Observacion { get; set; }
    }
}