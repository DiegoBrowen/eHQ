using eHQ.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace eHQ.EventBus.Interfaces
{
    public interface IEventBus: IDisposable
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;
    }
}
