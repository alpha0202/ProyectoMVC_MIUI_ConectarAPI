using CapaEntidad;
using System.Text.Json;

namespace ProyectoMVC_MIUI_ConectarAPI.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClienteRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

     
        public async Task<List<T>> GetAll<T>(IHttpClientFactory httpClientFactory, string urlBase, string rutaAPI)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(urlBase);
                string cadena = await client.GetStringAsync(rutaAPI);
                List<T> Lstresult = JsonSerializer.Deserialize<List<T>>(cadena);
                return Lstresult;

            }
            catch (Exception e)
            {

                return new List<T>();
            }

        }

        public async Task<T> GetDetail<T>(IHttpClientFactory httpClientFactory, string urlBase, string rutaAPI)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(urlBase);
                string cadena = await client.GetStringAsync(rutaAPI);
                var Lstresult = JsonSerializer.Deserialize<T>(cadena);
                return Lstresult;

            }
            catch (Exception e)
            {

                return (T)Activator.CreateInstance(typeof(T));
            }

        }

        public async Task<PersonaCLS> GetDetailbyId(IHttpClientFactory httpClientFactory, string urlBase, string rutaAPI)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(urlBase);
                string cadena = await client.GetStringAsync(rutaAPI);
                var Lstresult = JsonSerializer.Deserialize<PersonaCLS>(cadena);
                return Lstresult;

            }
            catch (Exception e)
            {

                return (PersonaCLS)Activator.CreateInstance(typeof(PersonaCLS));
            }
        }
    }
}
