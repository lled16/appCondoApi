namespace AppCondo.Domain.Porteiro
{
    public class PorteiroModel
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Cpf { get; set; }
        public string ImagemDoc { get; set; }
        public bool Status { get; set; }
    }
}
