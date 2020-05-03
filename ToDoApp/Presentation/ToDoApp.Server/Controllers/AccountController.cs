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
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(GetTokenQuery getTokenQuery)
        {
            var result = await _mediator.Send(getTokenQuery);
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
            var result = await _mediator.Send(registerUserCommand);
            return Json(result.IsSuccessful ? string.Empty : result.ErrorMessage);
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
