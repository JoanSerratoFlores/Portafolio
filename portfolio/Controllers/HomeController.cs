using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Diagnostics;
using portfolio.Servicios;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        //private readonly IConfiguration configuracion;

        //private readonly ServicioDelimitado servicioDelimitado;
        //private readonly ServicioTransitorio servicioTransitorio;
        //private readonly ServicioUnico servicioUnico;
        //private readonly ServicioDelimitado servicioDelimitado2;
        //private readonly ServicioTransitorio servicioTransitorio2;
        //private readonly ServicioUnico servicioUnico2;

        public HomeController(ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            IServicioEmail servicioEmail
            //IConfiguration configuracion
            //ServicioDelimitado servicioDelimitado,
            //ServicioTransitorio servicioTransitorio,
            //ServicioUnico servicioUnico,

            //ServicioDelimitado servicioDelimitado2,
            //ServicioTransitorio servicioTransitorio2,
            //ServicioUnico servicioUnico2

            )
        {
            //_logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
            //this.configuracion = configuracion;
            //this.servicioDelimitado = servicioDelimitado;
            //this.servicioTransitorio = servicioTransitorio;
            //this.servicioUnico = servicioUnico;
            //this.servicioDelimitado2 = servicioDelimitado2;
            //this.servicioTransitorio2 = servicioTransitorio2;
            //this.servicioUnico2 = servicioUnico2;
        }

        public IActionResult Index()
        {
            //var apellido = configuracion.GetValue<string>("Apellido");
            //_logger.LogTrace("Este es un mensaje de LogTrace");
            //_logger.LogDebug("Este es un mensaje de LogDebug");
            //_logger.LogInformation("Este es un mensaje de log");
            //_logger.LogWarning("Este es un mensaje de LogWarning");
            //_logger.LogError("Este es un mensaje de LogError");
            //_logger.LogCritical("Este es un mensaje de LogCritical " + apellido);

            //var persona = new Persona()
            //{
            //    Nombre = "Joan Emanuele Serrato Flores",
            //    Edad = 3,
            //};

            //ViewBag.nombre="Joan Emanuele Serrato Flores";//
            //ViewBag.edad=22;

            //return View("Index",persona);

            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            //var guidViewmodel = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado.ObtenerGuid,
            //    Transitorio = servicioTransitorio.ObtenerGuid,
            //    Unico = servicioUnico.ObtenerGuid,
            //};

            //var guidViewmodel2 = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado2.ObtenerGuid,
            //    Transitorio = servicioTransitorio2.ObtenerGuid,
            //    Unico = servicioUnico2.ObtenerGuid,
            //};

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                //EjemploGUID_1=guidViewmodel,
                //EjemploGUID_2 = guidViewmodel2
            };
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
