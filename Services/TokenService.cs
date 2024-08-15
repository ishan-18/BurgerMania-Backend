using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Options;
using api.Interface;
using api.Data;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ApplicationDBContext _context;
        public TokenService(JwtSettings jwtSettings, ApplicationDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        // method for generating token
        public string GenerateToken(string Username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Username);
            // Claims: User-specific information is added to the token.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "User")
            };

            if (user.UserRole == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            // secret key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // Combines the secret key and algorithm to sign the token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Represents the token itself, with claims, issuer, audience, expiration, and signing credentials.
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            // returning token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}