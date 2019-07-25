using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuOnlineWebMVC.AutoMapper.Profiles;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Models.ViewModels;
using MuOnlineWebMVC.Models.ViewModels.PainelViewModels;

namespace MuOnlineWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RankingResets()
        {
            var character = _dbContext.Character.Where(p => p.Resets > 0);
            return View(character);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
