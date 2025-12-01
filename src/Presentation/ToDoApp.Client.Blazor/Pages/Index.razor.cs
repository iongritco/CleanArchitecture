using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace ToDoApp.Client.Blazor.Pages;

public partial class Index
{
    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateTask;
        var user = authState.User;

        if (user.Identity is not { IsAuthenticated: true })
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}