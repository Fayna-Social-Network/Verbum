using Messages.Test.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Verbum.Commands.CreateMessage;
using Verbum.Application.Verbum.Commands.DeleteMessage;
using Xunit;

namespace Messages.Test.Messages.Commands
{
    
    public class DeleteMessageCommandHandlerTests :TestCommandBase
    {
        [Fact]
        public async Task DeleteMessageCommandHandler_Saccess() {
            
            //Arrange
            var handler = new DeleteMessageCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteMessageCommand
                {

                    Id  = MessagesContextFactory.MessageIdForDelete,
                    UserId = MessagesContextFactory.UserAId

                }, CancellationToken.None);

            //Assert
            Assert.Null(Context.Messages.SingleOrDefault(mess =>
                mess.Id == MessagesContextFactory.MessageIdForDelete));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOrWrongId() {

            //Arrange
            var handler = new DeleteMessageCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteMessageCommand {
                        Id = Guid.NewGuid(),
                        UserId  = MessagesContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOrWrongUserId()
        {

            //Arrange
            var deleteHandler = new DeleteMessageCommandHandler(Context);
            var createHandler = new CreateMessageCommandHandler(Context);
            var messageId = await createHandler.Handle(
                new CreateMessageCommand { 
                    Text = "Message Text",
                    UserId = MessagesContextFactory.UserAId
                }, 
                CancellationToken.None);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteMessageCommand
                    {
                        Id = messageId,
                        UserId = MessagesContextFactory.UserBId
                    }, CancellationToken.None));
        }

    }
}
