using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Server.Services
{
    public class Settings : ISettings
    {
        private readonly IConfiguration configuration;

        public Settings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string TokenKey { get => configuration["JwtSecret"]; }
    }
}
