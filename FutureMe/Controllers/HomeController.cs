﻿using FutureMe.Models;
using FutureMe.Services.LetterSaver;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FutureMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILetterSaverService _letterSaverService;

        public HomeController(ILogger<HomeController> logger,ILetterSaverService letterSaverService)
        {
            _logger = logger;
            _letterSaverService = letterSaverService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveLetter(string content, DateTime sendingDate, bool IsPublic, string Email, string Title, int UserId)
        {
            if (!ModelState.IsValid)
            {
                return (RedirectToAction(nameof(Index)));
            }

            _letterSaverService.saveLetter(content, sendingDate, IsPublic, Email, Title, 1); //change 1 to UserId once identity is included
            //TODO:Add success message to view
            return (RedirectToAction(nameof(Index)));


        }


    }
}
