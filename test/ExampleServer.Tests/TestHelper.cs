using Microsoft.Extensions.DependencyInjection;

namespace ExampleServer.Tests
{
    public static class TestHelper
    {
        public static IServiceCollection ConfigureTestServices()
        {
            ServiceCollection services = new();
            new Startup().ConfigureServices(services);
            return services;
        }
    }
}