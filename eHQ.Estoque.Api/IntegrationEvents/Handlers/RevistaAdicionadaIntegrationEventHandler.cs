using eHQ.Estoque.Api.Infra;
using eHQ.Estoque.Api.IntegrationEvents.Events;
using eHQ.Estoque.Api.Models;
using eHQ.EventBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.IntegrationEvents.Handlers
{
    public class RevistaAdicionadaIntegrationEventHandler : IIntegrationEventHandler<RevistaAdicionadaIntegrationEvent>
    {
        private readonly EstoqueContext _estoqueContext;

        public RevistaAdicionadaIntegrationEventHandler(EstoqueContext estoqueContext)
        {
            _estoqueContext = estoqueContext;
        }

        public Task Handle(RevistaAdicionadaIntegrationEvent @event)
        {
            var revista = new Revista(@event.Id, @event.Ano, @event.Titulo);
            var revistaEstoque = new EstoqueRevista(revista);

            _estoqueContext.EstoqueRevistas.Add(revistaEstoque);

            return _estoqueContext.SaveChangesAsync();
        }
    }
}
