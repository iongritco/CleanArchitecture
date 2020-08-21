using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using ToDoApp.Application.ToDo.Queries;
using Google.Protobuf.WellKnownTypes;
using System;

namespace ToDoApp.Server.GRPC.Services
{
    public class ToDoService : ToDo.ToDoBase
    {
        private readonly IMediator _mediator;

        public ToDoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task GetToDoList(GetToDoListRequest request, IServerStreamWriter<GetToDoListReply> responseStream, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetToDoListQuery(request.Username));
            foreach (var item in result)
            {
                var response = new GetToDoListReply { Description = item.Description, Status= (int)item.Status, CreatedDate = Timestamp.FromDateTime(item.CreatedDate.ToUniversalTime()) };
                await responseStream.WriteAsync(response);
            }
        }
    }
}
