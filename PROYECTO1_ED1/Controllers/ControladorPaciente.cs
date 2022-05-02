﻿using Microsoft.AspNetCore.Http;
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
            return View(Data.Instance.ÁrbolPacientes);
        }

        //vista para mostrar error con las fechas
        public ActionResult Error()
        {
            return View();
        }



        // GET: ControladorPaciente/Details/5
        public ActionResult Details(int id)
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
            ModeloPaciente PacienteBuscado = new ModeloPaciente();
            PacienteBuscado.DPI = parametro;

            
            if (Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro)) != default)
            {
                return View(Data.Instance.ÁrbolPacientes.Buscar(Lab03_ED_2022.Delegados.Delegado.CompararDPI(parametro)));
            }
            else
            {
                //return RedirectToAction(nameof(ErrorBusqueda));
                return null;

            }
        }

        // POST: ControladorPaciente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {


            if (ModeloPaciente.Guardar(new ModeloPaciente
            {
                Nombres = collection["Nombres"],
                Apellidos = collection["Apellidos"],
                DPI = long.Parse(collection["DPI"]),
                Edad = int.Parse(collection["Edad"]),
                Teléfono = long.Parse(collection["Teléfono"]),
                ÚltimaConsulta = DateTime.Parse(collection["ÚltimaConsulta"]),
                PróximaConsulta = DateTime.Parse(collection["PróximaConsulta"]),
                DescripciónTratamiento = collection["DescripciónTratamiento"],
            }) == true)
            {
                return RedirectToAction(nameof(Index));
                
            }
            return RedirectToAction(nameof(Error)); 
            
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

        // GET: ControladorPaciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControladorPaciente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
