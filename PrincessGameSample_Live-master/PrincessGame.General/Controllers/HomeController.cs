using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrincessGame.DLL;
using PrincessGame.DLL.Helpers;
using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Members;
using PrincessGame.General.Models;
using PrincessGame.General.Resources;

namespace PrincessGame.General.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PrincessGameLauncher _princessGameLauncher;

        public HomeController(ILogger<HomeController> logger)
        {
            _princessGameLauncher = new PrincessGameLauncher();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int fieldHeight = 20;
            int fieldWidth = 20;
         

            var gameLauncher = new PrincessGameLauncher();

            var startData = gameLauncher.GetStartData(
                (1, 1),
                (fieldWidth - 2, fieldHeight - 2),
                35,
                fieldHeight,
                fieldWidth);

            AppResources.GameData = startData;

            return View();
        }

        [HttpPost]
        public IActionResult Index(ActionType actionType)
        {
            _princessGameLauncher.PerformGameAction(actionType, AppResources.GameData.GameField, AppResources.GameData.Player, AppResources.GameData.Bomb);

            Position playerPosition = AppResources.GameData.Player.Position;

            if (AppResources.GameData.GameField[playerPosition].Has(typeof(Princess)))
            {
                return Redirect("~/Home/WinnerPanel");
            }
            if(AppResources.GameData.Player.HealthPoints <= 0)
            {
                return Redirect("~/Home/LosePanel");
            }

            return View();
        }
       
        [HttpGet]
        public IActionResult LosePanel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WinnerPanel()
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
    }
}
