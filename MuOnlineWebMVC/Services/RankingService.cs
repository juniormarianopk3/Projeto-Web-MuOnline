using Microsoft.EntityFrameworkCore;
using MuOnlineWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Services
{
    public class RankingService
    {
        private readonly ApplicationDbContext _dbContext;

        public RankingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Character>> FindByResetsAsync()
        {
            var result = from obj in _dbContext.Character select obj;

            return await
                result
                .OrderByDescending(p => p.Resets)
                .ToListAsync();


        }
        public async Task<List<Character>> FindByResetsWeekAsync()
        {
            var result = from obj in _dbContext.Character select obj;

            return await
                result
                .OrderByDescending(p => p.ResetsWeek)
                .ToListAsync();

        }
    }
}
