﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength:10)]
        public string Nombre { get; set; }
        [Range(18,120)]
        public int Edad { get; set; }
        [CreditCard]
        public string TarjetaDeCredito { get; set; }
        [Url]
        public string Url { get; set; }
    }
}
