using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Razor_ADO.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            return View(NAlumno.Consultar());
        }
        public ActionResult Details(int id = 2)
        {
            Alumno alumno = NAlumno.Consultar(id);
            return View(alumno);
        }
        [HttpGet]
        public ActionResult Delete(int id = 2)
        {
            return View(NAlumno.Consultar(id));
        }
        [HttpPost]
        public ActionResult Delete(Alumno alumno)
        {
            NAlumno.Eliminar(alumno.id);
            return RedirectToAction("Delete");
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.estados = NEstado.Consultar(-3);
            ViewBag.estatus = NEstatusAlumno.Consultar(-3);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            NAlumno.Agregar(alumno);
            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Edit(int id = 2)
        {
            return View(NAlumno.Consultar(id));
        }
        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            NAlumno.Actualizar(alumno);
            return RedirectToAction("Edit");
        }
    }
}