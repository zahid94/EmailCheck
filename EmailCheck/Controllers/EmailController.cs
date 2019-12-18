using EmailCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EmailCheck.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmailSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailSend(Email email)
        {
            email.sendMail();
            return View();
        }

    }
}