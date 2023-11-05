using CapaEntidad;

namespace ProyectoMVC_MIUI_ConectarAPI.Repositorio
{
    public interface IClienteRepository
    {
         Task<List<T>> GetAll<T>(IHttpClientFactory httpClientFactory,string urlBase,string rutaAPI );
         Task<T> GetDetail<T>(IHttpClientFactory httpClientFactory,string urlBase,string rutaAPI );



    }
}
