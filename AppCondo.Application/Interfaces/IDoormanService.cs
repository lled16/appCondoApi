using AppCondo.Application.DTO;
using AppCondo.Domain.Doorman;

namespace AppCondo.Application.Interfaces
{
    public interface IDoormanService
    {
        Task<Doorman> GetById(int id);
        Task<Doorman> RegisterDoorman(DoormanDTO porteiroDTO);
        Task<bool> ActiveDoormanRegister(int id, string registrationId);
    }
}
