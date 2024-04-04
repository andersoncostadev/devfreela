using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DevFreela.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new("userName", email),
                new(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddHours(8), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ComputeSha256Hash(string password)
        {
            using var sha256 = SHA256.Create();
            // ComputeHash - returns byte array
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); // x2 faz com que o byte seja convertido para hexadecimal
            }

            return builder.ToString();
        }

    }
}
