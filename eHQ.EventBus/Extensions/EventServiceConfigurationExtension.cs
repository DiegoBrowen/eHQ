using eHQ.EventBus.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace eHQ.EventBus.Extensions
{
    public static class EventServiceConfigurationExtension
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureConnection(services, configuration);
            services.AddSingleton<IEventBusSubscriptionsManager, EventBusSubscriptionsManager>();
            
            var queue = configuration["Queue"];
            services.AddSingleton<IEventBus, EventBus>(sp =>
            {
                var connection = sp.GetRequiredService<IMqConnection>();
                var logger = sp.GetRequiredService<ILogger<EventBus>>();

                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var serviceProvider = services.BuildServiceProvider();

                return new EventBus(connection, logger, eventBusSubcriptionsManager, serviceProvider, queue);
            });
            return services;
        }

        public static IServiceCollection AddIntegrationEventService<TIntegrationEventServiceInterface, TIntegrationEventService>(this IServiceCollection services)
            where TIntegrationEventServiceInterface : IIntegrationEventService
            where TIntegrationEventService : TIntegrationEventServiceInterface
        {
            services.AddTransient(typeof(TIntegrationEventServiceInterface), typeof(TIntegrationEventService));
            return services;
        }

        private static void ConfigureConnection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMqConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<IMqConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
                {
                    factory.UserName = configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
                {
                    factory.Password = configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new MqConnection(factory, logger);
            });

        }
    }
}
