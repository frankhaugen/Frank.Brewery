using System;
using Frank.Brewery.DataContexts;
using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frank.Brewery.Repositories
{
    public class YeastRepository : IYeastRepository
    {
        private readonly DataContext _dataContext;

        public YeastRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Yeast>> GetAll()
        {
            return await _dataContext.Yeasts.ToListAsync();
        }

        public async Task<Yeast> Add(Yeast yeast)
        {
            var entityEntry = await _dataContext.Yeasts.AddAsync(yeast);
            await _dataContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<Yeast> Update(Yeast yeast)
        {
            var entityEntry = _dataContext.Yeasts.Update(yeast);
            await _dataContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<bool> Remove(Guid yeastId)
        {
            var yeast = await _dataContext.Yeasts.SingleAsync(y => y.Id == yeastId);
            _dataContext.Yeasts.Remove(yeast);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
