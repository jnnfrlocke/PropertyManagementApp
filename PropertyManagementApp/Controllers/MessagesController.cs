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
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body,RecipientsUnit")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messages);
        }

        // GET: Messages/SendToManager
        public ActionResult SendToManager()
        {
            //Messages model = new Messages();
            return View();
        }

        // POST: Messages/SendToManager
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendToManager([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();

                MailGun managerMessage = new MailGun();
                managerMessage.SendToSingleEmail("hello@jenniferlocke.work", messages.Subject, messages.Body, messages.Resident, messages.Unit, messages.BuildingName);
                
                return RedirectToAction("MessageSuccess");
            }

            return View(messages);
        }

        // GET: Messages/SendFromMgrToResident
        public ActionResult SendMessageFromManagerToResident()
        {
            //Messages model = new Messages();
            return View();
        }

        // POST: Messages/SendFromMgrToResident
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessageFromManagerToResident([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();

                string residentEmail = null;

                var residentEmailQuery = from rm in db.Residents
                                    where (rm.Name == messages.Resident)
                                    select rm.EmailAddress;
                
                foreach (string result in residentEmailQuery)
                {
                    residentEmail = result;
                }

                MailGun managerMessageToResident = new MailGun();
                managerMessageToResident.SendFromMgrToResident(residentEmail, messages.Subject, messages.Body, messages.Resident);

                return RedirectToAction("MessageSuccess");
            }

            return View(messages);
        }

        // GET: Messages/SendFromMgrToBuilding
        public ActionResult SendFromManagerToBuilding()
        {
            //Messages model = new Messages();
            return View();
        }

        // POST: Messages/SendFromMgrToBuilding
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendFromManagerToBuilding([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();

                string residentEmail = null;

                var buildingQuery = from rm in db.Residents
                                         where (rm.Location == messages.BuildingName)
                                         select rm.EmailAddress;

                foreach (string result in buildingQuery)
                {
                    residentEmail = result;
                    MailGun managerMessageToResident = new MailGun();
                    managerMessageToResident.SendFromMgrToBuilding(residentEmail, messages.Subject, messages.Body, messages.BuildingName);
                }

                return RedirectToAction("MessageSuccess");
            }

            return View(messages);
        }

        public ActionResult MessageSuccess()
        {
            return View();
        }


        // GET: Messages/SendFromResidentToResidentt
        public ActionResult SendFromResidentToResident()
        {
            //Messages model = new Messages();
            return View();
        }

        // POST: Messages/SendFromResidentToResident
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendFromResidentToResident([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body,RecipientsUnit")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();

                string residentEmail = null;
                string sendersEmail = null;

                var residentEmailQuery = from rm in db.Residents
                                         where ((rm.Unit == messages.RecipientsUnit) && (rm.Location == messages.BuildingName))
                                         select rm.EmailAddress;
                
                foreach (string result in residentEmailQuery)
                {
                    residentEmail = result;
                }
                
                var sendersEmailQuery = from se in db.Residents
                                        where ((se.Unit == messages.Unit) && (se.Location == messages.BuildingName))
                                        select se.EmailAddress;
                foreach (string result in sendersEmailQuery)
                {
                    sendersEmail = result;
                }

                MailGun managerMessageToResident = new MailGun();
                managerMessageToResident.SendFromResidentToResident(residentEmail, messages.Subject, messages.Body, messages.Resident, messages.BuildingName, messages.Unit, sendersEmail);


                return RedirectToAction("MessageSuccess");
            }

            return View(messages);
        }



        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Resident,BuildingName,Unit,Subject,Body,RecipientsUnit")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messages);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messages messages = db.Messages.Find(id);
            db.Messages.Remove(messages);
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
