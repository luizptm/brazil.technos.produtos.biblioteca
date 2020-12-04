using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Security
{
    public static class TokenConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
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
                });
            }
        }
    }
}
