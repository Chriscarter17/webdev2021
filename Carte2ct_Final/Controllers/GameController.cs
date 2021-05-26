using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carte2ct_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carte2ct_Final.Controllers
{
    public class GameController : Controller
    {

        private GameContext context { get; set; }

        public GameController(GameContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Games());

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var game = context.Games.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(Games game)
        {
            if (ModelState.IsValid)
            {
                if (game.GameId == 0)
                    context.Games.Add(game);
                else
                    context.Games.Update(game);
                context.SaveChanges();
                return RedirectToAction("VG", "Home");
            }
            else
            {
                ViewBag.Action = (game.GameId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                return View(game);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = context.Games.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(Games game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
            return RedirectToAction("VG", "Home");
        }
    }
}
