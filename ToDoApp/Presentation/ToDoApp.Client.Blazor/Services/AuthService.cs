using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using ToDoApp.Client.Blazor.ViewModels;

namespace ToDoApp.Client.Blazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("http://localhost:5000/");
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorage = localStorage;
        }

        public async Task<string> Register(RegisterModel registerModel)
        {
            var result = await this._httpClient.PostJsonAsync<string>("api/account/register", new { email = registerModel.Email, password = registerModel.Password });
            return result;
        }

        // PostJsonAsync throws an error when reading string result - this is why I switched to PostAsync
        public async Task<string> Login(LoginModel loginModel)
        {
            var token = await this._httpClient.PostJsonAsync<string>("api/account/login", new { username = loginModel.Email, password = loginModel.Password });
            if (string.IsNullOrEmpty(token))
            {
                return token;
            }

            await this._localStorage.SetItemAsync("authToken", token);
            ((CustomAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return token;
        }

        public async Task Logout()
        {
            await this._localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsLoggedOut();
            this._httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}