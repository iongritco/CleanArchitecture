using Microsoft.AspNetCore.Components;
using ToDoApp.Client.Blazor.Services;
using ToDoApp.Client.Blazor.ViewModels;

namespace ToDoApp.Client.Blazor.Pages;

public partial class Login
{
    private readonly LoginModel _loginModel = new();
    private bool _displayErrors;

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    [Inject]
    public IAuthService? AuthService { get; set; }

    private async Task HandleLogin()
    {
        _displayErrors = false;
        var token = await AuthService.Login(_loginModel);
        if (!string.IsNullOrEmpty(token))
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            _displayErrors = true;
        }
    }
}