

using PROYECTO1_ED1.Models;
using System;

namespace Lab03_ED_2022.Comparison
{
    public delegate int Compare<T>(T a, T b);
    public delegate int VerificarFecha<T>(T a);

    public class Delegados
    {

        public static int VerificarFecha(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now;

            if (DateTime.Compare(a.PróximaConsulta,HoraActual) < 0) 
            {
                return 1; 
            }
            return 0; 
        }


       

        public static int CompararDPI(ModeloPaciente a, ModeloPaciente b)
        {

            if (a.DPI != b.DPI)
            {
                if (a.DPI < b.DPI)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static ModeloPaciente CompararDPI(int a)
        {
            ModeloPaciente parametro = new ModeloPaciente();
            parametro.DPI = a;
            return parametro;
        }



    }


}

