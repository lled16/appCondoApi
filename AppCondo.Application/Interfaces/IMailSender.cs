using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Application.Interfaces
{
    public interface IMailSender
    {
        void SendEmailRegistrationDoorman(string toEmail, string subject, string idRegistration, string name);
    }
}
