using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Generics;

namespace ToDoApp.Identity.User
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;
        }

        public async Task<Result> RegisterUser(string email, string password)
        {
            var identity = new ApplicationUser { UserName = email, Email = email };
            var identityResult = await userManager.CreateAsync(identity, password);

            return identityResult.Succeeded 
                    ? Result.Ok() 
                    : Result.Fail(identityResult.Errors.Select(x => x.Description).Aggregate((a, b) => a + "; " + b));
        }
    }
}
