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
    public class PagoController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Pago
        public ActionResult Index()
        {
            var pagoes = db.Pagoes.Include(p => p.Becario);
            return View(pagoes.ToList());
        }

        // GET: Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pago/Create
        public ActionResult Create()
        {
            ViewBag.BecadoID = new SelectList(db.Becarios, "IDBecario", "Nombre");
            return View();
        }

        // POST: Pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPago,NumeroParcialidades,MontoTotal,MontoParcialidad,BecadoID,Monto1,Monto2,Monto3,Monto4,Monto5")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pagoes.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BecadoID = new SelectList(db.Becarios, "IDBecario", "Nombre", pago.BecadoID);
            return View(pago);
        }

        // GET: Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.BecadoID = new SelectList(db.Becarios, "IDBecario", "Nombre", pago.BecadoID);
            return View(pago);
        }

        // POST: Pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPago,NumeroParcialidades,MontoTotal,MontoParcialidad,BecadoID,Monto1,Monto2,Monto3,Monto4,Monto5")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BecadoID = new SelectList(db.Becarios, "IDBecario", "Nombre", pago.BecadoID);
            return View(pago);
        }

        // GET: Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagoes.Find(id);
            db.Pagoes.Remove(pago);
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
