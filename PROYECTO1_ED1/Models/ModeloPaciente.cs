﻿using Lab03_ED_2022.Delegados;
using PROYECTO1_ED1.Helpers;
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
        [MaxLength (13)]
        public long DPI { get; set; }

        [Required]
        [Range(0,150)]
        public int Edad { get; set; }

        [Required]
        [MaxLength(8)]
        public long Teléfono { get; set; }

        [Required]
        public DateTime ÚltimaConsulta { get; set; }

        public string DescripciónTratamiento { get; set; }
        [Required]
        public string Tratamiento { get; set; }
       
        public DateTime? PróximaConsulta { get; set; }

        public static bool Guardar(ModeloPaciente datos)
        {
            if ((Data.Instance.ÁrbolPacientes.VerificarFechaAnterior(datos) == true && datos.PróximaConsulta == default))
            {
                
                    Data.Instance.ÁrbolPacientes.Insert(datos);
                    return true;
                
            }

            if (Data.Instance.ÁrbolPacientes.VerificarFechaAnterior(datos) == true && Data.Instance.ÁrbolPacientes.VerificarProxFecha(datos) == true)
            {
                Data.Instance.ÁrbolPacientes.Insert(datos);  
                return true;
            }

            return false; 
            
        }

        public static void GuardadColaO (ModeloPaciente datos)
        {
            Data.Instance.PacientesOrtodoncia.Encolar(datos);   
        }
        public static void GuardadColaC(ModeloPaciente datos)
        {
            Data.Instance.PacientesCaries.Encolar(datos);
        }
        public static void GuardadColaS(ModeloPaciente datos)
        {
            Data.Instance.PacientesNoDiagnostico.Encolar(datos);
        }
        public static void GuardadColaX(ModeloPaciente datos)
        {
            Data.Instance.PacientesDiagnostico.Encolar(datos);
        }
    }
}
