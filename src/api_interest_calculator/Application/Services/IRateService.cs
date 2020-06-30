using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRateService
    {
        Task<decimal?> GetRateMonthlyAsync();
    }
}