using System;
using static System.Int32;

namespace Frank.Brewery.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return MinValue;
            }

        }
    }
}
