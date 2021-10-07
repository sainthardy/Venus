using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venus.Models;
using System.Net.Mail;

namespace Venus.Controllers
{
    public class SendEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("fseiei99@gmail.com");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("fseiei99@gmail.com", "aaaaa");
            smtp.Send(mm);
            ViewBag.message = "The mail has been sent to " + em.To + " successfully.";

            return View();
        }
    }
}
