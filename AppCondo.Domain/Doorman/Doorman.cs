using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCondo.Domain.Doorman
{
    public class Doorman
    {
        [Key]
        [NotMapped]
        public int? Id;
        public string PrimeiroNome;
        public string UltimoNome;
        public string Cpf;
        public string ImagemDoc;
        public bool Status;
        public string Password;
        [NotMapped]
        public string RegistrationId;

        public Doorman()
        {
        }

        public Doorman(int? id, string primeiroNome, string ultimoNome, string cpf, string imagemDoc, bool status, string registrationId, string password)
        {
            Id = id;
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Cpf = cpf;
            ImagemDoc = imagemDoc;
            Status = status;
            RegistrationId = GenerateId();
            Password = password;
        }

        private static string GenerateId()
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            return sixDigitNumber;
        }
    }
}
