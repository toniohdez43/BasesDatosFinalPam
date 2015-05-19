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
    public class BecariosController : Controller
    {
        private ProyectoFinalEntities db = new ProyectoFinalEntities();

        // GET: Becarios
        public ActionResult Index()
        {
            var becarios = db.Becarios.Include(b => b.Categoria).Include(b => b.Escuela).Include(b => b.Tutor);
            return View(becarios.ToList());
        }
        public ActionResult ConsultaAlumno()
        {
            var list = new List<ProyectoFinalPam.Models.ConsultaAlumno_Result>();
            var context = new ProyectoFinalPam.Models.ProyectoFinalEntities();
            var info = context.ConsultaAlumno("");
            list = info.ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: Becarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becario becario = db.Becarios.Find(id);
            if (becario == null)
            {
                return HttpNotFound();
            }
            return View(becario);
        }

        // GET: Becarios/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "ClaveCat");
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Escuela1");
            ViewBag.IDTutor = new SelectList(db.Tutors, "IDTutor", "Nombre");
            return View();
        }

        // POST: Becarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBecario,IDTutor,IDCategoria,IDEscuela,Nombre,ApellidoP,ApellidoM,FechaNacimiento,GradoEscolar,Promedio,Foto")] Becario becario, RegistroPago registroPago, Pago pago)
        {
            if (ModelState.IsValid)
            {
                registroPago.ClaveCat = db.Categorias.FirstOrDefault(a => a.IDCategoria == becario.IDCategoria).ClaveCat;
                pago.MontoTotal = db.Categorias.FirstOrDefault(a=>a.IDCategoria == becario.IDCategoria).Monto;
                db.Pagoes.Add(pago);
                db.RegistroPagoes.Add(registroPago); 
                db.Becarios.Add(becario);
                db.SaveChanges();
                registroPago.IDBecado = becario.IDBecario;
                pago.BecadoID = becario.IDBecario;
                db.Entry(registroPago).State = EntityState.Modified;
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();             
                return RedirectToAction("Index");
                
               
             
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "ClaveCat", becario.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Escuela1", becario.IDEscuela);
            ViewBag.IDTutor = new SelectList(db.Tutors, "IDTutor", "Nombre", becario.IDTutor);
            return View(becario);
        }

        // GET: Becarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becario becario = db.Becarios.Find(id);
            if (becario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "ClaveCat", becario.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Escuela1", becario.IDEscuela);
            ViewBag.IDTutor = new SelectList(db.Tutors, "IDTutor", "Nombre", becario.IDTutor);
            return View(becario);
        }

        // POST: Becarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBecario,IDTutor,IDCategoria,IDEscuela,Nombre,ApellidoP,ApellidoM,FechaNacimiento,GradoEscolar,Promedio,Foto")] Becario becario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(becario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "ClaveCat", becario.IDCategoria);
            ViewBag.IDEscuela = new SelectList(db.Escuelas, "IDEscuela", "Escuela1", becario.IDEscuela);
            ViewBag.IDTutor = new SelectList(db.Tutors, "IDTutor", "Nombre", becario.IDTutor);
            return View(becario);
        }

        // GET: Becarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becario becario = db.Becarios.Find(id);
            if (becario == null)
            {
                return HttpNotFound();
            }
            return View(becario);
        }

        // POST: Becarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Becario becario = db.Becarios.Find(id);
            db.Becarios.Remove(becario);
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
