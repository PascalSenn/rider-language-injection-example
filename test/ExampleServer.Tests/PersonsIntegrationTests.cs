using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Xunit;
using static ExampleServer.Tests.TestHelper;

namespace ExampleServer.Tests
{
    public class PersonsIntegrationTests
    {
        [Fact]
        public async Task GetPersons_Should_ReturnPagesPersons()
        {
            // arrange
            IServiceCollection services = ConfigureTestServices();
            IRequestExecutor executor = await services
                .AddGraphQLServer()
                .BuildRequestExecutorAsync();

            string query =
                @"query getPersons {
                persons {
                    nodes {
                        name
                    }
                }
            }";

            IReadOnlyQueryRequest request =
                QueryRequestBuilder.New().SetQuery(query).Create();

            // act
            IExecutionResult result = await executor.ExecuteAsync(request);

            // assert
            result.ToJson().MatchSnapshot();
        }
    }
}