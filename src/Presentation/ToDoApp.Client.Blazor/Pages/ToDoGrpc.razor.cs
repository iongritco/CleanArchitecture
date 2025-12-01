using Grpc.Core;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using ToDoApp.Domain.Entities;
using ToDoApp.Server.GRPC;
using Blazored.LocalStorage;
using Grpc.Net.Client;
using Status = ToDoApp.Domain.Enums.Status;

namespace ToDoApp.Client.Blazor.Pages
{
    public partial class ToDoGrpc
    {
        private List<ToDoItem> _toDoList;
        private string _currentUser;
        private string _newItem;
        private ToDo.ToDoClient _grpcClient;
        private Metadata _headers;

        [Inject]
        public NavigationManager NavigationManager { get; set; }        
        
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }      
        
        [Inject]
        public GrpcChannel? Channel { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;
            _grpcClient = new ToDo.ToDoClient(Channel);
            var token = await LocalStorageService.GetItemAsync<string>("authToken");
            _headers = new Metadata
            {
                { "Authorization", $"Bearer {token}" }
            };

            if (user.Identity is { IsAuthenticated: true })
            {
                _currentUser = user.Identity.Name;
                var response = await _grpcClient.GetToDoListAsync(new GetToDoListRequest { Username = _currentUser }, _headers);
                _toDoList = new List<ToDoItem>();

                foreach (var item in response.ToDoList)
                {
                    var todo = new ToDoItem(item.Description, (Status)item.Status, item.CreatedDate.ToDateTime(), item.Id);
                    _toDoList.Add(todo);
                }
            }
            else
            {
                NavigationManager.NavigateTo("login/");
            }

        }

        private async Task AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(_newItem))
            {
                var todo = new ToDoItem(_newItem, _currentUser);
                _toDoList.Add(todo);
                await _grpcClient.AddToDoAsync(new AddToDoRequest { Description = todo.Description, Id = todo.Id.ToString(), Username = todo.Username }, _headers);
                _newItem = string.Empty;
            }
        }

        private async Task RemoveTodo(Guid guid)
        {
            _toDoList.Remove(_toDoList.First(x => x.Id.Equals(guid)));
            await _grpcClient.DeleteToDoAsync(new DeleteToDoRequest { Id = guid.ToString(), Username = _currentUser }, _headers);
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
            var todo = _toDoList.First(x => x.Id.Equals(guid));
            todo.SetStatus(status);
            await _grpcClient.UpdateToDoAsync(new UpdateToDoRequest { Username = _currentUser, Description = todo.Description, Id = guid.ToString(), Status = (int)todo.Status }, _headers);
        }
    }
}
