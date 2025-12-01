using Microsoft.AspNetCore.Components;
using ToDoApp.Client.Blazor.Services;

namespace ToDoApp.Client.Blazor.Pages
{
    public partial class Logout
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IAuthService? AuthService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}