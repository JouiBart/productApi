using Eshop.ServiceDefaults.RabbitMQ;
using Product.Domain.Interfaces.v2;
using Product.Domain.Models;
using Product.Infrastructure.Repositories.v2;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Product.API.BackgroudServices
{
    public class ProductUpdateStockConsumerService : BackgroundService
    {
        private readonly ILogger<ProductUpdateStockConsumerService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private IConnection _messageConnection;

        private string _queuesName = ProductQueues.UpdateStock;

        public ProductUpdateStockConsumerService(ILogger<ProductUpdateStockConsumerService> logger, IServiceProvider serviceProvider, IConnection messageConnection)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _messageConnection = messageConnection;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var channel = _messageConnection.CreateModel();
                channel.QueueDeclare(_queuesName, exclusive: false, durable: true);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var data = new
                    {
                        LogAt = DateTimeOffset.UtcNow.ToString("O"),
                        ea.Exchange,
                        ea.RoutingKey,
                        Message = JsonSerializer.Deserialize<object>(ea.Body.ToArray())
                    };


                    var stock = JsonSerializer.Deserialize<UpdateStock>(ea.Body.ToArray());
                    
                    if (stock == null)
                    {
                        _logger.LogError("Received null message. Json: {text}", data.Message);
                    }

                    int currentStock = 0;

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var productRepository = scope.ServiceProvider.GetRequiredService<IProductCacheService_v2>();
                        currentStock = productRepository.UpdateStock(stock).GetAwaiter().GetResult();
                    }

                    

                    _logger.LogInformation("{logInformation}", JsonSerializer.Serialize(data.Message));
                };

                channel.BasicConsume(queue: _queuesName, autoAck: true, consumer: consumer);

                stoppingToken.Register(() =>
                {
                    channel.Close();
                    channel.Dispose();
                });

                // Prevents the service from exiting immediately
                Task.Delay(Timeout.Infinite, stoppingToken).Wait();
            }, stoppingToken);
        }

    }
}