using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC_MIUI_ConectarAPI.Repositorio;
using System.Text.Json;

namespace ProyectoMVC_MIUI_ConectarAPI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IClienteRepository _clienteRepository;
        private string _baseUrl;

        public PersonaController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IClienteRepository clienteRepository)
        {
            _baseUrl = configuration["baseUrl"];
            _httpClientFactory = httpClientFactory;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
           

            return View();
        }

        public async Task<List<PersonaCLS>> ListarPersonas()
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(_baseUrl);

            //string strCadena = await cliente.GetStringAsync("/api/persona");

            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(strCadena);

            return await _clienteRepository.GetAll<PersonaCLS>(_httpClientFactory,_baseUrl, "/api/persona");
        }


        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombre)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(_baseUrl);

            //string strCadena = await cliente.GetStringAsync("/api/persona/"+ nombre);

            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(strCadena);

            return await _clienteRepository.GetAll<PersonaCLS>(_httpClientFactory, _baseUrl, "/api/persona/" + nombre);
        }

        public async Task<PersonaCLS> RecuperarPersonasById(int id)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(_baseUrl);

            //string strCadena = await cliente.GetStringAsync("/api/persona/"+ nombre);

            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(strCadena);

            return await _clienteRepository.GetDetailbyId(_httpClientFactory, _baseUrl, "/api/persona/personaid/" + id);
        }

    }
}
