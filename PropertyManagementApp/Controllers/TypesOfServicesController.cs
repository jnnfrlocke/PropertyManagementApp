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
    public class TypesOfServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypesOfServices
        public ActionResult Index()
        {
            return View(db.TypesOfServices.ToList());
        }

        // GET: TypesOfServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesOfService typesOfService = db.TypesOfServices.Find(id);
            if (typesOfService == null)
            {
                return HttpNotFound();
            }
            return View(typesOfService);
        }

        // GET: TypesOfServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypesOfServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Landscaping,SnowRemoval,Pavement,Exterior,Plumbing,Electrical,Appliances,Painting,General,HVAC,Roofing,Windows,Cleaning,Carpet,DrywallInsulation,Doors")] TypesOfService typesOfService)
        {
            if (ModelState.IsValid)
            {
                db.TypesOfServices.Add(typesOfService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typesOfService);
        }

        // GET: TypesOfServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesOfService typesOfService = db.TypesOfServices.Find(id);
            if (typesOfService == null)
            {
                return HttpNotFound();
            }
            return View(typesOfService);
        }

        // POST: TypesOfServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Landscaping,SnowRemoval,Pavement,Exterior,Plumbing,Electrical,Appliances,Painting,General,HVAC,Roofing,Windows,Cleaning,Carpet,DrywallInsulation,Doors")] TypesOfService typesOfService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesOfService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typesOfService);
        }

        // GET: TypesOfServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesOfService typesOfService = db.TypesOfServices.Find(id);
            if (typesOfService == null)
            {
                return HttpNotFound();
            }
            return View(typesOfService);
        }

        // POST: TypesOfServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypesOfService typesOfService = db.TypesOfServices.Find(id);
            db.TypesOfServices.Remove(typesOfService);
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
