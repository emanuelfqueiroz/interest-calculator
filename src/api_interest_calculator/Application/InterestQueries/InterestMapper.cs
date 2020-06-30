using Application.InterestQueries.CalculatorQuery;
using AutoMapper;
using Domain.InterestAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterestQueries
{
    public static class InterestMapper
    {
        public static IMapper mapper { get; set; }
        static InterestMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<decimal, decimal>().ConvertUsing(x => Decimal.Round(x, 2));
                cfg.CreateMap<Interest, CalculatorResponse>().ReverseMap();
            }).CreateMapper();
        }

        public static CalculatorResponse Map(this Interest interest)
        {
            return mapper.Map<Interest, CalculatorResponse>(interest);
        }

    }
}
