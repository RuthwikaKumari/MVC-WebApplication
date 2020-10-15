using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class Assignment3Controller : Controller
    {
        // GET: Assignment3
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployees()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployees(tbl_employee emp)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            dxcdb.tbl_employee.Add(emp);
            dxcdb.SaveChanges();
            
            return RedirectToAction("DisplayEmployees");
        }
        public ActionResult DisplayEmployees()
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var records = dxcdb.tbl_employee.ToList();
            return View(records);
        }
    }
}