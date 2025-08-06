using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCondo.Application.DTO
{
    public class DoormanDTO
    {
        [NotMapped]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string ImageDoc { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
    }

    public class DoormanValidator : AbstractValidator<DoormanDTO>
    {
        public DoormanValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.LastName).NotNull().WithMessage("O nome é obrigatório");
            RuleFor(x => x.Cpf).NotNull().WithMessage("O CPF é obrigatório");
            RuleFor(x => x.ImageDoc).NotNull().WithMessage("A imagem do documento é obrigatória");
            RuleFor(x => x.Password).NotNull().WithMessage("A senha é obrigatória");
            RuleFor(x => x.Password).NotNull().MinimumLength(5).WithMessage("A senha precisa ter no mínimo 5 caracteres");
        }
    }
}
