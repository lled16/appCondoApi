using AppCondo.Application.DTO;
using AppCondo.Domain.Porteiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Application.Mappings.Doorman
{
    public interface IDoormanMap
    {
        DoormanModel DoormanToModel(DoormanDTO doormanDTO);
        DoormanDTO DoormanToDTO(DoormanModel doormanModel);
    }
    public class DoormanMap : IDoormanMap
    {
        public DoormanModel DoormanToModel(DoormanDTO doormanDTO)
        {
            return new DoormanModel()
            {
                PrimeiroNome = doormanDTO.PrimeiroNome,
                UltimoNome = doormanDTO.UltimoNome,
                Cpf = doormanDTO.Cpf,
                ImagemDoc = doormanDTO.ImagemDoc,
                Status = doormanDTO.Status
            };
        }

        public DoormanDTO DoormanToDTO(DoormanModel doormanModel)
        {
            return new DoormanDTO()
            {
                PrimeiroNome = doormanModel.PrimeiroNome,
                UltimoNome = doormanModel.UltimoNome,
                Cpf = doormanModel.Cpf,
                ImagemDoc = doormanModel.ImagemDoc,
                Status = doormanModel.Status
            };
        }
    }
}
