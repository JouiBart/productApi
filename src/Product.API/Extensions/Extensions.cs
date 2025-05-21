using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Product.API.BackgroudServices;
using Product.API.Services;
using Product.API.Services.v1;
using Product.Domain.Interfaces.v1;
using Product.Domain.Interfaces.v2;
using Product.Infrastructure;
using Product.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Product.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        #region Aspire
        builder.AddSqlServerDbContext<ProductContext>(Eshop.ServiceDefaults.Constants.MSSQL_PRODUCTS);
        builder.AddRedisDistributedCache(connectionName: Eshop.ServiceDefaults.Constants.REDIS_SERVER);
        builder.AddKeyedRedisClient(name: Eshop.ServiceDefaults.Constants.REDIS_PRODUCTS);
        builder.AddRabbitMQClient("product");
        #endregion


        #region Services
        #region v1
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<Product.Infrastructure.Repositories.IProductRepository, Product.Infrastructure.Repositories.ProductRepository>();
        builder.Services.AddScoped<IProductCacheService, ProductCacheService>();
        #endregion

        #region v2
        builder.Services.AddScoped<IProductService_v2, ProductService_v2>();
        builder.Services.AddScoped<Product.Infrastructure.Repositories.v2.IProductRepository_v2, Product.Infrastructure.Repositories.v2.ProductRepository_v2 > ();
        builder.Services.AddScoped<IProductCacheService_v2, ProductCacheService_v2>();
        #endregion


        #endregion

        #region Versioning
        builder.Services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    // reporting api versions will return the headers
                    // "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                }).AddMvc() 
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
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

            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
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

            options.ExampleFilters();
        });

        builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        #endregion


        #region RabbitMQ
        builder.Services.AddHostedService<ProductUpdateStockConsumerService>();
        #endregion

    }
}
