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
    public class ServiceRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Manager")]
        // GET: ServiceRequests
        public ActionResult Index()
        {
            return View(db.ServiceRequests.ToList());
        }

        [Authorize(Roles = "Manager")]
        // GET: ServiceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequests serviceRequests = db.ServiceRequests.Find(id);
            if (serviceRequests == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequests);
        }

        [Authorize]
        // GET: ServiceRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: ServiceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Unit,TypeOfService,Details,Urgency,DateSubmitted,ContractorUsed,FollowUpNeeded,Completed,DateCompleted")] ServiceRequests serviceRequests)
        {
            if (ModelState.IsValid)
            {
                db.ServiceRequests.Add(serviceRequests);
                db.SaveChanges();
                
                MailGun managerMessage = new MailGun();
                managerMessage.SendServiceRequest("hello@jenniferlocke.work", serviceRequests.Name, serviceRequests.Location, serviceRequests.Unit, serviceRequests.TypeOfService, serviceRequests.Details, serviceRequests.Urgency, serviceRequests.DateSubmitted);

                return RedirectToAction("Success");
            }

            return View(serviceRequests);
        }

        [Authorize]
        //Service Request was created successfully
        public ActionResult Success()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // GET: ServiceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequests serviceRequests = db.ServiceRequests.Find(id);
            if (serviceRequests == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequests);
        }

        [Authorize(Roles = "Manager")]
        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,TypeOfService,Details,Urgency,DateSubmitted,ContractorUsed,FollowUpNeeded,Completed,DateCompleted")] ServiceRequests serviceRequests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceRequests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceRequests);
        }

        [Authorize(Roles = "Manager")]
        // GET: ServiceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequests serviceRequests = db.ServiceRequests.Find(id);
            if (serviceRequests == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequests);
        }

        [Authorize(Roles = "Manager")]
        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceRequests serviceRequests = db.ServiceRequests.Find(id);
            db.ServiceRequests.Remove(serviceRequests);
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
