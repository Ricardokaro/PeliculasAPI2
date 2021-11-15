using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController, ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;            
        }

        [HttpGet]// api/generos
        [HttpGet("listado")]// api/generos/listado
        [HttpGet("listadogeneros")]// api/generos/listadogeneros
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Vamos a mostrar los géneros");
            return repositorio.ObtenerTodosLosGeneros();
        }     

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id,[FromHeader] string Nombre)
        {
            logger.LogDebug($"Obteniendo un genero por el id {Id}");
            var genero = await repositorio.ObtenerPorId(Id);
            if (genero == null)
            {
                logger.LogWarning($"No pudimos encontrar el género con id {Id}");
                NotFound();
            }
            return genero;
        }

        [HttpGet("{guid}")]        
        public ActionResult<Guid> GetGuid()
        {
            return Ok(new
            {
                guid_GenerosController = repositorio.ObtenerGuid(),
                guid_WeatherForescastController = weatherForecastController.ObtenerGuidWeaterForescatController()
            });
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

       
    }
}
