using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class Assignment1Controller : Controller
    {
        // GET: Assignment1
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllRegisters()
        {
            
            DXCDBEntities1 dxcdb = new DXCDBEntities1();
            var records = dxcdb.Registrations.ToList();
            
            return View(records);
        }
        [HttpGet]
        public ActionResult DisplayAllRegisters()
        {
            DXCDBEntities1 dxcdb = new DXCDBEntities1();
            var records = dxcdb.Registrations.ToList();

            HttpCookie ck_name = Request.Cookies.Get("Name");
            string Name = ck_name.Value;
            ViewData.Add("name", Name);

            return View(records);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Registration reg)
        {
            DXCDBEntities1 dxcdb = new DXCDBEntities1();
            dxcdb.Registrations.Add(reg);
            dxcdb.SaveChanges();
            HttpCookie ck_name = new HttpCookie("Name", reg.username);
            Response.Cookies.Add(ck_name);
            return RedirectToAction("DisplayAllRegisters");
        }
    }
}