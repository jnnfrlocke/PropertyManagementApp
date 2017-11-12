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
    public class AvailableUnitInfoRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Manager")]
        // GET: AvailableUnitInfoRequests
        public ActionResult Index()
        {
            return View(db.AvailableUnitInfoRequests.ToList());
        }

        [Authorize(Roles = "Manager")]
        // GET: AvailableUnitInfoRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableUnitInfoRequests availableUnitInfoRequests = db.AvailableUnitInfoRequests.Find(id);
            if (availableUnitInfoRequests == null)
            {
                return HttpNotFound();
            }
            return View(availableUnitInfoRequests);
        }

        // GET: AvailableUnitInfoRequests/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: AvailableUnitInfoRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmailAddress,Subject,Body")] AvailableUnitInfoRequests availableUnitInfoRequests)
        {
            if (ModelState.IsValid)
            {
                db.AvailableUnitInfoRequests.Add(availableUnitInfoRequests);
                db.SaveChanges();

                MailGun managerMessage = new MailGun();
                managerMessage.SendAvailableUnitRequest(availableUnitInfoRequests.Name, availableUnitInfoRequests.EmailAddress, availableUnitInfoRequests.Subject, availableUnitInfoRequests.Body);

                return RedirectToAction("MessageSuccess", "Messages");
            }

            return View(availableUnitInfoRequests);
        }

        [Authorize(Roles = "Manager")]
        // GET: AvailableUnitInfoRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableUnitInfoRequests availableUnitInfoRequests = db.AvailableUnitInfoRequests.Find(id);
            if (availableUnitInfoRequests == null)
            {
                return HttpNotFound();
            }
            return View(availableUnitInfoRequests);
        }

        [Authorize(Roles = "Manager")]
        // POST: AvailableUnitInfoRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmailAddress,Subject,Body")] AvailableUnitInfoRequests availableUnitInfoRequests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availableUnitInfoRequests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availableUnitInfoRequests);
        }

        [Authorize(Roles = "Manager")]
        // GET: AvailableUnitInfoRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableUnitInfoRequests availableUnitInfoRequests = db.AvailableUnitInfoRequests.Find(id);
            if (availableUnitInfoRequests == null)
            {
                return HttpNotFound();
            }
            return View(availableUnitInfoRequests);
        }

        [Authorize(Roles = "Manager")]
        // POST: AvailableUnitInfoRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvailableUnitInfoRequests availableUnitInfoRequests = db.AvailableUnitInfoRequests.Find(id);
            db.AvailableUnitInfoRequests.Remove(availableUnitInfoRequests);
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
