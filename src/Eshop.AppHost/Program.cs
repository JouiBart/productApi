var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithRedisInsight();

var sql = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("ProductApi");

builder.AddProject<Projects.Product_API>("product-api")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(db)
    .WaitFor(cache)
    .WaitFor(db);


builder.AddProject<Projects.Product_MigrationService>("product-migrationservice")
    .WithReference(db)
    .WaitFor(db);



builder.Build().Run();
