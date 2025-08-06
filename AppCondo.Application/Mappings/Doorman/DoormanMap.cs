using AppCondo.Application.DTO;

namespace AppCondo.Application.Mappings.Doorman
{
    public interface IDoormanMap
    {
        Domain.Doorman.Doorman DoormanToModel(DoormanDTO doormanDTO);
        DoormanDTO DoormanToDTO(Domain.Doorman.Doorman doormanModel);
    }
    public class DoormanMap : IDoormanMap
    {
        public Domain.Doorman.Doorman DoormanToModel(DoormanDTO doormanDTO)
        {
            return new Domain.Doorman.Doorman()
            {
                Id = doormanDTO.Id,
                PrimeiroNome = doormanDTO.FirstName,
                UltimoNome = doormanDTO.LastName,
                Cpf = doormanDTO.Cpf,
                ImagemDoc = doormanDTO.ImageDoc,
                Status = doormanDTO.Status,
                Password = doormanDTO.Password
            };
        }

        public DoormanDTO DoormanToDTO(Domain.Doorman.Doorman doormanModel)
        {
            return new DoormanDTO()
            {
                FirstName = doormanModel.PrimeiroNome,
                LastName = doormanModel.UltimoNome,
                Cpf = doormanModel.Cpf,
                ImageDoc = doormanModel.ImagemDoc,
                Status = doormanModel.Status,
                Password = doormanModel.Password
            };
        }
    }
}
