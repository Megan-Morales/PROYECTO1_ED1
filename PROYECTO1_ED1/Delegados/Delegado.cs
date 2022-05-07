using PROYECTO1_ED1.Models;
using System;

namespace Lab03_ED_2022.Delegados
{
    public delegate int Compare<T>(T a, T b);
    public delegate int VerificarFecha<T>(T a);
    

    public class Delegado
    {
       
        public static int VerificarFecha(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;
            
          
            if (DateTime.Compare((DateTime)a.PróximaConsulta,HoraActual) < 0) 
            {
                return 1; 
            }
            return 0; 
        }
      

        public static int VerificarFechaAnterior (ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;


            if (DateTime.Compare((DateTime)a.ÚltimaConsulta, HoraActual) > 0)
            {
                return 1;
            }
            return 0;
        }

        public static int SinDianóstico(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;
            HoraActual = HoraActual.AddMonths(-6);

            if (a.PróximaConsulta == default && a.Tratamiento == "Sin diagnóstico" && a.ÚltimaConsulta <= HoraActual)
            {
                return 1;
            }

            return 0;
            
        }

        public static int Ortodoncia(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;
            HoraActual = HoraActual.AddMonths(-2);

            if (a.PróximaConsulta == default && a.Tratamiento == "Ortodoncia" && a.ÚltimaConsulta <= HoraActual)
            {
                return 1;
            }

            return 0;

        }

        public static int Caries(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;
            HoraActual = HoraActual.AddMonths(-4);

            if (a.PróximaConsulta == default && a.Tratamiento == "Caries" && a.ÚltimaConsulta <= HoraActual)
            {
                return 1;
            }

            return 0;

        }

        public static int Otro(ModeloPaciente a)
        {
            DateTime HoraActual = DateTime.Now.Date;
            HoraActual = HoraActual.AddMonths(-6);

            if (a.PróximaConsulta == default && a.Tratamiento == "Otro" && a.ÚltimaConsulta <= HoraActual)
            {
                return 1;
            }

            return 0;

        }

        public static int EncolarTodo(ModeloPaciente a)
        {
             return 1;
        }

        public static int BuscarFecha(ModeloPaciente a, ModeloPaciente b)
        {
            if (a.PróximaConsulta == b.PróximaConsulta)
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

        public static int CompararFecha(ModeloPaciente a, ModeloPaciente b)
        {

            if (a.PróximaConsulta != b.PróximaConsulta)
            {
                if (a.PróximaConsulta < b.PróximaConsulta)
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

        public static int CompararFechaCitas(Citas a, Citas b)
        {

            if (a.Fecha != b.Fecha)
            {
                if (a.Fecha < b.Fecha)
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



        public static int AsignarFecha(ModeloPaciente a, ModeloPaciente b)
        {
            b.PróximaConsulta = a.PróximaConsulta;
            return 1;
        }

        public static int CompararNombres(ModeloPaciente a, ModeloPaciente b)
        {

            if (a.Nombres == b.Nombres && a.Apellidos == b.Apellidos)
            {
                return 0;
            }
            return 1;

        }

        public static ModeloPaciente CompararDPI(long a)
        {
            ModeloPaciente parametro = new ModeloPaciente();
            parametro.DPI = a;
            return parametro;
        }
        public static ModeloPaciente CompararFecha(DateTime a)
        {
            ModeloPaciente parametro = new ModeloPaciente();
            parametro.PróximaConsulta = a;
            return parametro;
        }

        public static ModeloPaciente CompararNombres(string a, string b)
        {
            ModeloPaciente parametro = new ModeloPaciente();
            parametro.Nombres = a;
            parametro.Apellidos = b;
            return parametro;
        }
    }
}

