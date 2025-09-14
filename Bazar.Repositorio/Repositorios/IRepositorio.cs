using Bazar.BD.Datos;

namespace Bazar.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
        Task<bool> Update(int id, E entidad);
    }
}