using NewBase.Integration.Services.Abstraction;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Implementation
{
    public class EPaymentService : IEPaymentService
    {
        public async Task<bool> Pay()
        {
            return await Task.FromResult(true);
        }
    }
}
