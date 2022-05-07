using Lab03_ED_2022.Delegados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO1_ED1.Helpers;
using PROYECTO1_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO1_ED1.Controllers
{
    public class ControladorPaciente : Controller
    {
        // GET: ControladorPaciente
        public ActionResult Index()
        {
            Data.Instance.ÁrbolPacientes.CompararListas = Delegado.EncolarTodo;
            return View(Data.Instance.ÁrbolPacientes);
        }
        public ActionResult IndexCaries()
        {
            Data.Instance.ÁrbolPacientes.CompararListas = Delegado.Caries;
            return View(Data.Instance.ÁrbolPacientes);
        }
        public ActionResult IndexOrtodoncia()
        {
            Data.Instance.ÁrbolPacientes.CompararListas = Delegado.Ortodoncia;
            return View(Data.Instance.ÁrbolPacientes);
        }
        public ActionResult IndexSinDiagnostico()
        {
            Data.Instance.ÁrbolPacientes.CompararListas = Delegado.SinDianóstico;
            return View(Data.Instance.ÁrbolPacientes);
        }
        public ActionResult IndexOtro()
        {
            Data.Instance.ÁrbolPacientes.CompararListas = Delegado.Otro;
            return View(Data.Instance.ÁrbolPacientes);
        }
        //vista para mostrar error con las fechas
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult ErrorBusqueda(int id)
        {
            return View();
        }

        // GET: ControladorPaciente/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult IndiceBusqueda()
        {
            //formulario para busquedas
            return View(new ModeloPaciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndiceBusqueda(IFormCollection collection)
        {
            try
            {


                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BusquedaDpi()
        {
            return View(new ModeloPaciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaDpi(IFormCollection collection)
        {
            int parametro = (int.Parse(collection["DPI"]));

            if (Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro)) != default)
            {
                return View(Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro)));
            }
            else
            {
                return RedirectToAction(nameof(ErrorBusqueda));
            }
        }
        public ActionResult BusquedaNombre()
        {
            return View(new ModeloPaciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaNombre(IFormCollection collection)
        {
            string parametro = (collection["Nombres"]);
            string parametro2 = (collection["Apellidos"]);

            if (Data.Instance.ÁrbolPacientes.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2)) != default)
            {
                return View(Data.Instance.ÁrbolPacientes.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2)));
            }
            else
            {
                return RedirectToAction(nameof(ErrorBusqueda));
            }
        }
        // POST: ControladorPaciente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            

            try
            {
                if ((Citas.GuardarCitas(new Citas
                {
                    Fecha = DateTime.Parse(collection["PróximaConsulta"]).Date,
                    Contador = 1
                }) == true))
                {
                    if (ModeloPaciente.Guardar(new ModeloPaciente
                    {
                        Nombres = collection["Nombres"],
                        Apellidos = collection["Apellidos"],
                        DPI = long.Parse(collection["DPI"]),
                        Edad = int.Parse(collection["Edad"]),
                        Teléfono = long.Parse(collection["Teléfono"]),
                        ÚltimaConsulta = DateTime.Parse(collection["ÚltimaConsulta"]),
                        PróximaConsulta = DateTime.Parse(collection["PróximaConsulta"]).Date,
                        DescripciónTratamiento = collection["DescripciónTratamiento"],
                        Tratamiento = collection["Tratamiento"],
                    }) == true)



                    {
                        return RedirectToAction(nameof(Index));

                    }
                    return RedirectToAction(nameof(Error));

                }
                return RedirectToAction(nameof(Error));

            }
            catch 
            {
                if (ModeloPaciente.Guardar(new ModeloPaciente
                {
                    Nombres = collection["Nombres"],
                    Apellidos = collection["Apellidos"],
                    DPI = long.Parse(collection["DPI"]),
                    Edad = int.Parse(collection["Edad"]),
                    Teléfono = long.Parse(collection["Teléfono"]),
                    ÚltimaConsulta = DateTime.Parse(collection["ÚltimaConsulta"]),

                    DescripciónTratamiento = collection["DescripciónTratamiento"],
                    Tratamiento = collection["Tratamiento"],
                }) == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                
                
                    return RedirectToAction(nameof(Error));
                

            }
            



           





        }
        // GET: ControladorPaciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControladorPaciente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult IndiceEdicion()
        {
            //formulario para busquedas
            return View(new ModeloPaciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndiceEdicion(IFormCollection collection)
        {
            try
            {


                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EdicionDpi()
        {
            return View(new ModeloPaciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdicionDpi(IFormCollection collection)
        {
            int parametro = (int.Parse(collection["DPI"]));

            DateTime FechaModificar = (DateTime.Parse(collection["PróximaConsulta"])).Date;
            
            ModeloPaciente PacienteModificar = null;


            //ENCUENTRA EL PACIENTE //si la fecha ingresada es menor o igual
            if (Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro)) != default && DateTime.Compare(DateTime.Now, FechaModificar) <= 0)
            {
                PacienteModificar = Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro));

                DateTime fechaBorrar = (DateTime) PacienteModificar.PróximaConsulta;



                if (Data.Instance.FechasdeConsulta.Insert(new Citas
                {
                    Fecha = FechaModificar,
                    Contador = 0,

                }) == false)

                {
                    return RedirectToAction(nameof(Error));
                }



                //resta la fecha que se modificó 
                Data.Instance.FechasdeConsulta.RestarFechas(new Citas
                {
                    Fecha = fechaBorrar,
                }) ;

                //modifica el árbol de pacientes



                //actualiza el nodo
                PacienteModificar.PróximaConsulta = FechaModificar;

            }
            else
            {
                //si no encuentra el error
                return RedirectToAction(nameof(ErrorBusqueda));
            }


            return RedirectToAction(nameof(Index));
        }

        public ActionResult EdicionNombres()
        {
            return View(new ModeloPaciente());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EdicionNombres(IFormCollection collection)
        //{
        //    string parametro = (collection["Nombres"]);
        //    string parametro2 = (collection["Apellidos"]);
        //    DateTime FechaModificar = (DateTime.Parse(collection["PróximaConsulta"]));

        //    ModeloPaciente PacienteBuscar = new ModeloPaciente();
        //    PacienteBuscar.Nombres = parametro;
        //    PacienteBuscar.Apellidos = parametro2;
        //    ModeloPaciente PacienteModificar = null;

        //    ModeloPaciente PacienteBuscar2 = new ModeloPaciente();
        //    PacienteBuscar2.Nombres = parametro;
        //    PacienteBuscar2.Apellidos = parametro2;
        //    ModeloPaciente PacienteModificar2 = null;

        //    if (Data.Instance.ÁrbolPacientes.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2)) != default && Data.Instance.FechasdeConsulta.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2)) != default)
        //    {
        //        PacienteModificar = Data.Instance.ÁrbolPacientes.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2));
        //        PacienteModificar2 = Data.Instance.FechasdeConsulta.BuscarNombre(Lab03_ED_2022.Delegados.Delegado.CompararNombres(parametro, parametro2));

        //        if (DateTime.Compare(DateTime.Now, FechaModificar) <= 0) //si la fecha ingresada es menor o igual
        //        {
        //            Lab03_ED_2022.Estructuras_de_datos.Nodo<ModeloPaciente> fechaBuscada = Data.Instance.FechasdeConsulta.BuscarFecha(Lab03_ED_2022.Delegados.Delegado.CompararFecha(FechaModificar));
        //            Lab03_ED_2022.Estructuras_de_datos.Nodo<ModeloPaciente> fechaBuscadaAnterior = Data.Instance.FechasdeConsulta.BuscarFecha(Lab03_ED_2022.Delegados.Delegado.CompararFecha((DateTime)PacienteModificar.PróximaConsulta));
        //            if (fechaBuscada == null)
        //            {
        //                PacienteModificar.PróximaConsulta = FechaModificar; //se modifica en ambos arboles
        //                PacienteModificar2.PróximaConsulta = FechaModificar;

        //                ModeloPaciente.Guardar(PacienteModificar);

        //                fechaBuscadaAnterior.totalConsultas--;

        //            }
        //            else if (fechaBuscada.totalConsultas < 8)
        //            {
        //                PacienteModificar.PróximaConsulta = FechaModificar;
        //                PacienteModificar2.PróximaConsulta = FechaModificar;
        //                fechaBuscada.totalConsultas++;
        //                fechaBuscadaAnterior.totalConsultas--;
        //            }
        //            else
        //            {
        //                return RedirectToAction(nameof(Error));
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(Error));
        //        }


        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(ErrorBusqueda));

        //    }
        //}
    }

}
