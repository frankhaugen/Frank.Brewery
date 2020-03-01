using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Frank.Brewery.DataContexts;
using Frank.Brewery.Entities;
using Frank.Brewery.Enums;
using Microsoft.EntityFrameworkCore;

namespace Frank.Brewery.Tests
{
    public class DatabaseConstructor
    {
        private readonly Fixture _fixture = new Fixture();
        public DataContext DataContext;

        public DatabaseConstructor()
        {
            DataContext = TestDatabase.DataContext;


            var hops = AddItems(_fixture.OmitRecursion().CreateMany<Hop>());
            var fermentables = AddItems(_fixture.OmitRecursion().CreateMany<Fermentable>());
            var yests = AddItems(_fixture.OmitRecursion().CreateMany<Yeast>());

            var step = DataContext.Add(new Recipe()
            {

                Name = "Beer",
                MashTime = 90,
                BoilTime = 30,
                BatchSize = 20,
                YeastId = yests.First().Id,
                YeastAmount = 2,
                Creator = "MyName"
            });


        }

        private IEnumerable<T> AddItems<T>(IEnumerable<T> list)
        {
            var output = new List<T>();

            foreach (var item in list)
            {
                var entry = DataContext.Add(item);
                output.Add((T)entry.Entity);
            }

            DataContext.SaveChanges();

            return output;
        }

        private List<Yeast> GenerateYeasts()
        {
            var yeasts = new List<Yeast>();
            yeasts.Add(new Yeast()
            {
                Name = "US-05",
                AlcoholTolerance = Amount.Medium,
                Flocculation = Amount.Medium,
                BrewCategory = BrewCategory.Ale
            });
            yeasts.Add(new Yeast()
            {
                Name = "Saflager",
                AlcoholTolerance = Amount.Medium,
                Flocculation = Amount.Medium,
                BrewCategory = BrewCategory.Lager
            });
            return yeasts;
        }

        private List<Fermentable> GenerateFermentables()
        {
            var fermentables = new List<Fermentable>();
            fermentables.Add(new Fermentable()
            {
                Name = "Wheat Malt",
                Lovibond = 10.1,
                Ppg = 1,

            });
            fermentables.Add(new Fermentable()
            {
                Name = "Barley Extract",
                Lovibond = 10.1,
                Ppg = 1,

            });
            return fermentables;
        }

        // 1. Create default role
        // 2. Create Permissions for role
        // 3a. Create organization 1
        // 3b. Create organization 2
        // 3c. Create organization 3 child of 1
        // 4a. Create dataset A of Organization 1
        // 4b. Create dataset B of Organization 1
        // 4c. Create dataset C of Organization 1

        // 4d. Create dataset D of Organization 2
        // 4e. Create dataset E of Organization 3
        // 4f. Create dataset F of Organization 3

        // 5. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
        // 3. Create organization 1
    }
}
