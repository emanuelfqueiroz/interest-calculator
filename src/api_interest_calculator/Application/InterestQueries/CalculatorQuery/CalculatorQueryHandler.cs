using Application.Services;
using CQRSHelper._Common;
using Domain.Common;
using Domain.InterestAggregate;
using Domain.Scopes;
using FluentValidation.Results;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.InterestQueries.CalculatorQuery
{
    public class CalculatorQueryHandler : IQueryHandler<CalculatorQuery, CalculatorResponse>
    {
        IRateService _rateService;
        AsyncRetryPolicy _retry;
        public CalculatorQueryHandler(IRateService rateService, AsyncRetryPolicy defaultRetry)
        {
            this._rateService = rateService;
            this._retry = defaultRetry;
        }

        public async Task<CalculatorResponse> Handle(CalculatorQuery request, CancellationToken cancellationToken)
        {
            var rate = await _retry.ExecuteAsync<decimal?>(_rateService.GetRateMonthlyAsync);

            if (!rate.HasValue)
                return Error("Rate Service Unabailable");

            var interest = new Interest(request.InitialVale, request.Months, rate.Value);
            var validation = interest.IsValidForCalculateInterest();
            if (validation.IsSuccess)
                return await Task.FromResult(interest.Map());

            return Error(validation.Message);
        }

        private CalculatorResponse Error(string message)
        {
            return new CalculatorResponse() { Status = false, Message = message };
        }
    }
}
