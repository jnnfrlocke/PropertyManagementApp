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
    public class PreferredServiceProvidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreferredServiceProviders
        public ActionResult Index()
        {
            return View(db.PreferredServiceProviders.ToList());
        }

        // GET: PreferredServiceProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreferredServiceProviders preferredServiceProviders = db.PreferredServiceProviders.Find(id);
            if (preferredServiceProviders == null)
            {
                return HttpNotFound();
            }
            return View(preferredServiceProviders);
        }

        // GET: PreferredServiceProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreferredServiceProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,PreApproved,Company,Contact,OfficePhone,MobilePhone,Email,StreetAddress,City,State,ZipCode,Website")] PreferredServiceProviders preferredServiceProviders)
        {
            if (ModelState.IsValid)
            {
                db.PreferredServiceProviders.Add(preferredServiceProviders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preferredServiceProviders);
        }

        // GET: PreferredServiceProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreferredServiceProviders preferredServiceProviders = db.PreferredServiceProviders.Find(id);
            if (preferredServiceProviders == null)
            {
                return HttpNotFound();
            }
            return View(preferredServiceProviders);
        }

        // POST: PreferredServiceProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,PreApproved,Company,Contact,OfficePhone,MobilePhone,Email,StreetAddress,City,State,ZipCode,Website")] PreferredServiceProviders preferredServiceProviders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preferredServiceProviders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preferredServiceProviders);
        }

        // GET: PreferredServiceProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreferredServiceProviders preferredServiceProviders = db.PreferredServiceProviders.Find(id);
            if (preferredServiceProviders == null)
            {
                return HttpNotFound();
            }
            return View(preferredServiceProviders);
        }

        // POST: PreferredServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreferredServiceProviders preferredServiceProviders = db.PreferredServiceProviders.Find(id);
            db.PreferredServiceProviders.Remove(preferredServiceProviders);
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
