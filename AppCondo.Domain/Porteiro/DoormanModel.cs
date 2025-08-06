using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCondo.Domain.Porteiro
{
    public class DoormanModel
    {
        [Key]
        public int Id;
        public string PrimeiroNome;
        public string UltimoNome;
        public string Cpf;
        public string ImagemDoc;
        public bool Status;
        [NotMapped]
        public string RegistrationId;


        public DoormanModel(int id, string primeiroNome, string ultimoNome, string cpf, string imagemDoc, bool status, string registrationId)
        {
            Id = id;
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Cpf = cpf;
            ImagemDoc = imagemDoc;
            Status = status;
            RegistrationId = GenerateID();
        }

        private string GenerateID()
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            return sixDigitNumber;
        }
    }
}
