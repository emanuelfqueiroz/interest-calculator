using CQRSHelper._Common;
using InfraStructure.DI;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Application.Interest.RateQuery
{
    public class RateQueryHandler : IQueryHandler<RateQuery, RateQueryResponse>
    {
        public RateConfig _rateConfig { get; private set; }

        public RateQueryHandler(IConfiguration config)
        {
            _rateConfig = config.GetSection("Rate").Get<RateConfig>();
        }

        public Task<RateQueryResponse> Handle(RateQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new RateQueryResponse() { MonthlyRate = _rateConfig.MonthlyRate });
        }
    }
}
