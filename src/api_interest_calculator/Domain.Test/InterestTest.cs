using Domain.InterestAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    internal class InterestMap
    {
        public InterestAggregate.Interest Interest { get; set; }
        public decimal Expected { get; set; }
        public decimal Result => Decimal.Round(Interest.Total, 2);

        public InterestMap(Interest interest, decimal expected)
        {
            Interest = interest;
            Expected = expected;
        }
    }
    public class InterestTest
    {
        List<InterestMap> Interests;

        [SetUp]
        public async Task Setup()
        {
            //TODO: USE FILE FOR TESTS
            //SAMPLE: https://gitlab.com/emanuelfqueiroz/routes-project/-/blob/master/src/RouteFinder.Application.Tests/RouteBasicTests.cs
            Interests = new List<InterestMap>()
            {

                new InterestMap(new Interest(1000, times: 12, rate: 0.01M), 1_126.83M),
                new InterestMap(new Interest(1000, times: 12, rate: 0.00M), 1000M),
                new InterestMap(new Interest(1000.99M, times: 10, rate: 0.0199M), 1219.01M),

            };
        }

        [Test]
        public void ZeroRateTest()
        {
            var map = new InterestMap(new Interest(1000, times: 12, rate: 0.00M), 1000M);
            Assert.AreEqual(map.Expected, map.Result);
        }
        [Test]
        public void ZeroInitialTest()
        {
            var map  = new InterestMap(new Interest(0, times: 10, rate: 0.01M), 0M);
            Assert.AreEqual(map.Expected, map.Result);
        }
        [Test]
        public void ZeroTimesTest()
        {
            var map = new InterestMap(new Interest(1000, times: 0, rate: 0.01M), 1000M);
            Assert.AreEqual(map.Expected, map.Result);
        }

        [Test]
        public async Task Check()
        {
            if (Interests == null || Interests.Count <= 0)
            {
                Assert.Fail("Test Error: Interest Map not found");
            }
            var scenario = 1;
            foreach (var item in Interests)
            {

                Assert.AreEqual(item.Expected, item.Result, $"Scenario {scenario}");
                scenario++;
            }
        }
    }
}
