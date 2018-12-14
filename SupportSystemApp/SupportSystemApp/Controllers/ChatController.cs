using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportSystemApp.Models;

namespace SupportSystemApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult StartChat(string name)
        {
            Session["user"] = name;
            return View("Chat");
        }
        public ActionResult Chat(string msg)
        {
            Message message = new Message()
            {
                Name = Session["user"] as String,
                Time = DateTime.Now,
                Content = msg,
            };
            return PartialView("Message", message);
        }
    }
}