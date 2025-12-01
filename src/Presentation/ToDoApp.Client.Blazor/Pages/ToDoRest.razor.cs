using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Client.Blazor.Pages
{
    public partial class ToDoRest
    {
        private List<ToDoItem> toDoList;
        private string newItem;
        private string currentUser;

        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;

            if (user.Identity is { IsAuthenticated: true })
            {
                currentUser = user.Identity.Name;
                toDoList = await HttpClient.GetFromJsonAsync<List<ToDoItem>>("api/todo");
            }
            else
            {
                NavigationManager.NavigateTo("login/");
            }
        }

        private async Task AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(newItem))
            {
                var todo = new ToDoItem(newItem, currentUser);
                toDoList.Add(todo);
                await HttpClient.PostAsJsonAsync("api/todo", new { description = newItem, id = todo.Id });
                newItem = string.Empty;
            }
        }

        private void RemoveTodo(Guid guid)
        {
            toDoList.Remove(toDoList.First(x => x.Id.Equals(guid)));
            HttpClient.DeleteAsync($"api/todo/{guid}");
        }

        private async Task StartTodo(Guid guid)
        {
            await UpdateTodo(guid, Status.InProgress);
        }

        private async Task CompleteTodo(Guid guid)
        {
            await UpdateTodo(guid, Status.Completed);
        }

        private async Task UpdateTodo(Guid guid, Status status)
        {
            var todo = toDoList.First(x => x.Id.Equals(guid));
            todo.SetStatus(status);
            await HttpClient.PutAsJsonAsync("api/todo",
                new { id = guid, description = todo.Description, status = todo.Status });
        }
    }
}