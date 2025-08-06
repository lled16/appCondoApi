using AppCondo.Domain.Login;

namespace AppCondo.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> Get(string userName, string password);

    }
}
