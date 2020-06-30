using CQRSHelper._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interest.RateQuery
{
    public class RateQueryResponse : Response
    {
        public decimal MonthlyRate { get; set; }
    }
}
