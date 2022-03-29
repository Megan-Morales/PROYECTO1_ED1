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
        public string Nombre { get; set; }
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

    }
}
