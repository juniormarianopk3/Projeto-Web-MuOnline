using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Services;
using MuOnlineWebMVC.Utils;

namespace MuOnlineWebMVC.Controllers
{
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RankingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string filtroAtual, string filtro, int? pagina)
        {     
            if (filtro != null)
            {
                pagina = 1;
            }
            else
            {
                filtro = filtroAtual;
            }

            ViewData["filtroAtual"] = filtro;

            var character = from charact in _dbContext.Character select charact;

            //if (!String.IsNullOrEmpty(filtro))
            //{
            //    character = character.Where(x => x.Name.Contains(filtro));
            //}

            switch (filtroAtual)
            {
                case "Resets":
                    character = character.OrderByDescending(est => est.Resets);
                    break;
                case "ResetSemanal":
                    character = character.OrderByDescending(x => x.ResetsWeek);
                    break;
                case "MasterReset":
                    character = character.OrderByDescending(x => x.MrTotal);
                    break;
                case "MasterReset Semanal":
                    character = character.OrderByDescending(x => x.MrSemanal);
                    break;
                case "PlayerKiller":
                    character = character.OrderByDescending(x => x.PkHeroTotal);
                    break;
                case "PlayerKiller Semanal":
                    character = character.OrderByDescending(x => x.ResetsWeek);
                    break;

                default:
                    character = character.OrderByDescending(est => est.Resets);
                    break;
            }

            int pageSize = 2;
            return View(await PaginatedList<Character>.CreateAsync(character.AsNoTracking(), pagina ?? 1,pageSize));
        }

    }
}