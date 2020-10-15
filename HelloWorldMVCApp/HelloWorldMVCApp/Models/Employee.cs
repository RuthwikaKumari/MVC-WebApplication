using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVCApp.Models
{
    public class Employee
    {
        public int Ecode { get; set; }
        public string Ename { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
    }
}