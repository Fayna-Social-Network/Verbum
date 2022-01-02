using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Interfaces;
using Verbum.Persistence;
using Xunit;

namespace Messages.Test.Common
{
    public class QueryTestFixture :IDisposable
    {
        public VerbumDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture() {
            Context = MessagesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IVerbumDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();

        }

        public void Dispose() {
            MessagesContextFactory.Destroy(Context);
        }

    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
