using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMVCApp.Models;
// For Models

namespace HelloWorldMVCApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            string msg = "Welcome to Bangalore";
            ViewData.Add("Message", msg);
            return View();
        }
        public ActionResult GetAllEmps()
        {
            //List<Employee> lstemps = new List<Employee>
            //{
            //    new Employee{Ecode=101,Ename="Ruthwika",Salary=24000,DeptId=259},
            //    new Employee{Ecode=102,Ename="Pavani",Salary=14000,DeptId=259},
            //    new Employee{Ecode=103,Ename="Rithesh",Salary=30000,DeptId=259},
            //    new Employee{Ecode=104,Ename="Snehitha",Salary=20000,DeptId=259}
            //};

            DXCDBEntities dxcdb = new DXCDBEntities();
            var records = dxcdb.tbl_employee.ToList();
            return View(records);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var record = dxcdb.tbl_employee
                .Where(o => o.ecode == id)
                .SingleOrDefault();
            
            return View(record);
        }
        bool CheckDeptId(int did)
        {
            if (did == 201 || did == 202 || did == 203)
            {
                return true;
            }
            else
                return false;
        }
        [HttpPost]
        public ActionResult Edit(tbl_employee emp)
        {
            //if(!CheckDeptId((int)emp.deptid))
            //{
            //    ModelState.AddModelError("deptid", "Department Id is Invalid, it must either 201,202,203");
            //}

            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                DXCDBEntities dxcdb = new DXCDBEntities();
                var record = dxcdb.tbl_employee
                    .Where(o => o.ecode == emp.ecode)
                    .SingleOrDefault();

                record.ename = emp.ename;
                record.salary = emp.salary;
                record.deptid = emp.deptid;

                dxcdb.SaveChanges();

                return RedirectToAction("GetAllEmps");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var record = dxcdb.tbl_employee
                .Where(o => o.ecode == id)
                .SingleOrDefault();

            dxcdb.tbl_employee.Remove(record);
            dxcdb.SaveChanges();

            return RedirectToAction("GetAllEmps");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(tbl_employee emp)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            dxcdb.tbl_employee.Add(emp);
            dxcdb.SaveChanges();

            return RedirectToAction("GetAllEmps");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var record = dxcdb.tbl_employee
                .Where(o => o.ecode == id)
                .SingleOrDefault();

            return View(record);
        }
        [HttpGet]
        public ActionResult Display()
        {
            int x = int.Parse(Request.QueryString.Get("x"));
            int y = int.Parse(Request.QueryString.Get("y"));

            ViewData.Add("x", x);
            ViewData.Add("y", y);

            ViewBag.a = 500;
            ViewBag.b = 200;

            return View();
        }
        public ActionResult GetBonus(int id)
        {
            DXCDBEntities dxcdb = new DXCDBEntities();
            var Salary = dxcdb.tbl_employee
                .Where(o => o.ecode == id)
                .Select(o => o.salary)
                .SingleOrDefault();

            var Bonus = 0.0;
            if(Salary>20000)
            {
                Bonus = 0.1 * (int)Salary;
            }
            else
            {
                Bonus = 0.2 * (int)Salary;
            }
            ViewData.Add("Bonus", Bonus);
            return PartialView("_GetBonus");
        }
        public ActionResult DisplayForm()
        {
            var cities = new List<string> { "Karimnagar", "Hyderabad", "Bangalore" };
            ViewData.Add("cities", cities);
            return View();
        }
    }
}