using System.Threading.Tasks;

namespace MediArch.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
