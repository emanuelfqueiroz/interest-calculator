using CQRSHelper._Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Application.InterestQueries.CalculatorQuery
{
    public class CalculatorQuery :  IQuery<CalculatorResponse>
    {
        [FromQuery(Name ="meses")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Months { get; set; }
        [Required]
        [FromQuery(Name = "valorinicial")]
        [Range(0, int.MaxValue)]
        public decimal InitialVale { get; set; }
    }
}
