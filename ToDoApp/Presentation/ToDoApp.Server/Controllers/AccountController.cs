using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.User.Commands;
using ToDoApp.Application.User.Queries;
using ToDoApp.Identity.User;

namespace ToDoApp.Server.Controllers
{
    [Route("api/account")]
    [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(GetTokenQuery getTokenQuery)
        {
            var result = await mediator.Send(getTokenQuery);
            if (string.IsNullOrEmpty(result))
            {
                return Forbid();
            }

            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand registerUserCommand)
        {
            await mediator.Send(registerUserCommand);
            return Ok();
        }

        [HttpGet]
        [Route("currentuser")]
        public IActionResult GetCurrentUser()
        {
            var currentUser = User.Identity.IsAuthenticated ? User.Identity.Name : null;
            return Json(currentUser);
        }
    }
}
