using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalPam.Models;

namespace ProyectoFinalPam.Controllers
{
    public class EscuelaController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Escuela
        public ActionResult Index()
        {
            return View(db.Escuelas.ToList());
        }

        // GET: Escuela/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuelas.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // GET: Escuela/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escuela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEscuela,Escuela1,Direccion,Telefono")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Escuelas.Add(escuela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escuela);
        }

        // GET: Escuela/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuelas.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEscuela,Escuela1,Direccion,Telefono")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escuela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escuela);
        }

        // GET: Escuela/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuelas.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escuela escuela = db.Escuelas.Find(id);
            db.Escuelas.Remove(escuela);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
