using System.Net.Mail;
using System.Net;
using System.Text;
using AppCondo.Application.Interfaces;
using AppCondo.Domain.Porteiro;
using AppCondo.Domain.EmailModels;

namespace AppCondo.Application.Services.PorteiroService
{
    public class EmailService : IMailSender
    {
        public void SendEmailRegistrationDoorman(string toEmail, string subject, string idRegistration, string name)
        {
            var client = CreateClient();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("**********");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;

            StringBuilder mailBody = new StringBuilder();
            mailBody.Append(DoormanMails.RegistrationMails);

            mailBody.Replace("{DOORMANNAME}", name);
            mailBody.Replace("{REGISTERCODE}", idRegistration.ToString());

            mailMessage.Body = mailBody.ToString();

            client.Send(mailMessage);
        }


        public SmtpClient CreateClient()
        {
            SmtpClient client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("**********", "*********");
            return client;
        }
    }
}

