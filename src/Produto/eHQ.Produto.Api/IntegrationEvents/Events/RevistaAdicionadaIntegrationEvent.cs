using eHQ.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.IntegrationEvents.Events
{
    public class RevistaAdicionadaIntegrationEvent: IntegrationEvent
    {
        public Guid RevistaId { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }

        public RevistaAdicionadaIntegrationEvent(Guid revistaId, string titulo, int ano)
        {
            RevistaId = revistaId;
            Titulo = titulo;
            Ano = ano;
        }
    }
}
