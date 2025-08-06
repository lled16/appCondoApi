using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using AppCondo.Application.Mappings.Doorman;
using AppCondo.Domain.Interfaces;
using AppCondo.Domain.Porteiro;
using FluentValidation.Results;
using System.Reflection.Emit;

namespace AppCondo.Application.Services.PorteiroService
{
    public class DoormanService : IDoormanService
    {
        private readonly IDoormanRepository _doormanRepository;
        private readonly IDoormanMap _doormanMap;
        private readonly IMailSender _mailSender;
        public DoormanService(IDoormanRepository doormanRepository, IDoormanMap doormanMap, IMailSender mailSender)
        {
            _doormanRepository = doormanRepository;
            _doormanMap = doormanMap;
            _mailSender = mailSender;
        }

        public async Task<DoormanModel> GetById(int id)
        {

            return await _doormanRepository.GetById(id);
        }
        public async Task<DoormanModel> RegisterDoorman(DoormanDTO porteiroDTO)
        {
            ValidationResult result = new DoormanValidator().Validate(porteiroDTO);
            DoormanModel doorman = _doormanMap.DoormanToModel(porteiroDTO);

            try
            {
                if (!result.IsValid)
                {
                    string messageError = string.Empty;

                    foreach (var item in result.Errors)
                        messageError += "\n" + item;

                    throw new Exception(messageError);
                }
  
                var insert = await _doormanRepository.Create(doorman);

                _mailSender.SendEmailRegistrationDoorman("email", "subject", doorman.RegistrationId, doorman.PrimeiroNome);

                return insert;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
