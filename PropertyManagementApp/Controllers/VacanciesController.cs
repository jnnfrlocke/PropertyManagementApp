using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagementApp.Models;
using PropertyManagementApp.Apis;

namespace PropertyManagementApp.Controllers
{
    public class VacanciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ViewVacancies()
        {
            return View(db.Vacancies.ToList());
        }

        public ActionResult Maps(int? id)
        {
            var vacancy = from vac in db.Vacancies
                             where (vac.Id == id)
                             select vac;

            Vacancies viewData = new Vacancies();
            foreach (Vacancies result in vacancy)
            {
                viewData = result;
            }

            GoogleMaps newMap = new GoogleMaps();

            var latLng = newMap.GetVacantFormattedUrl(viewData.StreetNumber, viewData.StreetName, viewData.City, viewData.State, viewData.ZipCode);

            ViewBag.Lat = latLng[0];
            ViewBag.Long = latLng[1];

            return View(viewData);
        }

        [Authorize(Roles = "Manager")]
        // GET: Vacancies
        public ActionResult Index()
        {
            return View(db.Vacancies.ToList());
        }

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
        // GET: Vacancies/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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
