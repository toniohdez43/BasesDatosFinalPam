using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalPam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConsultaBecario(string alumno)
        {
            var list = new List<ProyectoFinalPam.Models.ConsultaBecario_Result>();
            using (var context = new ProyectoFinalPam.Models.ProyectoFinalEntities())
            {
                var info = context.ConsultaBecario(alumno);
                list = info.ToList();
            }
            return View(list);
        }
        public ActionResult ConsultaPagos(string alumno)
        {
            var list = new List<ProyectoFinalPam.Models.ConsultaPagos_Result>();
            using (var context = new ProyectoFinalPam.Models.ProyectoFinalEntities())
            {
                var info = context.ConsultaPagos(alumno);
                list = info.ToList();
            }
            return View(list);
        }
        public ActionResult ConsultaServicio(string alumno)
        {
            var list = new List<ProyectoFinalPam.Models.consultaServicio_Result>();
            using (var context = new ProyectoFinalPam.Models.ProyectoFinalEntities())
            {
                var info = context.consultaServicio(alumno);
                list = info.ToList();
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}