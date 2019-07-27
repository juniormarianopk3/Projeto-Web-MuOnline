using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuOnlineWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Components
{
    public class TopMasterResetsHomeViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public TopMasterResetsHomeViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var character = await _dbContext.Character.OrderByDescending(p => p.MrTotal).FirstOrDefaultAsync();
            return View(character);
        }
    }
}
