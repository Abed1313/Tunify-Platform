using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Servises
{
    public class JwtTokenServeses
    {
        private IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenServeses(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }


        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Jwt Secret key is missing or not configured properly.");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(secretBytes);
        }


        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan expiryDate)
        {
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincipal == null)
            {
                throw new InvalidOperationException("Failed to create user principal.");
            }

            var signingKey = GetSecurityKey(_configuration);
            if (signingKey == null)
            {
                throw new InvalidOperationException("Signing key not configured properly.");
            }

            // Add custom claims
            var claims = userPrincipal.Claims.ToList(); // Convert to list for modification
            claims.Add(new Claim("Email", user.Email)); // Add user's email as a claim

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiryDate,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
