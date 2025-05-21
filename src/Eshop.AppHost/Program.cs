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



builder.Build().Run();
