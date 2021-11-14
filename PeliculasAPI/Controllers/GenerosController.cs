﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
        }

        [HttpGet]// api/generos
        [HttpGet("listado")]// api/generos/listado
        [HttpGet("listadogeneros")]// api/generos/listadogeneros
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }     

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id,[FromHeader] string Nombre)
        {  
            var genero = await repositorio.ObtenerPorId(Id);
            if (genero == null)
            {
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
