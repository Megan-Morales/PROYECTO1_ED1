using Lab03_ED_2022.Estructuras_de_datos;
using PROYECTO1_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO1_ED1.Helpers
{
    public class Singleton
    {
        //anti patrón singleton 
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public Árbol<ModeloPaciente> ÁrbolPacientes = new Árbol<ModeloPaciente>
        {

        };
    }
}
