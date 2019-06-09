using System;
using System.Threading.Tasks;

namespace ToDoApp.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> Authenticate(string username, string password);

        Task RegisterUser(string email, string password);
    }
}
