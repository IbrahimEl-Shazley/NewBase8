using System.Net.Mail;
using System.Threading.Tasks;

namespace NewBase.Integration.Services.Abstraction
{
    public interface IMailService
    {
        Task<bool> Send(MailMessage mailMessage);
    }
}
