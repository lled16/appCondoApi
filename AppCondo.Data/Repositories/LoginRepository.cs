using AppCondo.Data.Context;
using AppCondo.Domain.Interfaces;
using AppCondo.Domain.Login;

namespace AppCondo.Data.Repositories
{
    public class LoginRepository(ApplicationDbContext context) : ILoginRepository
    {
        public async Task<User> Get(string userName, string password)
        {
            return context.Users.Where(x => x.Nome == userName).FirstOrDefault();
        }
    }
}
