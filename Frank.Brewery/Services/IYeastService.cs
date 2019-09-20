using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Frank.Brewery.Entities;

namespace Frank.Brewery.Services
{
    public interface IYeastService
    {
        Task<List<Yeast>> GetAll();
        Task<Yeast> Add(Yeast yeast);
        Task<Yeast> Update(Yeast yeast);
        Task<bool> Remove(Guid yeast);
    }
}