using Microsoft.OpenApi.Models;
using Product.Infrastructure;

namespace Product.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        #region Aspire
        builder.AddSqlServerDbContext<ProductContext>(Eshop.ServiceDefaults.Constants.MSSQL_PRODUCTS);
        builder.AddRedisDistributedCache(connectionName: Eshop.ServiceDefaults.Constants.REDIS_SERVER);
        builder.AddKeyedRedisClient(name: Eshop.ServiceDefaults.Constants.REDIS_PRODUCTS);
        #endregion

        #region Swagger
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
        #endregion

        #region Services
        builder.Services.AddScoped<Product.Domain.Interfaces.IProductService, Product.API.Services.ProductService>();
        builder.Services.AddScoped<Product.Infrastructure.Repositories.IProductRepository, Product.Infrastructure.Repositories.ProductRepository>();
        builder.Services.AddScoped<Product.Domain.Interfaces.IProductCacheService, Product.API.Services.ProductCacheService>();
        #endregion

    }
}
