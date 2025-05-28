using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using AppCondo.Domain.BaseHandler;
using AppCondo.Domain.Porteiro;
using FluentValidation.Results;

namespace AppCondo.Application.Services.PorteiroService
{
    public class PorteiroService : IPorteiroService
    {
        public async Task<BaseHandler> CadastrarPorteiro(PorteiroDTO porteiroDTO)
        {
            PorteiroValidator validation = new();
            ValidationResult result = validation.Validate(porteiroDTO);

            if (result.IsValid is false)
            {
                string messageError = string.Empty;

                foreach (var item in result.Errors)
                {
                    messageError += "\n" + item ;
                }

                return new BaseHandler()
                {
                    Success = false,
                    Message = "Erro ao cadastrar porteiro" + messageError,
                    Validations = result.Errors.ToList()
                };
            }
            return new BaseHandler();
        }
    }
}
