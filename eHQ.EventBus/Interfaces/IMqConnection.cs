using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace eHQ.EventBus.Interfaces
{
    public interface IMqConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
