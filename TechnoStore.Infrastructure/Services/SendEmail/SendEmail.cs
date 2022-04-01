using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Infrastructure.Services.SendEmail
{
    public class SendEmail : ISendEmail
    {
        private readonly IWebHostEnvironment _env;
        public SendEmail(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task Send(string to, string subject, string html)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));
            message.From = new MailAddress("al5.aaa67@gmail.com", "TechnoStore");
            message.Subject = subject;
            message.Body = html;
            message.IsBodyHtml = true;

            using var emailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Technostore.web@gmai.com", "TechnoStore@2022")
            };
            await emailClient.SendMailAsync(message);
        }

    }
}
