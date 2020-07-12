using eHQ.EventBus.Events;
using eHQ.EventBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.IntegrationEvents.Interfaces
{
    public interface IProdutoIntegrationEventService: IIntegrationEventService
    {
        public Task SaveEventAndDataAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken);
    }
}
