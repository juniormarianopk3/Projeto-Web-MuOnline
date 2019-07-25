using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Services;

namespace MuOnlineWebMVC.Controllers
{
    public class RankingController : Controller
    {
        private readonly RankingService _service;

        public RankingController(RankingService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Resets()
        {
            var result = await _service.FindByResetsAsync();
            return View(result);
        }
    }
}