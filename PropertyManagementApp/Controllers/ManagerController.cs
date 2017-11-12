using PropertyManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementApp.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Manager
        [Authorize(Roles ="Manager")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult EmailSelector()
        {
            return View(db.Residents.ToList());
        }

        [Authorize(Roles = "Manager")]
        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // POST: Manager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Manager")]
        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Manager")]
        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        // POST: Manager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
