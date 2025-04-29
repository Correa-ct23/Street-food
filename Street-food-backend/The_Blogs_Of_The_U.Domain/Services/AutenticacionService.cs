using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Core.Ports;

namespace The_Blogs_Of_The_U.Domain.Services
{
    [DomainService]
    public class AutenticacionService
    {
        private readonly IMySqlRepositoryClient _mySqlRepositoryClient;
        public AutenticacionService(IMySqlRepositoryClient mySqlRepositoryClient)
        {
            _mySqlRepositoryClient = mySqlRepositoryClient; 
        }


        public async Task<string> validationToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            return await _mySqlRepositoryClient.getParameters(value);

        }

        public async Task<string> getAccesToken(string secretKey, string access)
        {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            ClaimsIdentity clamis = new ClaimsIdentity();
            clamis.AddClaim(new Claim(ClaimTypes.NameIdentifier, access));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = clamis,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokenCreated = tokenHandler.WriteToken(tokenConfig);

            return tokenCreated;

        }
    }
}
