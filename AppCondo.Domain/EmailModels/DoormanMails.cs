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
