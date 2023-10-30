using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProyectoMVC_MIUI_ConectarAPI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;

        public PersonaController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _baseUrl = configuration["baseUrl"];
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
           

            return View();
        }

        public async Task<List<PersonaCLS>> ListarPersonas()
        {
            var cliente = _httpClientFactory.CreateClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            string strCadena = await cliente.GetStringAsync("/api/persona");

            List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(strCadena);

            return lista;
        }


        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombre)
        {
            var cliente = _httpClientFactory.CreateClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            string strCadena = await cliente.GetStringAsync("/api/persona/"+ nombre);

            List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(strCadena);

            return lista;
        }

    }
}
