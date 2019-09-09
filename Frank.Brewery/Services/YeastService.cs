using Frank.Brewery.Entities;
using Frank.Brewery.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frank.Brewery.Services
{
    public class YeastService : IYeastService
    {
        private readonly IYeastRepository _yeastRepository;

        public YeastService(IYeastRepository yeastRepository)
        {
            _yeastRepository = yeastRepository;
        }

        public async Task<List<Yeast>> GetAll()
        {
            return await _yeastRepository.GetAll();
        }

        public async Task<Yeast> Add(Yeast yeast)
        {
            return await _yeastRepository.Add(yeast);
        }

        public async Task<Yeast> Update(Yeast yeast)
        {
            return await _yeastRepository.Update(yeast);
        }

        public async Task<Yeast> Remove(Yeast yeast)
        {
            return await _yeastRepository.Remove(yeast);
        }
    }
}
