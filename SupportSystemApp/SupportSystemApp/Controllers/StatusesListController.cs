using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupportSystemApp.Models;

namespace SupportSystemApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StatusesListController : Controller
    {
        private DBPodrskaEntities db = new DBPodrskaEntities();

        // GET: StatusesList
        public ActionResult Index()
        {
            return View(db.StatusesLists.ToList());
        }

        // GET: StatusesList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusesList statusesList = db.StatusesLists.Find(id);
            if (statusesList == null)
            {
                return HttpNotFound();
            }
            return View(statusesList);
        }

        // GET: StatusesList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusesList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] StatusesList statusesList)
        {
            if (ModelState.IsValid)
            {
                db.StatusesLists.Add(statusesList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusesList);
        }

        // GET: StatusesList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusesList statusesList = db.StatusesLists.Find(id);
            if (statusesList == null)
            {
                return HttpNotFound();
            }
            return View(statusesList);
        }

        // POST: StatusesList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] StatusesList statusesList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusesList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusesList);
        }

        // GET: StatusesList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusesList statusesList = db.StatusesLists.Find(id);
            if (statusesList == null)
            {
                return HttpNotFound();
            }
            return View(statusesList);
        }

        // POST: StatusesList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusesList statusesList = db.StatusesLists.Find(id);
            db.StatusesLists.Remove(statusesList);
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
