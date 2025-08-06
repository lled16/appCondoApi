using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using AppCondo.Application.Mappings.Doorman;
using AppCondo.Domain.Doorman;
using AppCondo.Domain.Interfaces;
using FluentValidation.Results;

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

        public async Task<Doorman> GetById(int id)
        {
            return await _doormanRepository.GetById(id);
        }

        public async Task<Doorman> RegisterDoorman(DoormanDTO porteiroDTO)
        {
            ValidationResult result = new DoormanValidator().Validate(porteiroDTO);

            Doorman doorman = _doormanMap.DoormanToModel(porteiroDTO);

            try
            {
                if (!result.IsValid)
                    throw new Exception(ReturnMessageError(result));

                var insert = await _doormanRepository.Create(doorman);

                _mailSender.SendEmailRegistrationDoorman("email", "subject", doorman.RegistrationId, doorman.PrimeiroNome);

                return insert;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ActiveDoormanRegister(int id, string registrationId)
        {
            if (await _doormanRepository.ActiveDoormanRegister(id, registrationId))
                return true;

            return false;
        }

        private string ReturnMessageError(ValidationResult result)
        {
            string messageError = string.Empty;

            foreach (var item in result.Errors)
                messageError += "\n" + item;

            return messageError;
        }

    }
}
