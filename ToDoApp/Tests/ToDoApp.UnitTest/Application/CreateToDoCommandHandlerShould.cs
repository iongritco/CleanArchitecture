using AutoFixture.Xunit2;
using FluentAssertions;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Commands.CreateToDo;
using ToDoApp.Entity.Entities;
using Xunit;

namespace ToDoApp.UnitTests.Application
{
    public class CreateToDoCommandHandlerShould
    {
        [Theory]
        [AutoMoqData]
        public async Task ReturnUnitValueWhenSuccessful(
            CreateToDoCommand command,
            [Frozen] Mock<IToDoCommandRepository> todoCommandRepositoryMock,
            CreateToDoCommandHandler sut)
        {
            var result = await sut.Handle(command, CancellationToken.None);

            todoCommandRepositoryMock.Verify(call => call.CreateToDo(
                It.Is<ToDoItem>(x => x.Id.Equals(command.Id) && x.Description.Equals(command.Description) && x.Username.Equals(command.Username))), 
                Times.Once);
            result.Should().Be(Unit.Value);
        }
    }
}
