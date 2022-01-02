using AutoMapper;
using Messages.Test.Common;
using Shouldly;
using System.Threading;
using Verbum.Application.Verbum.Queries.GetMessageList;
using Verbum.Persistence;
using Xunit;

namespace Messages.Test.Messages.Queries
{
    [Collection("QueryCollection")]
    public class GetMessageListQueryHandlerTests
    {
        private readonly VerbumDbContext Context;
        private readonly IMapper Mapper;

        public GetMessageListQueryHandlerTests(QueryTestFixture fixture) { 
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetMessageListQueryHandler_Succes() {
            //Arrange
            var handler = new GetMessageListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetMessageListQuery
            {
                UserId = MessagesContextFactory.UserBId
            },
                CancellationToken.None);

            //Assert
           result.ShouldBeOfType<MessageListVm>();
           result.Messages.Count.ShouldBe(2);


        }
    }
}
