using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A320FailureConsole.Models;

namespace A320FailureConsole.Controllers
{
    public class FailuresController : Controller
    {
        private A320FailureConsoleContext db = new A320FailureConsoleContext();

        // GET: Failures
        public ActionResult Index()
        {
            var failures = db.Failures.Include(f => f.ParentSystem);
            return View(failures.ToList());
        }

        // GET: Failures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Failure failure = db.Failures.Find(id);
            if (failure == null)
            {
                return HttpNotFound();
            }
            return View(failure);
        }

        // GET: Failures/Create
        public ActionResult Create()
        {
            ViewBag.ACSystemID = new SelectList(db.ACSystems, "ACSystemID", "ACSystemIDName");
            return View();
        }

        // POST: Failures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FailureID,FailureName,Description,ACSystemID,DREF0suffix,FailValue,FixValue")] Failure failure)
        {
            if (ModelState.IsValid)
            {
                db.Failures.Add(failure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ACSystemID = new SelectList(db.ACSystems, "ACSystemID", "ACSystemIDName", failure.ACSystemID);
            return View(failure);
        }

        // GET: Failures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Failure failure = db.Failures.Find(id);
            if (failure == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACSystemID = new SelectList(db.ACSystems, "ACSystemID", "ACSystemIDName", failure.ACSystemID);
            return View(failure);
        }

        // POST: Failures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FailureID,FailureName,Description,ACSystemID,DREF0suffix,FailValue,FixValue")] Failure failure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(failure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ACSystemID = new SelectList(db.ACSystems, "ACSystemID", "ACSystemIDName", failure.ACSystemID);
            return View(failure);
        }

        // GET: Failures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Failure failure = db.Failures.Find(id);
            if (failure == null)
            {
                return HttpNotFound();
            }
            return View(failure);
        }

        // POST: Failures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Failure failure = db.Failures.Find(id);
            db.Failures.Remove(failure);
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
