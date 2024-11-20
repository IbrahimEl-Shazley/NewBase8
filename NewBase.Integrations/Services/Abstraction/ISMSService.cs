using NewBase.Integration.DTOs;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Abstraction
{
    public interface ISMSService
    {
        public Task<bool> Send(SMSDTO dto);
    }
}
