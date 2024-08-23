using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project__True_Coders_;
using Final_Project__True_Coders_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class GameController : Controller
    {

        private readonly IGameRepository repo;

        public GameController(IGameRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var gameGenresVM = new GameGenresViewModel { ModelGames = repo.GetAllGames(), ModelGenres = repo.GetAllGenres()};
            return View(gameGenresVM);
        }


        public IActionResult ViewGame(int listNum)
        {
            var gameGenresVM = new GameGenresViewModel { ModelGames = new List<Game>() {repo.GetGame(listNum)}, ModelGenres = repo.GetAllGenres() }; 
            return View(gameGenresVM);
        }

        public IActionResult UpdateGame(int listNum)
        {
            Game gm = repo.GetGame(listNum); 
            if (gm == null)
            {
                return View("GameNotFound");
            }

            return View(gm);
        }

        public IActionResult UpdateGameToDatabase(Game Game)
        {
            repo.UpdateGame(Game);

            return RedirectToAction("ViewGame", new { listNum = Game.ListNumber });
        }

        public IActionResult InsertGame()
        {
            var gm = repo.AssignGenre();

            return View(gm);

        }

        public IActionResult InsertGameToDatabase(Game gameToInsert)
        {
            repo.InsertGame(gameToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGame(Game game)
        {
            repo.DeleteGame(game);
            return RedirectToAction("Index");
        }
    }
}