using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Views
{
    public class EmployeesController : Controller
    {
        private M52Entities db = new M52Entities();

        // GET: Employees
		[Authorize]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Job_Titles);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
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

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Department_Name");
            ViewBag.Job_Title_ID = new SelectList(db.Job_Titles, "Job_Title_ID", "Tob_Title");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,First_Name,Last_Name,Email_Address,Phone_Number,Department_ID,Job_Title_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Department_Name", employee.Department_ID);
            ViewBag.Job_Title_ID = new SelectList(db.Job_Titles, "Job_Title_ID", "Tob_Title", employee.Job_Title_ID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Department_Name", employee.Department_ID);
            ViewBag.Job_Title_ID = new SelectList(db.Job_Titles, "Job_Title_ID", "Tob_Title", employee.Job_Title_ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,First_Name,Last_Name,Email_Address,Phone_Number,Department_ID,Job_Title_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department_ID = new SelectList(db.Departments, "Department_ID", "Department_Name", employee.Department_ID);
            ViewBag.Job_Title_ID = new SelectList(db.Job_Titles, "Job_Title_ID", "Tob_Title", employee.Job_Title_ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
