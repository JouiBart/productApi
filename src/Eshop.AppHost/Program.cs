var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


builder.AddProject<Projects.Product_API>("product-api")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache);


builder.Build().Run();
