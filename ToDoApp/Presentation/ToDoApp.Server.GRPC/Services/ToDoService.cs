using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using ToDoApp.Application.ToDo.Queries;

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
            var response = new GetToDoListReply { Message = result[0].Description };
            return response;
        }
    }
}
