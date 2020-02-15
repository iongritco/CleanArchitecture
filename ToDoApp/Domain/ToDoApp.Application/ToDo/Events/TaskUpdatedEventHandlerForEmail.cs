using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

namespace ToDoApp.Application.ToDo.Events
{
    public class TaskCompletedEventHandler : INotificationHandler<TaskUpdatedEvent>
    {
        private readonly ILogger<TaskCompletedEventHandler> logger;

        public TaskCompletedEventHandler(ILogger<TaskCompletedEventHandler> logger)
        {
            this.logger = logger;
        }
        public async Task Handle(TaskUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);
            logger.LogInformation($"Sending email for user {notification.Email} with task {notification.Description} and status {notification.Status}.");
        }
    }
}
