using System.Threading.Tasks;

namespace NewBase.Integration.Services.Abstraction
{
    public interface IEPaymentService
    {
        Task<bool> Pay();
    }
}
