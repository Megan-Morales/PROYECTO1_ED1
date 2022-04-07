﻿using PROYECTO1_ED1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO1_ED1.Models
{
    public class ModeloPaciente
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public long DPI { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public int Teléfono { get; set; }
        [Required]
        public DateTime ÚltimaConsulta { get; set; }
        public DateTime PróximaConsulta { get; set; }
        public string DescriptionTratamiento { get; set; }

        public static bool Guardar(ModeloPaciente datos)
        {
            Data.Instance.ÁrbolPacientes.Insert(datos);
            return true; 
        }
    }
}
