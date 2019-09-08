using BeerMath;
using System.Threading.Tasks;

namespace Frank.Brewery.Services
{
    public class AbvService
    {
        public async Task<Abv> GetAbvAsync(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            var getAbvTask = Task.Run(() => GetAbv(originalGravity, finalGravity));
            return await getAbvTask;
        }
        
        public Abv GetAbv(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            return Abv.FromOgFg(originalGravity, finalGravity);
        }
    }
}
