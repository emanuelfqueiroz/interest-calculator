using CQRSHelper._Common;
using Domain.InterestAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.InterestQueries.CalculatorQuery
{
    public class CalculatorResponse : Response
    {
        public decimal Total { get; set; }
        public decimal InitialValue { get; set; }
        public decimal Rate { get; set; }
        public decimal Interest => Total - InitialValue;

        public object TotalText => Total.ToString("N2");

        //List<Snapshot> 
        //public CalculatorResponse(decimal initialValue, decimal finalValue, decimal rate )
        //{
        //    InitialValue = initialValue;
        //    FinalValue = Decimal.Round(finalValue, 2);
        //    Rate = Decimal.Round(rate, 2);
        //}

    }
}
