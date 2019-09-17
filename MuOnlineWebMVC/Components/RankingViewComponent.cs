using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Components
{
    public class RankingViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public RankingViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ordem,string filtroAtual,string filtro,int? pagina)
        {

            ViewData["ordemAtual"] = ordem;
            ViewData["NomeParm"] = String.IsNullOrEmpty(ordem) ? "nome_desc" : "";
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
                            

            if (!String.IsNullOrEmpty(filtro))
            {
                character = character.Where(x => x.Name.Contains(filtro));
            }

            switch (ordem)
            {
                case "nome_desc":
                    character = character.OrderByDescending(est => est.Name);
                    break;
                default:
                    character = character.OrderByDescending(est => est.Resets);
                    break;
            }

            int pageSize = 1;
            return View(await PaginatedList<Character>.CreateAsync(character.AsNoTracking(), pagina ?? 1, pageSize));
        }
    }
}
