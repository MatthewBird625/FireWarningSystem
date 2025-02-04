namespace FireWarningSystem.Data.Services
{
    public interface IEmailService
    {
       Task SendFormEmailAsync(string fromEmail, string subject, string body);
    }
}
