using Application.Interest.RateQuery;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.Test.Rate
{
    public class RateHandlerTest
    {
        public RateQueryHandler Handler { get; private set; }

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true)
                .Build();
            this.Handler = new RateQueryHandler(config);
        }

        [Test]
        public async Task MonthlyRateTest()
        {
            var query = new RateQuery();
            var result = await this.Handler.Handle(query, new System.Threading.CancellationToken());
            Assert.AreEqual(9.99, result.MonthlyRate);
        }

    }
}
