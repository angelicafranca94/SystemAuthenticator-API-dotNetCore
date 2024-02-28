using EmailSender.API.DTOs;

namespace EmailSender.Consumer.Services;

public interface IEmailService
{
   Task SendEmailAsync(EmailRequestDto emailRequest);
}
