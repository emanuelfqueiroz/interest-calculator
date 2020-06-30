using Domain.Common;
using Domain.InterestAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Scopes
{
    public static class InterestScope
    {
        public static DomainValidation IsValidForCalculateInterest(this Interest interest)
        {
            if(interest.InitialValue >= 0 && interest.Rate >= 0 && interest.Times >= 0)
            {
                return DomainValidation.Success;
            }
            return new DomainValidation("Negative values are not allowed");
        }
    }
}
