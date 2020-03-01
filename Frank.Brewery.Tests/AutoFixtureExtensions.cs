using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;

namespace Frank.Brewery.Tests
{
    internal static class AutoFixtureExtensions
    {
        internal static Fixture OmitRecursion(this Fixture fixture)
        {
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}
