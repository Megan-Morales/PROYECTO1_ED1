using PROYECTO1_ED1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO1_ED1.Models
{
    public class Citas
    {
        public DateTime Fecha { get; set; }
        public int Contador { get; set; }

        public static bool GuardarCitas(Citas datos)
        {
            if ((Data.Instance.FechasdeConsulta.Insert(datos) == true))
            {
                return true;
            }
            return false;
            

        }

    }

    
}
