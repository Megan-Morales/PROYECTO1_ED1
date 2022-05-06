using Lab03_ED_2022.Delegados;
using Lab03_ED_2022.Estructura_de_Datos;
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
            CompararId = Delegado.CompararDPI,
            CompararFecha = Delegado.VerificarFecha,
            CompararNombres = Delegado.CompararNombres,
            CompararFechaBuscar = Delegado.CompararFecha


        };

        //arbol para guardar las fechas de consulta 
        public Árbol<ModeloPaciente> FechasdeConsulta = new Árbol<ModeloPaciente>
        {
            Comparar = Delegado.CompararFecha,
            CompararId = Delegado.CompararDPI,
            CompararFecha = Delegado.VerificarFecha,
            CompararNombres = Delegado.CompararNombres,
            CompararFechaBuscar = Delegado.CompararFecha

        };

        public ColaRecorrido<ModeloPaciente> PacientesOrtodoncia = new ColaRecorrido<ModeloPaciente> { };
        public ColaRecorrido<ModeloPaciente> PacientesCaries = new ColaRecorrido<ModeloPaciente> { };
        public ColaRecorrido<ModeloPaciente> PacientesNoDiagnostico= new ColaRecorrido<ModeloPaciente> { };
        public ColaRecorrido<ModeloPaciente> PacientesDiagnostico = new ColaRecorrido<ModeloPaciente> { };
    }
}
