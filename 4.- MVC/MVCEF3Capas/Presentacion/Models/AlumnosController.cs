using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Negocio.ServiceReferenceWCFAlumnos;

namespace Presentacion.Models
{
    public class AlumnosController : Controller
    {
        NAlumno metodosAlumnos = new NAlumno();
        NEstado metodosEstados = new NEstado();
        NEstatus metodosEstatus = new NEstatus();
        // GET: Alumnos
        public ActionResult Index()
        {
            return View(metodosAlumnos.Consultar());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id = 2)
        {
            ViewBag.estado = metodosEstados.Consultar((int)metodosAlumnos.Consultar(id).idEstadoOrigen);
            ViewBag.estatus = metodosEstatus.Consultar((int)metodosAlumnos.Consultar(id).idEstatus);
            return View(metodosAlumnos.Consultar(id));
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.estados = metodosEstados.Consultar();
            ViewBag.estatus = metodosEstatus.Consultar();
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumno)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    metodosAlumnos.Agregar(alumno);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            ViewBag.estados = metodosEstados.Consultar();
            ViewBag.estatus = metodosEstatus.Consultar();
            return View();
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(metodosAlumnos.Consultar(id));
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos alumno)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    metodosAlumnos.Actualizar(alumno);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                
            }
            ViewBag.estados = metodosEstados.Consultar();
            ViewBag.estatus = metodosEstatus.Consultar();
            return View();
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(metodosAlumnos.Consultar(id));
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                metodosAlumnos.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _AportacionesIMSS(int id)
        {
            NAlumno alumno = new NAlumno();
            AportacionesIMSS imss = metodosAlumnos.CalcularIMSS(id);
            return PartialView(imss);
        }
        public ActionResult _TablaISR(int id)
        {
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            itemTablaISR = metodosAlumnos.CalcularISR(id);
            return PartialView(itemTablaISR);
        }
    }
}
