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
    public class SectionsListController : Controller
    {
        private DBPodrskaEntities db = new DBPodrskaEntities();

        // GET: SectionsList
        public ActionResult Index()
        {
            return View(db.SectionsLists.ToList());
        }

        // GET: SectionsList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionsList sectionsList = db.SectionsLists.Find(id);
            if (sectionsList == null)
            {
                return HttpNotFound();
            }
            return View(sectionsList);
        }

        // GET: SectionsList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionsList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SectionName,Description")] SectionsList sectionsList)
        {
            if (ModelState.IsValid)
            {
                db.SectionsLists.Add(sectionsList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sectionsList);
        }

        // GET: SectionsList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionsList sectionsList = db.SectionsLists.Find(id);
            if (sectionsList == null)
            {
                return HttpNotFound();
            }
            return View(sectionsList);
        }

        // POST: SectionsList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SectionName,Description")] SectionsList sectionsList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionsList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sectionsList);
        }

        // GET: SectionsList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionsList sectionsList = db.SectionsLists.Find(id);
            if (sectionsList == null)
            {
                return HttpNotFound();
            }
            return View(sectionsList);
        }

        // POST: SectionsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionsList sectionsList = db.SectionsLists.Find(id);
            db.SectionsLists.Remove(sectionsList);
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
