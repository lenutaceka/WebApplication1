using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            var data = from student in db.Students //plec de la entitate student din colectia mea de db.students
                       group student by student.EnrollmentDate into dateGroup //rezul groupeaza-le dupa enrollment date-ul lor in dateGrou
                       select new EnrollmentDateGroup() //din datele groupate dupa enrollment date, extragem data si nr stude
                       { 
                           EnrollmentDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };


            //return View();
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //controll la garbage collection
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}