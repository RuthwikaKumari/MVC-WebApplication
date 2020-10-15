using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class Assignment2Controller : Controller
    {
        // GET: Assignment2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllUsers()
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var records = dxcdb.Registrations.ToList();
            return View(records);
        }
        [HttpGet]
        public ActionResult Display()
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var usernames = dxcdb.Registrations.Select(o => o.username).Distinct().ToList();
            return View(usernames);
        }
        [HttpPost]
        public ActionResult DisplayDetails(string id)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var username = dxcdb.Registrations
                .Where(o => o.username == id).ToList();
            return View(username);
        }
    }
}