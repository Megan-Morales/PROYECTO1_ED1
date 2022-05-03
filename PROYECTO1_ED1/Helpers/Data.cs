using Lab03_ED_2022.Delegados;
using Lab03_ED_2022.Estructuras_de_datos;
using PROYECTO1_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO1_ED1.Helpers
{
    public class Data
    {
        //anti patrón singleton 
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

        public Árbol<ModeloPaciente> ÁrbolPacientes = new Árbol<ModeloPaciente>
        {
            Comparar = Delegado.CompararDPI,
            CompararFecha = Delegado.VerificarFecha,
            CompararNombres = Delegado.CompararNombres


        };

        //arbol para guardar las fechas de consulta 
        public Árbol<ModeloPaciente> FechasdeConsulta = new Árbol<ModeloPaciente>
        {
            Comparar = Delegado.CompararFecha,
            CompararFecha = Delegado.VerificarFecha,
        };
    }
}
