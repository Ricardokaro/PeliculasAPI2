using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]// api/generos
        [HttpGet("listado")]// api/generos/listado
        [HttpGet("listadogeneros")]// api/generos/listadogeneros
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }     

        [HttpGet]
        [Route("{Id:int}/{Nombre=Roberto}")]
        public ActionResult<Genero> Get(int Id, string Nombre)
        {
            var genero = repositorio.ObtenerPorId(Id);
            if (genero == null)
            {
                NotFound();
            }
            return genero;
        }

        [HttpPost]
        public ActionResult Post()
        {
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
