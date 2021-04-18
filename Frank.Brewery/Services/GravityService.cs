using BeerMath;
using Frank.Brewery.Extensions;
using System.Threading.Tasks;

namespace Frank.Brewery.Services
{
    public class GravityService
    {
        public async Task<SpecificGravity> GetCorrectedGravityAsync(SpecificGravity specificGravity, decimal temperature)
        {
            var getCorrectSgTask = Task.Run(() => GetCorrectedGravity(specificGravity, temperature));
            return await getCorrectSgTask;
        }

        public SpecificGravity GetCorrectedGravity(SpecificGravity specificGravity, decimal temperature)
        {
            var calibrationTemperature = 20.0m;
            var farenheightTemperature = (temperature * 9 / 5) + 32;
            var farenheightCalibrationTemperature = (calibrationTemperature * 9 / 5) + 32;

            var correctedGravity =
                specificGravity.Value
                * (1.00130346m
                    - (0.000134722124m * farenheightTemperature)
                    + (0.00000204052596m * farenheightTemperature.ToPowerOf(2))
                    - (0.00000000232820948m * farenheightTemperature.ToPowerOf(3)))
                / (1.00130346m
                    - (0.000134722124m * farenheightCalibrationTemperature)
                    + (0.00000204052596m * farenheightCalibrationTemperature.ToPowerOf(2))
                    - (0.00000000232820948m * farenheightCalibrationTemperature.ToPowerOf(3)));

            return SpecificGravity.FromGravity(correctedGravity);
        }
    }
}
