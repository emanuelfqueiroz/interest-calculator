using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.InterestAggregate
{
    public class Interest
    {
        public decimal InitialValue { get; private set; }
        public int Times { get; private set; }
        public decimal Rate { get; private set; }
        private Lazy<decimal> _total { get; set; }
        public decimal Total => _total.Value;


        public Interest(decimal initialValue, int times, decimal rate)
        {
            InitialValue = initialValue;
            Times = times;
            Rate = rate;
            _total = new Lazy<decimal>(() => CalculateTotal(), false);
        }

        private decimal CalculateTotal()
        {
            var dRate = Convert.ToDouble(Rate);
            return InitialValue * Convert.ToDecimal(Math.Pow(dRate + 1, Times));
        }

    }
}
