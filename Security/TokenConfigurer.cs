using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Security
{
    public static class TokenConfigurer
    {
        private static IConfiguration configuration;

        private static int seconds = 3600;
        private static DateTime dataCriacao = DateTime.Now;
        public static DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(seconds);

        private static string ValidIssuer = "";
        private static string ValidAudience = "";

        public static string Create(ClaimsIdentity identity = null)
        {
            if (identity == null)
            {
                identity = new ClaimsIdentity(
                    new GenericIdentity("1", "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("teste", "1")
                    }
                );
            }
 
            var provider = new RSACryptoServiceProvider(2048);
            var Key = new RsaSecurityKey(provider.ExportParameters(true));

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = ValidIssuer,
                Audience = ValidAudience,
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature),
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            TokenConfigurer.configuration = configuration;

            var authenticationBuilder = services.AddAuthentication();

            if (bool.Parse(configuration["JwtBearer:IsEnabled"]))
            {
                authenticationBuilder.AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtBearer:SecurityKey"])),

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,

                        ValidIssuer = configuration["JwtBearer:Issuer"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = configuration["JwtBearer:Audience"],

                        // Validate the token expiry
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here
                        ClockSkew = TimeSpan.Zero
                    };

                    options.SecurityTokenValidators.Clear();
                    options.SecurityTokenValidators.Add(new JwtSecurityTokenHandler());

                    ValidIssuer = options.TokenValidationParameters.ValidIssuer;
                    ValidAudience = options.TokenValidationParameters.ValidAudience;
                });
            }
        }
    }
}
