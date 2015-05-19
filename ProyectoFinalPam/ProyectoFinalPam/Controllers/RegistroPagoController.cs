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
    public class RegistroPagoController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: RegistroPago
        public ActionResult Index()
        {
            var registroPagoes = db.RegistroPagoes.Include(r => r.Becario);
            return View(registroPagoes.ToList());
        }
        

        // GET: RegistroPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagoes.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            return View(registroPago);
        }

        // GET: RegistroPago/Create
        public ActionResult Create()
        {
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre");
            return View();
        }

        // POST: RegistroPago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRegistroPago,IDBecado,ClaveCat,Pago1,FechaPago1,Pago2,FechaPago2,Pago3,FechaPago3,Pago4,FechaPago4,Pago5,FechaPago5")] RegistroPago registroPago)
        {
            if (ModelState.IsValid)
            {
                db.RegistroPagoes.Add(registroPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", registroPago.IDBecado);
            return View(registroPago);
        }

        // GET: RegistroPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagoes.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", registroPago.IDBecado);
            return View(registroPago);
        }

        // POST: RegistroPago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRegistroPago,IDBecado,ClaveCat,Pago1,FechaPago1,Pago2,FechaPago2,Pago3,FechaPago3,Pago4,FechaPago4,Pago5,FechaPago5")] RegistroPago registroPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBecado = new SelectList(db.Becarios, "IDBecario", "Nombre", registroPago.IDBecado);
            return View(registroPago);
        }

        // GET: RegistroPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagoes.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            return View(registroPago);
        }

        // POST: RegistroPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroPago registroPago = db.RegistroPagoes.Find(id);
            db.RegistroPagoes.Remove(registroPago);
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
