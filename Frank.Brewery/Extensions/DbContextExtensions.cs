using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Frank.Brewery.Extensions
{
    public static class DbContextExtensions
    {
        public static IEnumerable<T> AddAndSaveItems<T>(this DbContext context, IEnumerable<T> list)
        {
            var output = new List<T>();

            foreach (var item in list)
            {
                var entry = context.Add(item);
                output.Add((T)entry.Entity);
            }

            context.SaveChanges();

            return output;
        }
    }
}
