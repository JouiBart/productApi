using Aspire.Hosting;

namespace Eshop.Tests;

[TestClass]
public class WebTests
{
    [Fact]
    public async Task Application_Builds_And_Runs_Without_Exception()
    {
        // Arrange
        var args = new string[0];

        // Act & Assert
        await Task.Run(() =>
        {
            var builder = DistributedApplication.CreateBuilder(args);

            var cache = builder.AddRedis("cache")
                .WithRedisInsight();

            var sql = builder.AddSqlServer("sql")
                .WithLifetime(ContainerLifetime.Persistent);

            var db = sql.AddDatabase("ProductApi");

            var rabbitmq = builder.AddRabbitMQ("product");

            builder.AddProject<Projects.Product_API>("product-api")
                .WithExternalHttpEndpoints()
                .WithReference(cache)
                .WithReference(db)
                .WithReference(rabbitmq)
                .WaitFor(cache)
                .WaitFor(rabbitmq)
                .WaitFor(db);

            builder.AddProject<Projects.Product_MigrationService>("product-migrationservice")
                .WithReference(db)
                .WaitFor(db);

            // Just ensure Build() does not throw
            var app = builder.Build();
            Assert.NotNull(app);
        });
    }
}
