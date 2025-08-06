using AppCondo.Domain.Porteiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Domain.EmailModels
{
    public static class DoormanMails
    {
        public static string RegistrationMails = @"
            Bem vindo, {DOORMANNAME}
            <br>
            Seu código de registro é : {REGISTERCODE} .
        ";
    }
}
