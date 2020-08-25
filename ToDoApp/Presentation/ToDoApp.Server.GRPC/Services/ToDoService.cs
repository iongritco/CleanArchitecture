using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using ToDoApp.Application.ToDo.Queries;
using Google.Protobuf.WellKnownTypes;

namespace ToDoApp.Server.GRPC.Services
{
    public class ToDoService : ToDo.ToDoBase
    {
        private readonly IMediator _mediator;

        public ToDoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GetToDoListReply> GetToDoList(GetToDoListRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetToDoListQuery(request.Username));
            var response = new GetToDoListReply();
            foreach (var item in result)
            {
                response.ToDoList.Add(new ToDoView{CreatedDate = Timestamp.FromDateTime(item.CreatedDate.ToUniversalTime()), Description = item.Description, Status = (int)item.Status});
            }

            return response;
        }
    }
}
