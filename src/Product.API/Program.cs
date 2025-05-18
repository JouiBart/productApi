using Product.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<ProductContext>(Eshop.ServiceDefaults.Constants.MSSQL_PRODUCTS);
builder.AddRedisDistributedCache(connectionName: Eshop.ServiceDefaults.Constants.REDIS_SERVER);
builder.AddKeyedRedisClient(name: Eshop.ServiceDefaults.Constants.REDIS_PRODUCTS);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<Product.Domain.Interfaces.IProductService, Product.API.Services.ProductService>();
builder.Services.AddScoped<Product.Infrastructure.Repositories.IProductRepository, Product.Infrastructure.Repositories.ProductRepository>();
builder.Services.AddScoped<Product.Domain.Interfaces.IProductCacheService, Product.API.Services.ProductCacheService>();

var app = builder.Build();


app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
