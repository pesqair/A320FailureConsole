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
    public class ACSystemsController : Controller
    {
        private A320FailureConsoleContext db = new A320FailureConsoleContext();

        // GET: ACSystems
        public ActionResult Index()
        {
            return View(db.ACSystems.ToList());
        }

        // GET: ACSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACSystem aCSystem = db.ACSystems.Find(id);
            if (aCSystem == null)
            {
                return HttpNotFound();
            }
            return View(aCSystem);
        }

        // GET: ACSystems/Create
        //[Authorize()]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACSystemID,ACSystemIDName,Description,DREF0prefix")] ACSystem aCSystem)
        {
            if (ModelState.IsValid)
            {
                db.ACSystems.Add(aCSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCSystem);
        }

        // GET: ACSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACSystem aCSystem = db.ACSystems.Find(id);
            if (aCSystem == null)
            {
                return HttpNotFound();
            }
            return View(aCSystem);
        }

        // POST: ACSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACSystemID,ACSystemIDName,Description,DREF0prefix")] ACSystem aCSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCSystem);
        }

        // GET: ACSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACSystem aCSystem = db.ACSystems.Find(id);
            if (aCSystem == null)
            {
                return HttpNotFound();
            }
            return View(aCSystem);
        }

        // POST: ACSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACSystem aCSystem = db.ACSystems.Find(id);
            db.ACSystems.Remove(aCSystem);
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
