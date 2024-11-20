using NewBase.Integration.DTOs;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Abstraction
{
    public interface IIAMService
    {
        public Task<IAMUserDTO> GetUserInfoAsync(string identityId);
    }
}
