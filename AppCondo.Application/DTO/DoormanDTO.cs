using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCondo.Application.DTO
{
    public class DoormanDTO
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Cpf { get; set; }
        public string ImagemDoc { get; set; }
        public bool Status { get; set; }
    }

    public class DoormanValidator : AbstractValidator<DoormanDTO>
    {
        public DoormanValidator()
        {
            RuleFor(x => x.PrimeiroNome).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.UltimoNome).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.Cpf).NotNull().WithMessage("O CPF é obrigatório");
            RuleFor(x => x.ImagemDoc).NotNull().WithMessage("A imagem do documento é obrigatória");
        }
    }
}
