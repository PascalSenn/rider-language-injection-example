using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter;
using Snapshooter.Xunit;
using Xunit;
using static ExampleServer.Tests.TestHelper;

namespace ExampleServer.Tests
{
    public class SchemaTests
    {
        [Fact]
        public async Task SchemaShouldNotChange()
        {
            // arrange
            SnapshotFullName fullName = new XunitSnapshotFullNameReader().ReadSnapshotFullName();
            IServiceCollection services = ConfigureTestServices();
            IRequestExecutor executor = await services
                .AddGraphQLServer()
                .BuildRequestExecutorAsync();

            // act
            string schema = executor.Schema.Print();

            // assert
            schema.MatchSnapshot(new SnapshotFullName("schema.graphql", fullName.FolderPath));
        }
    }
}