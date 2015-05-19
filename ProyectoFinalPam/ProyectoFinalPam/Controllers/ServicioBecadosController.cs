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
    public class ServicioBecadosController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: ServicioBecados
        public ActionResult Index()
        {
            var servicioBecadoes = db.ServicioBecadoes.Include(s => s.Becario).Include(s => s.Organizacion);
            return View(servicioBecadoes.ToList());
        }

        // GET: ServicioBecados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBecado servicioBecado = db.ServicioBecadoes.Find(id);
            if (servicioBecado == null)
            {
                return HttpNotFound();
            }
            return View(servicioBecado);
        }

        // GET: ServicioBecados/Create
        public ActionResult Create()
        {
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre");
            ViewBag.IDOrg = new SelectList(db.Organizacions, "IDOrg", "Nombre");
            return View();
        }

        // POST: ServicioBecados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOrg,IDBecado,Dias,HorarioInicio,HorarioFin,Actividades,FechaInicio,FechaFin")] ServicioBecado servicioBecado)
        {
            if (ModelState.IsValid)
            {
                db.ServicioBecadoes.Add(servicioBecado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", servicioBecado.IDBecado);
            ViewBag.IDOrg = new SelectList(db.Organizacions, "IDOrg", "Nombre", servicioBecado.IDOrg);
            return View(servicioBecado);
        }

        // GET: ServicioBecados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBecado servicioBecado = db.ServicioBecadoes.Find(id);
            if (servicioBecado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", servicioBecado.IDBecado);
            ViewBag.IDOrg = new SelectList(db.Organizacions, "IDOrg", "Nombre", servicioBecado.IDOrg);
            return View(servicioBecado);
        }

        // POST: ServicioBecados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOrg,IDBecado,Dias,HorarioInicio,HorarioFin,Actividades,FechaInicio,FechaFin")] ServicioBecado servicioBecado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicioBecado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", servicioBecado.IDBecado);
            ViewBag.IDOrg = new SelectList(db.Organizacions, "IDOrg", "Nombre", servicioBecado.IDOrg);
            return View(servicioBecado);
        }

        // GET: ServicioBecados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBecado servicioBecado = db.ServicioBecadoes.Find(id);
            if (servicioBecado == null)
            {
                return HttpNotFound();
            }
            return View(servicioBecado);
        }

        // POST: ServicioBecados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioBecado servicioBecado = db.ServicioBecadoes.Find(id);
            db.ServicioBecadoes.Remove(servicioBecado);
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
