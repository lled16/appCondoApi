using AppCondo.Application.Interfaces;
using AppCondo.Domain.Interfaces;
using AppCondo.Domain.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AppCondo.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly JwtSettings _jwtSettings;

        public LoginService(ILoginRepository loginRepository, IOptions<JwtSettings> jwtSettings)
        {
            _loginRepository = loginRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Login(string userName, string password)
        {
            try
            {
                var user = await _loginRepository.Get(userName, password);

                if (user == null)
                    return null;


                return GenerateJwtToken(userName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = _jwtSettings.Key;

            SymmetricSecurityKey IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var creds = new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public (string hash, string salt) HashPassword(string password)
        {
            var saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(saltBytes);

            var salt = Convert.ToBase64String(saltBytes);

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
            var hashBytes = pbkdf2.GetBytes(32);

            var hash = Convert.ToBase64String(hashBytes);

            return (hash, salt);
        }

        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
            var hashBytes = pbkdf2.GetBytes(32);

            var hash = Convert.ToBase64String(hashBytes);

            return hash == storedHash;
        }
    }
}
