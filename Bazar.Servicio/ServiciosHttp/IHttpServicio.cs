
namespace Bazar.Servicio.ServiciosHttp
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}