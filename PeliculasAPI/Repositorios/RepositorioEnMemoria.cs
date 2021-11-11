using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public class RepositorioEnMemoria
    {
        private List<Genero> _generos;
        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>() {
                new Genero(){ Id = 1, Nombre="Comedia"},
                new Genero(){ Id = 1, Nombre="Accion"}
            };
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }
    }
}
