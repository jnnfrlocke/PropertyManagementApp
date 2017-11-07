using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagementApp.Models;

namespace PropertyManagementApp.Controllers
{
    public class VacanciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ViewVacancies()
        {
            return View(db.Vacancies.ToList());
        }

        // GET: Vacancies
        public ActionResult Index()
        {
            return View(db.Vacancies.ToList());
        }

        // GET: Vacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancies vacancies = db.Vacancies.Find(id);
            if (vacancies == null)
            {
                return HttpNotFound();
            }
            return View(vacancies);
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BuildingName,Unit,PhoneNumber")] Vacancies vacancies)
        {
            if (ModelState.IsValid)
            {
                db.Vacancies.Add(vacancies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacancies);
        }

        // GET: Vacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancies vacancies = db.Vacancies.Find(id);
            if (vacancies == null)
            {
                return HttpNotFound();
            }
            return View(vacancies);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BuildingName,Unit,PhoneNumber")] Vacancies vacancies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacancies);
        }

        // GET: Vacancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancies vacancies = db.Vacancies.Find(id);
            if (vacancies == null)
            {
                return HttpNotFound();
            }
            return View(vacancies);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacancies vacancies = db.Vacancies.Find(id);
            db.Vacancies.Remove(vacancies);
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
