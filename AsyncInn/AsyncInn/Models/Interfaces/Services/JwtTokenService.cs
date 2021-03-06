﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class JwtTokenService
    {
        /// <summary>
        /// this method validates whether or not we have secrets and if they are correct 
        /// </summary>
        /// <param name="configuration">This will ensure the security key, which comes from our configuration is valid</param>
        /// <returns></returns>

        private IConfiguration configuration;
        private SignInManager<ApplicationUser> signInManager;

        /// <summary>
        /// Gets the validated parameters
        /// </summary>
        /// <param name="config"></param>
        /// <param name="manager"></param>
        public JwtTokenService(IConfiguration config, SignInManager<ApplicationUser> manager)
        {
            configuration = config;
            signInManager = manager;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];
            if (secret == null) { throw new InvalidOperationException("Oopsie, no JWT secret found here.."); }
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }
        /// <summary>
        /// Will get a token 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="expiresIn"></param>
        /// <returns>the token</returns>
        public async Task<string> GetToken(ApplicationUser user, System.TimeSpan expiresIn)
        {
            var principal = await signInManager.CreateUserPrincipalAsync(user);
            if (principal == null) { return null; }

            var signingKey = GetSecurityKey(configuration);
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiresIn,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: principal.Claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
