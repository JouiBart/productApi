using Microsoft.OpenApi.Models;
using Product.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<ProductContext>(Eshop.ServiceDefaults.Constants.MSSQL_PRODUCTS);
builder.AddRedisDistributedCache(connectionName: Eshop.ServiceDefaults.Constants.REDIS_SERVER);
builder.AddKeyedRedisClient(name: Eshop.ServiceDefaults.Constants.REDIS_PRODUCTS);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product API",
        Description = "API for maintaining products",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // Load all xmls comments and examples for Swagger
    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    foreach (string fileName in xmlFiles)
    {
        string xmlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
        if (File.Exists(xmlFilePath))
            options.IncludeXmlComments(xmlFilePath, includeControllerXmlComments: true);
    }

});



builder.Services.AddScoped<Product.Domain.Interfaces.IProductService, Product.API.Services.ProductService>();
builder.Services.AddScoped<Product.Infrastructure.Repositories.IProductRepository, Product.Infrastructure.Repositories.ProductRepository>();
builder.Services.AddScoped<Product.Domain.Interfaces.IProductCacheService, Product.API.Services.ProductCacheService>();

var app = builder.Build();


app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
