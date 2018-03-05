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
    public class Job_TitleController : Controller
    {
        private M52Entities db = new M52Entities();

		// GET: Job_Title
		[Authorize]
		public ActionResult Index()
        {
            return View(db.Job_Titles.ToList());
        }

        // GET: Job_Title/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Title job_Title = db.Job_Titles.Find(id);
            if (job_Title == null)
            {
                return HttpNotFound();
            }
            return View(job_Title);
        }

        // GET: Job_Title/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job_Title/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Job_Title_ID,Tob_Title")] Job_Title job_Title)
        {
            if (ModelState.IsValid)
            {
                db.Job_Titles.Add(job_Title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job_Title);
        }

        // GET: Job_Title/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Title job_Title = db.Job_Titles.Find(id);
            if (job_Title == null)
            {
                return HttpNotFound();
            }
            return View(job_Title);
        }

        // POST: Job_Title/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Job_Title_ID,Tob_Title")] Job_Title job_Title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job_Title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job_Title);
        }

        // GET: Job_Title/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Title job_Title = db.Job_Titles.Find(id);
            if (job_Title == null)
            {
                return HttpNotFound();
            }
            return View(job_Title);
        }

        // POST: Job_Title/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job_Title job_Title = db.Job_Titles.Find(id);
            db.Job_Titles.Remove(job_Title);
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
