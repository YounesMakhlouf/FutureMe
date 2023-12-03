using FutureMe.Models;
using FutureMe.Services.EmailSender;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FutureMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            await emailSender.SendEmailAsync("salmabouabidi019@gmail.com","test","test");
            return View();
        }
    }
}
