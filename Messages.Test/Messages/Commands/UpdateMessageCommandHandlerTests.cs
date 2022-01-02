using Messages.Test.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Verbum.Application.Verbum.Commands.UpdateMessage;
using Xunit;

namespace Messages.Test.Messages.Commands
{
    public class UpdateMessageCommandHandlerTests :TestCommandBase
    {
        [Fact]
        public async Task UpdateMessageCommandHandler_Success() {
            
            //Arrange
            var handler = new UpdateMessageCommandHandler(Context);
            var updatedMessage = "new MessageEEEEEEEEEEE";

            //Act
            await handler.Handle(new UpdateMessageCommand
            {

                Id = MessagesContextFactory.MessageIdForUpdate,
                UserId = MessagesContextFactory.UserBId,
                Text = updatedMessage
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Messages.SingleOrDefaultAsync(mess =>
                mess.Id == MessagesContextFactory.MessageIdForUpdate &&
                mess.Text == updatedMessage));



        } 

    }
}
