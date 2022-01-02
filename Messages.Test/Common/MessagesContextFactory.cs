using Microsoft.EntityFrameworkCore;
using System;
using Verbum.Domain;
using Verbum.Persistence;

namespace Messages.Test.Common
{
    public class MessagesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid MessageIdForDelete = Guid.NewGuid();
        public static Guid MessageIdForUpdate = Guid.NewGuid();

        public static VerbumDbContext Create() {
            var options = new DbContextOptionsBuilder<VerbumDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new VerbumDbContext(options);
            context.Database.EnsureCreated();
            context.Messages.AddRange(
                new Message { 
                    Timestamp  = DateTime.Today,
                    Text = "Test Text1",
                    Id = Guid.Parse("136F9CC5-F1E3-48EE-879D-B5D749B4258A"),
                    UserId = UserAId
                },
                   new Message
                   {
                       Timestamp = DateTime.Today,
                       Text = "Test Text2",
                       Id = Guid.Parse("1CB9C8B7-FF8C-43B4-B4C1-45E900700460"),
                       UserId = UserBId
                   },

                       new Message
                       {
                           Timestamp = DateTime.Today,
                           Text = "Test Text3",
                           Id = MessageIdForDelete,
                           UserId = UserAId
                       },

                           new Message
                           {
                               Timestamp = DateTime.Today,
                               Text = "Test Text4",
                               Id = MessageIdForUpdate,
                               UserId = UserBId
                           }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(VerbumDbContext context) {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
