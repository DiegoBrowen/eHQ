using eHQ.EventBus.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eHQ.IntegrationEventLog.Interfaces
{
    public interface IIntegrationEventLogService
    {
        Task SaveEventAsync(IntegrationEvent @event, DbContext dbContext, CancellationToken cancellationToken);
        Task EventPublishedAsync(Guid eventId, CancellationToken cancellationToken);
        Task EventInProgressAsync(Guid eventId, CancellationToken cancellationToken);
        Task EventFailedAsync(Guid eventId, CancellationToken cancellationToken);
    }
}
