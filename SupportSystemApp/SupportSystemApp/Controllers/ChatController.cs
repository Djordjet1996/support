using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SupportSystemApp.Models;

namespace SupportSystemApp.Controllers
{
   
    public class ChatController : Controller
    {
        DBPodrskaEntities db = new DBPodrskaEntities();
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StartChat(string name)
        {
            Session["user"] = name;
            return View("Chat");
        }
        //public ActionResult Chat(string msg)
        //{
        //    Message message = new Message()
        //    {
        //        Name = Session["user"] as String,
        //        Time = DateTime.Now,
        //        Content = msg,
        //    };
        //    return PartialView("Message", message);
        //}
        public ActionResult SaveComment(string message, int id)
        {
            string result = "Error! Comment is not saved!";
            if (message != null)
            {
                //SupportList sl = db.SupportLists.Find(id);
                Comment comment = new Comment();
                comment.Message = message;
                comment.AspNetUsersId = User.Identity.GetUserId();
                comment.TicketNoID = id;
                db.Comments.Add(comment);
                db.SaveChanges();
                result = "Success! Comment is saved!";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetComments(int id)
        //{
        //    IEnumerable<Comment> commentList = new List<Comment>();
        //    using (DBPodrskaEntities db = new DBPodrskaEntities())
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


    }
}