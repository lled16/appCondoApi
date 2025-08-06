using AppCondo.Domain.Doorman;

namespace AppCondo.Domain.Interfaces
{
    public interface IDoormanRepository
    {
        Task<Doorman.Doorman> GetById(int id);
        Task<Doorman.Doorman> Create(Doorman.Doorman porteiro);
        Task<bool> ActiveDoormanRegister(int id, string registrationId);
        Task<Doorman.Doorman> GetDoormanByIdAndRegistrationId(int id, string registrationId);
    }
}
