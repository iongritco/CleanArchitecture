using Microsoft.AspNetCore.Components;
using ToDoApp.Client.Blazor.Services;
using ToDoApp.Client.Blazor.ViewModels;

namespace ToDoApp.Client.Blazor.Pages
{
    public partial class Register
    {
        private readonly RegisterModel _registerModel = new();
        private bool _displayErrors;
        private string? _errorMessage;

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IAuthService? AuthService { get; set; }

        private async Task HandleRegistration()
        {
            _displayErrors = false;
            var result = await AuthService.Register(_registerModel);
            if (string.IsNullOrWhiteSpace(result))
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                _displayErrors = true;
                _errorMessage = result;
            }
        }
    }
}