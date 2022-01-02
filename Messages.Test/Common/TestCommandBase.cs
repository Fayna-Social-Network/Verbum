using System;
using Verbum.Persistence;

namespace Messages.Test.Common
{
    public abstract class TestCommandBase :IDisposable
    {
        protected readonly VerbumDbContext Context;

        public TestCommandBase() {
            Context = MessagesContextFactory.Create();
        }

        public void Dispose() {
            MessagesContextFactory.Destroy(Context);
        }
    }
}
