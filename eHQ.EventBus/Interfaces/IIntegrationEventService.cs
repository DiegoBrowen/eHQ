using eHQ.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eHQ.EventBus.Interfaces
{
    public interface IIntegrationEventService
    {
        Task PublishEventAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken);
    }
}
