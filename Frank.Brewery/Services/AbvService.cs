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

        public async Task<SpecificGravity> GetCorrectedGravityAsync(SpecificGravity specificGravity, decimal temperature)
        {
            var getCorrectSgTask = Task.Run(() => GetCorrectedGravity(specificGravity, temperature));
            return await getCorrectSgTask;
        }


        public SpecificGravity GetCorrectedGravity(SpecificGravity specificGravity, decimal temperature)
        {
            var correctedGravity = specificGravity.Value *
                                   ((1.00130346m - 0.000134722124m * temperature + 0.00000204052596m * temperature -
                                     0.00000000232820948m * temperature)
                                    / (1.00130346m - 0.000134722124m * 20 + 0.00000204052596m * 20 -
                                       0.00000000232820948m * 20));
            return SpecificGravity.FromGravity(correctedGravity);
        }

        //CG = corrected gravity
        //MG = measured gravity
        //TR = temperature at time of reading
        //    TC = calibration temperature of hydrometer
        //    CG = MG * ((1.00130346 – 0.000134722124 * TR + 0.00000204052596 * TR – 0.00000000232820948 * TR) / (1.00130346 – 0.000134722124 * TC + 0.00000204052596 * TC – 0.00000000232820948 * TC))
    }
}
