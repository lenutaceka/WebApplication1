using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext(); //s-a creat legat leg dintre controller si baza de date

        // GET: Student
        public ActionResult Index(string sortOrder, string searchString) //pag principala
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in db.Students select s; //clonam db students a.i sa nu modific db studentul intruna la fiecare sortare

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString)); //caut cu lamda expression daca last name si first name contin caracterele dupa care search eu
            }
            switch(sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc ":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default: //ordonare crescatoare, implicita
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            //return View(db.Students.ToList());//returneaza toti studentii
            return View(students.ToList()); //returneaza toti studentii sortati
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id) //detalii referitoare la studentul curent, cu id-ul id
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);//incerc sa identific studentul cu id-ul ala
            if (student == null)
            {
                return HttpNotFound();//daca nu il gaseste, exceptie 'not found'
            }
            return View(student); //daca il gaseste, returneaza detalii pt studentul ala
        }

        // GET: Student/Create
        public ActionResult Create() //primul create se intampla cand vreau sa creez o noua entitate, un nou student
        {
            return View();//metoda care incarca pagina de create
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,EnrollmentDate")] Student student) //ca user, am introdus datele in browser, se creeaza studentul, care se adauga la colectia de studenti din repository
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)//identifica studentul in baza id-ului
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) //dupa ce gasesc userul, aici il sterg
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
