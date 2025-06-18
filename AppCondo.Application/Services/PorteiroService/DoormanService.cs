using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using AppCondo.Application.Mappings.Doorman;
using AppCondo.Domain.Interfaces;
using AppCondo.Domain.Porteiro;
using FluentValidation.Results;

namespace AppCondo.Application.Services.PorteiroService
{
    public class DoormanService : IDoormanService
    {
        private readonly IDoormanRepository _doormanRepository;
        private readonly IDoormanMap _doormanMap;

        public DoormanService(IDoormanRepository doormanRepository, IDoormanMap doormanMap)
        {
            _doormanRepository = doormanRepository;
            _doormanMap = doormanMap;
        }

        public async Task<DoormanModel> GetById(int id)
        {

            return await _doormanRepository.GetById(id);

        }
        public async Task<DoormanModel> RegisterDoorman(DoormanDTO porteiroDTO)
        {
            DoormanValidator validation = new();
            ValidationResult result = validation.Validate(porteiroDTO);
            DoormanModel doorman = _doormanMap.DoormanToModel(porteiroDTO);

            try
            {
                if (result.IsValid is false)
                {
                    string messageError = string.Empty;

                    foreach (var item in result.Errors)
                        messageError += "\n" + item;

                    throw new Exception(messageError);
                }

                var insert = await _doormanRepository.Create(doorman);

                return insert;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
