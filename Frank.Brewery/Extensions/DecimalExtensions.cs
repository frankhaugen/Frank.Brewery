namespace Frank.Brewery.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToPowerOf(this decimal value, int powerOf)
        {
            if (powerOf < 1) return 0.0m;
            if (powerOf == 1) return value;
            
            var result = value;

            for (int i = 1; i < powerOf; i++)
            {
                result *= value;
            }

            return result;
        }
    }
}
