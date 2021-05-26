using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Carte2ct_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Carte2ct_Final.Controllers
{
    public class HomeController : Controller
    {
        private GameContext context { get; set; }

        public HomeController(GameContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult FavGames()
        {
            return View();
        }

        public IActionResult Sports()
        {
            return View();
        }

        public IActionResult FunFacts()
        {
            return View();
        }

        public IActionResult VG()
        {
            var Games = context.Games
                .Include(m => m.Genre)
                .OrderBy(m => m.Name)
                .ToList();
            return View(Games);
        }


    }
}
