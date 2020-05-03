using eHQ.EventBus.Events;
using eHQ.EventBus.Interfaces;
using eHQ.Produto.Api.IntegrationEvents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.IntegrationEvents.Services
{
    public class ProdutoIntegrationEventService : IProdutoIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        public ProdutoIntegrationEventService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }


        public Task PublishEventAsync(IntegrationEvent integrationEvent)
        {
            SaveEventAsync(integrationEvent);
            _eventBus.Publish(integrationEvent);
            //implementar futuramente a parte do log;
            return Task.CompletedTask;
        }

        private Task SaveEventAsync(IntegrationEvent integrationEvent)
        {
            //implentar futuramente
            return Task.CompletedTask;
        }
    }
}
