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
    public class SupportListsController : Controller
    {
        private DBPodrskaEntities db = new DBPodrskaEntities();

        // GET: SupportLists
        public ActionResult Index()
        {
            var supportLists = db.SupportLists.Include(s => s.PriorityList).Include(s => s.SectionsList).Include(s => s.SeverityList).Include(s => s.StatusesList).Include(s => s.CategoryList);
            return View(supportLists.ToList());
        }

        // GET: SupportLists/Details/5
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

        // GET: SupportLists/Create
        public ActionResult Create()
        {
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName");
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName");
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName");
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name");
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName");
            
            return View();
        }

        // POST: SupportLists/Create
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

            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            return View(supportList);
        }

        // GET: SupportLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportList supportList = db.SupportLists.Find(id);
            
            Comment comment = db.Comments.Find(supportList.TicketNo);
            if (comment != null)
            {
                SupportListComment commentList = new SupportListComment()
                {
                    TicketNo = supportList.TicketNo,
                    Title = supportList.Title,
                    Status = supportList.Status,
                    Category = supportList.Status,
                    Severity = supportList.Severity,
                    Priority = supportList.Priority,
                    RaisedBy = supportList.RaisedBy,
                    RaisedOn = supportList.RaisedOn,
                    DueOn = supportList.DueOn,
                    ResolvedOn = supportList.ResolvedOn,
                    IDSectionList = supportList.IDSectionList,
                    AspNetUser = comment.AspNetUser,

                };
            }
            //System.Collections.IList list = comment.Message.ToList();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    string stg = (string)list[i];
            //    commentList.Message.Add(stg);
            //}
            if (supportList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            return View(supportList);
        }

        public JsonResult GetComments()
        {

            
            List<SupportListComments> comments = db.Comments.Select(c => new SupportListComments
            {       

                    Id = c.Id,
                    Message = c.Message,
                    AspNetUsersId = c.AspNetUser.UserName,
                    TicketNoID = c.TicketNoID,
                    UserRoleName = c.UserRoleName
            }).ToList(); 
            return Json(comments, JsonRequestBehavior.AllowGet); 
        }
        //[Authorize]
        //public JsonResult GetComments()
        //{
        //    SupportList supportListID = db.SupportLists.Find(id);
        //    List<SupportListComments> comments = db.Comments.Select(c => new SupportListComments
        //    {
        //        Id = c.Id,
        //        Message = c.Message,
        //        AspNetUsersId = c.AspNetUser.UserName,
        //        TicketNoID = c.TicketNoID
        //    }).Where(c => c.TicketNoID == id).ToList();
            
            
        //    return Json(comments, JsonRequestBehavior.AllowGet);
        //}





        // POST: SupportLists/Edit/5
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
            ViewBag.Priority = new SelectList(db.PriorityLists, "ID", "PriorityName", supportList.Priority);
            ViewBag.IDSectionList = new SelectList(db.SectionsLists, "ID", "SectionName", supportList.IDSectionList);
            ViewBag.Severity = new SelectList(db.SeverityLists, "ID", "SeverityName", supportList.Severity);
            ViewBag.Status = new SelectList(db.StatusesLists, "ID", "Name", supportList.Status);
            ViewBag.Category = new SelectList(db.CategoryLists, "ID", "CategoryName", supportList.Category);
            return View(supportList);
        }
        //public JsonResult GetComments(int? id)
        //{
        //    IEnumerable<Comment> commentList = new List<Comment>();
        //    //using (DBPodrskaEntities db = new DBPodrskaEntities())
        //    {
        //        var comment = db.Comments.Where(x => x.TicketNoID == id).ToList();
        //        commentList = comment.Select(x =>
        //                    new Comment()
        //                    {
        //                        AspNetUsersId = x.AspNetUsersId,
        //                        Id = x.Id,
        //                        Message = x.Message,
        //                        TicketNoID = x.TicketNoID
        //                    });
        //    }
        //    return Json(commentList, JsonRequestBehavior.AllowGet);

        //}


        // GET: SupportLists/Delete/5
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

        // POST: SupportLists/Delete/5
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