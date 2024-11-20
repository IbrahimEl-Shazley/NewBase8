using NewBase.Integration.DTOs;
using NewBase.Integration.Services.Abstraction;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Implementation
{
    public class IAMService : IIAMService
    {
        public async Task<IAMUserDTO> GetUserInfoAsync(string identityId)
        {
            return await Task.FromResult(new IAMUserDTO());
        }
    }
}
