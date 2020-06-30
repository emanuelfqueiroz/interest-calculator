using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Application.Services.RateClient
{
    public class RateClient : IRateService
    {
        private HttpClient _http;

        public RateClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<decimal?> GetRateMonthlyAsync()
        {
            var res = await _http.GetAsync("taxaJuros");
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rateValue = await res.Content.ReadAsStringAsync();
                return Convert.ToDecimal(rateValue);
            }
            return null;
        }
    }
}
