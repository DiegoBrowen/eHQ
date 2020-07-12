using eHQ.EventBus.Events;
using eHQ.EventBus.Interfaces;
using eHQ.IntegrationEventLog.Interfaces;
using eHQ.Produto.Api.Data;
using eHQ.Produto.Api.IntegrationEvents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.IntegrationEvents.Services
{
    public class ProdutoIntegrationEventService : IProdutoIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ProdutoContext _produtoContext;
        private readonly IIntegrationEventLogService _integrationEventLogService;
        public ProdutoIntegrationEventService(IEventBus eventBus,
                                              ProdutoContext produtoContext,
                                              IIntegrationEventLogService integrationEventLogService)
        {
            _eventBus = eventBus;
            _produtoContext = produtoContext;
            _integrationEventLogService = integrationEventLogService;
        }


        public async Task PublishEventAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            try
            {
                await _integrationEventLogService.EventInProgressAsync(integrationEvent.Id, cancellationToken);
                _eventBus.Publish(integrationEvent);
                await _integrationEventLogService.EventPublishedAsync(integrationEvent.Id, cancellationToken);
            }
            catch
            {
                await _integrationEventLogService.EventFailedAsync(integrationEvent.Id, cancellationToken);
            }
        }

        public async Task SaveEventAndDataAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            await _integrationEventLogService.SaveEventAsync(integrationEvent, _produtoContext, cancellationToken);
        }
    }
}
