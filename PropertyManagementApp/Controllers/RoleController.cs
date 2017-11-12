using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManagementApp.Models;

namespace A11_RBS.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}