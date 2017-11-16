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
using PropertyManagementApp.Properties;
using PagedList;
using System.Data.Entity.Infrastructure;


namespace PropertyManagementApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class PreferredServiceProvidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_asc" : "";
            ViewBag.CompanySortParm = sortOrder == "Company" ? "company_desc" : "Company";
            ViewBag.PreApprovedSortParm = String.IsNullOrEmpty(sortOrder) ? "preApproved_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var providers = from p in db.PreferredServiceProviders
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                providers = providers.Where(p => p.Type.Contains(searchString)
                                       || p.Type.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "type_asc":
                    providers = providers.OrderBy(p => p.Type);
                    break;
                case "company_desc":
                    providers = providers.OrderBy(p => p.Company);
                    break;
                case "preApproved_desc":
                    providers = providers.OrderByDescending(p => p.PreApproved);
                    break;
                default:
                    providers = providers.OrderBy(p => p.Id);
                    break;
            }
            return View(providers.ToList());
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
