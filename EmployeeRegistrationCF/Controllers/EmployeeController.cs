using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistrationCF.Models;

namespace EmployeeRegistrationCF.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

       // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create(bool isSuccess = false, string  id = null)
        {


            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");


            Employee emp = new Employee();
            ViewBag.Message = isSuccess;

            var lastemp = db.Employees.OrderByDescending(x => x.Id).FirstOrDefault();
            if (id != null)
            {
                emp = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            }
            else if (lastemp == null)
            {
                emp.Id = "EMP01";
            }
            else
            {
                var id1 = Convert.ToInt32(lastemp.Id.Substring(3, 2)) + 1;
                emp.Id = ("EMP0" + id1).ToString();
            }

            return View(emp);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, string[] hobbies)
        {
            if (ModelState.IsValid)
            {
                if (hobbies != null)
                {
                    var hobb = String.Join(",", hobbies);
                    employee.Hobbies = hobb;
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                //return RedirectToAction("Index");
                ViewBag.Message = "Record Save Successfully";
                return RedirectToAction("Create", new { isSuccess = true });
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);            
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }           
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);            
            return View(employee);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee,string[] hobbies)
        {
            if (ModelState.IsValid)
            {
                if (hobbies != null)
                {
                    var hobb = String.Join(",", hobbies);
                    employee.Hobbies = hobb;
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
