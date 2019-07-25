using MuOnlineWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuOnlineWebMVC.Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace MuOnlineWebMVC.Services
{
    public class MembInfoService
    {
        private readonly ApplicationDbContext _dbContext;

        public MembInfoService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<MembInfo>> FindAllAsync()
        {
            return await _dbContext.MembInfo.ToListAsync();
        }
        public async Task InsertAsync(MembInfo obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<MembInfo> FindByIdAsync(int id)
        {
            return await _dbContext.MembInfo.FirstOrDefaultAsync(x => x.MembGuid == id);
        }
        public async Task UpdateAsync(MembInfo obj)
        {
            bool HasAny = await _dbContext.MembInfo.AnyAsync(x => x.MembGuid == obj.MembGuid);
            if (!HasAny)
            {

                throw new NotFoundExcpetion("Id not found");
            }
            try
            {
                _dbContext.Update(obj);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }


        }

        public async Task EmailExist(string email)
        {
            await _dbContext.MembInfo.AnyAsync(x => x.MailAddr.Equals(email));
        }

        }
    }

