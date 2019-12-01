using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frank.Brewery.DataContexts;
using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;

namespace Frank.Brewery.Repositories
{
    public class RecipesRepository
    {
        private readonly DataContext _dataContext;

        public RecipesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Recipe>> Get()
        {
            return await _dataContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> Get(Guid receipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> Insert(Recipe recipe)
        {
            var entry = await _dataContext.Recipes.AddAsync(recipe);
            await _dataContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
