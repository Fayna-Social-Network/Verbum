using Messages.Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Verbum.Application.Verbum.Commands.CreateMessage;
using Xunit;

namespace Messages.Test.Messages.Commands
{
    public class CreateMessageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateMessageCommandHandler_Success() {

            //Arrange
            var handler = new CreateMessageCommandHandler(Context);
            var MessageText = "Message Text";


            //Act
            var MessageId = await handler.Handle(
                new CreateMessageCommand
                {
                    Text = MessageText,
                    UserId = MessagesContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Messages.SingleOrDefaultAsync(mess => 
                    mess.Id == MessageId && mess.Text == MessageText));


        } 
    }
}
