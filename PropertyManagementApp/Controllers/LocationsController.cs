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
    public class LocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = "Manager")]
        // GET: Locations
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public ActionResult Buildings()
        {
            return View(db.Locations.ToList());
        }


        [Authorize(Roles = "Manager")]
        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }


        [Authorize(Roles = "Manager")]
        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StreetNumber,StreetName,City,State,ZipCode,PhoneNumber,Lat,Long")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locations);
        }
        
        [Authorize(Roles = "Manager")]
        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }

        [Authorize(Roles = "Manager")]
        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StreetNumber,StreetName,City,State,ZipCode,PhoneNumber,Lat,Long")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locations);
        }

        [Authorize(Roles = "Manager")]
        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }

        [Authorize(Roles = "Manager")]
        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locations locations = db.Locations.Find(id);
            db.Locations.Remove(locations);
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
