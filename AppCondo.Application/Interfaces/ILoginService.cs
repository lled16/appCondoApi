using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Application.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(string userName, string password);
        string GenerateJwtToken(string username);
        (string hash, string salt) HashPassword(string password);
        bool VerifyPassword(string password, string storedHash, string storedSalt);

    }
}
