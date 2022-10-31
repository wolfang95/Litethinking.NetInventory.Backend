using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Litethinking.NetInventory.Backend.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace Litethinking.NetInventory.Backend.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService() { }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Application.Models.Email email)
        {
            string url = "UwBHAC4AQwBzAHYANABqAC0AQgB4AFEASwBPAHAAZQBYAEoAVwBHAFEAZQBzAEoAdwAuAGoAVgBoAFkAOABDAGIAZABVAEsARABXADMANgBqADQASABRADUAUwBMAHgAOQB0AHAAcwBqAHgAVAA5AC0AaQBLAGcATgB2AFIASQBzAGEAdwBfADQA";
            //byte[] encryted = System.Text.Encoding.Unicode.GetBytes(url);
            //string pa = Convert.ToBase64String(encryted);

            byte[] decryted = Convert.FromBase64String(url);

            string dpa = System.Text.Encoding.Unicode.GetString(decryted);



            var client = new SendGridClient(dpa);
            //var client = new SendGridClient("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");
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;
            /*
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            */
            var from = new EmailAddress
            {
                Email = "wolfang95@hotmail.es",
                Name = "wolfang"
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }


            _logger.LogError("El email no pudo enviarse, existen errores");
            return false;
        }

        
    }
}

