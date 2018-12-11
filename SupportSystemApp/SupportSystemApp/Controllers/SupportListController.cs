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
    public class SupportListController : Controller
    {
        private DBPodrskaEntities db = new DBPodrskaEntities();

        // GET: SupportList
        public ActionResult Index()
        {
            var supportLists = db.SupportLists.Include(s => s.CategoryList).Include(s => s.PriorityList).Include(s => s.SectionsList).Include(s => s.SeverityList).Include(s => s.StatusesList).Include(s => s.AspNetUsers);
            return View(supportLists.ToList());
        }

        // GET: SupportList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportList supportList = db.SupportLists.Find(id);
            if (supportList == null)
            {
                return HttpNotFound();
            }
            return View(supportList);
        }

        // GET: SupportList/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName");
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName");
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName");
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName");
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name");
            ViewBag.RaisedBy = new SelectList(db.AspNetUsers, "ID", "Name");
            return View();
        }

        // POST: SupportList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketNo,Title,Status,Category,Severity,Priority,RaisedBy,RaisedOn,DueOn,ResolvedOn,IDSectionList")] SupportList supportList)
        {
            if (ModelState.IsValid)
            {
                db.SupportLists.Add(supportList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.RaisedBy = new SelectList(db.AspNetUsers, "ID", "Name", supportList.RaisedBy);
            return View(supportList);
        }

        // GET: SupportList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportList supportList = db.SupportLists.Find(id);
            if (supportList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.RaisedBy = new SelectList(db.AspNetUsers, "ID", "Name", supportList.RaisedBy);
            return View(supportList);
        }

        // POST: SupportList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketNo,Title,Status,Category,Severity,Priority,RaisedBy,RaisedOn,DueOn,ResolvedOn,IDSectionList")] SupportList supportList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.RaisedBy = new SelectList(db.AspNetUsers, "ID", "Name", supportList.RaisedBy);
            return View(supportList);
        }

        // GET: SupportList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportList supportList = db.SupportLists.Find(id);
            if (supportList == null)
            {
                return HttpNotFound();
            }
            return View(supportList);
        }

        // POST: SupportList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportList supportList = db.SupportLists.Find(id);
            db.SupportLists.Remove(supportList);
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
