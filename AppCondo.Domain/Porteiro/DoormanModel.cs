using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCondo.Domain.Porteiro
{
    public class DoormanModel
    {
        [Key]
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Cpf { get; set; }
        public string ImagemDoc { get; set; }
        public bool Status { get; set; }
    }
}
