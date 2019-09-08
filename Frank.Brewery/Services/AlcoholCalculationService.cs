using BeerMath;
using BeerMath.Convenient;
using BeerMath.Fluent;

namespace Frank.Brewery.Services
{
    public class AlcoholCalculationService
    {



        
        

        public Abv GetAbv(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            return Abv.FromOgFg(originalGravity, finalGravity);
        }

        public Abv GetAbvWithTemperatureOffset(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            Ibu ibu = new Ibu(1.1m);
            

            return Abv.FromOgFg(originalGravity, finalGravity);
        }
    }
}
