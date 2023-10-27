using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace Presentacion.Controllers
{
    public class EstatusAlumnosController : Controller
    {
        NEstatusAlumnos metodosEstatus = new NEstatusAlumnos();
        // GET: EstatusAlumnos
        public ActionResult Index()
        {
            return View(metodosEstatus.Consultar());
        }

        // GET: EstatusAlumnos/Details/5
        public ActionResult Details(int id)
        {
            return View(metodosEstatus.Consultar(id));
        }

        // GET: EstatusAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusAlumnos/Create
        [HttpPost]
        public ActionResult Create(EstatusAlumnos estatus)
        {
            try
            {
                // TODO: Add insert logic here
                metodosEstatus.Agregar(estatus);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(metodosEstatus.Consultar(id));
        }

        // POST: EstatusAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstatusAlumnos estatus)
        {
            try
            {
                // TODO: Add update logic here
                metodosEstatus.Actualizar(estatus, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(metodosEstatus.Consultar(id));
        }

        // POST: EstatusAlumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EstatusAlumnos alumno)
        {
            try
            {
                // TODO: Add delete logic here
                metodosEstatus.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _EliminarAjax(int id)
        {
            ViewBag.id = id;
            return PartialView(metodosEstatus.Consultar(id));
        }
    }
}
