using eHQ.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.IntegrationEvents.Events
{
    public class RevistaAdicionadaIntegrationEvent : IntegrationEvent
    {
        public Guid RevistaId { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
    }
}
