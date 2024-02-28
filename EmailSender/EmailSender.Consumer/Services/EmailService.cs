using EmailSender.API.DTOs;
using EmailSender.API.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace EmailSender.Consumer.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(EmailRequestDto emailRequest)
    {
        try
        {
            var email = CreateEmail(emailRequest);

            using var smtp = new SmtpClient();
            
            smtp.Connect(_config["EmailHost"], Convert.ToInt32(_config["EmailPort"]), SecureSocketOptions.StartTls);
            
            smtp.Authenticate(_config["EmailUsername"], _config["EmailPassword"]);
            
            await smtp.SendAsync(email);
            
            smtp.Disconnect(true);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    private MimeMessage CreateEmail(EmailRequestDto emailRequest)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(emailRequest.To));


        email.Subject = emailRequest.Subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailRequest.Body };
        return email;
    }
}
