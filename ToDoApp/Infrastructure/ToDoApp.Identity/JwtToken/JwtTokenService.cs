﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Identity.JwtToken
{
    public class JwtTokenService : ITokenService
    {
        private readonly ISettings settings;

        public JwtTokenService(ISettings settings)
        {
            this.settings = settings;
        }

        public string GenerateToken(string username)
        {
            var symmetricKey = Convert.FromBase64String(settings.TokenKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name, username)
                            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}