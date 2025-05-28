using FluentValidation;

namespace AppCondo.Application.DTO
{
    public class PorteiroDTO
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Cpf { get; set; }
        public string ImagemDoc { get; set; }
        public bool Status { get; set; }
    }

    public class PorteiroValidator : AbstractValidator<PorteiroDTO>
    {
        public PorteiroValidator()
        {
            RuleFor(x => x.PrimeiroNome).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.UltimoNome).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.Cpf).NotNull().WithMessage("O CPF é obrigatório");
            RuleFor(x => x.ImagemDoc).NotNull().WithMessage("A imagem do documento é obrigatória");
        }
    }
}
