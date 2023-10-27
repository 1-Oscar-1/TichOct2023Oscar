using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC_Razor_EF.Models
{
    public class AlumnosController : Controller
    {
        EjerciciosTichEntities1 _DBContext = new EjerciciosTichEntities1();
        List<Alumnos> listAlumnos = new List<Alumnos>();
        // GET: Alumnos
        public ActionResult Index()
        {
            listAlumnos = _DBContext.Alumnos.ToList();
            return View(listAlumnos);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            Alumnos alumno = _DBContext.Alumnos.Find(id);
            return View(alumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumno)
        {
            try
            {
                _DBContext.Alumnos.Add(alumno);
                _DBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            Alumnos alumno = _DBContext.Alumnos.Find(id);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos alumno)
        {
            try
            {
                _DBContext.Entry(alumno).State = EntityState.Modified;
                _DBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            Alumnos alumno = _DBContext.Alumnos.Find(id);
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Alumnos alumno)
        {
            try
            {
                alumno = _DBContext.Alumnos.Find(id);
                _DBContext.Alumnos.Remove(alumno);
                _DBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
