using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyManagementApp.Models;
using Microsoft.AspNet.Identity;

namespace PropertyManagementApp.Controllers
{
    public class ResidentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> UserManager { get; set; }

        [Authorize(Roles = "Manager")]
        // GET: Residents
        public ActionResult Index()
        {
            return View(db.Residents.ToList());
        }

        [Authorize(Roles = "Resident")]
        public ActionResult Welcome()

        {
            string accountId = User.Identity.GetUserId();

            var user = from r in db.Residents
                       where (r.UserId == accountId)
                       select r;


            Resident ViewData = new Resident();
            foreach (Resident result in user)
            {
                ViewData = result;
                ViewBag.User = result.Id;
            }

            return View(ViewData);
        }

        [Authorize(Roles = "Resident")]
        public ActionResult PayRent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var residents = db.Residents.Find(id);
            if (residents == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id;
            return View(residents);
        }

        [Authorize]
        // GET: Residents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        [Authorize(Roles = "Manager")]
        // GET: Residents/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // POST: Residents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Unit,EmailAddress")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Residents.Add(resident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resident);
        }

        [Authorize]
        // GET: Residents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        [Authorize]
        // POST: Residents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Unit,EmailAddress")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resident);
        }
        
        [Authorize(Roles = "Resident")]
        // GET: Residents/EnterPaymentAmount
        public ActionResult EnterPaymentAmount(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        [Authorize(Roles = "Resident")]
        // POST: Residents/EnterPaymentAmount
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnterPaymentAmount([Bind(Include = "Id,Name,Location,Unit,EmailAddress,Rent,Payment,UserId")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resident).State = EntityState.Modified;
                db.SaveChanges();

                var id = resident.Id;
                //ViewBag.PaymentAmount = paymentAmount;

                return RedirectToAction($"MakePayment/{id}");
            }
            return View(resident);
        }

        [Authorize(Roles = "Resident")]
        public ActionResult MakePayment(int? id, Resident resident)
        {
            var payment = from p in db.Residents
                       where (p.Id == id)
                       select p;
            //Resident ViewData = new Resident();
            foreach (Resident result in payment)
            {
                //ViewData = result;
                ViewBag.Id = result.Id;
                ViewBag.Pmt = result.Payment;
                ViewBag.StripePmt = result.Payment * 100;
            }

            return View(resident);
        }

        [Authorize(Roles = "Manager")]
        // GET: Residents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }
        [Authorize(Roles = "Manager")]
        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resident resident = db.Residents.Find(id);
            db.Residents.Remove(resident);
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
