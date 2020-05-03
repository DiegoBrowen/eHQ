using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Models
{
    public class EstoqueRevista
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public virtual Revista Revista { get; set; }
        protected EstoqueRevista()
        {
        }

        public EstoqueRevista(Revista revista)
        {
            Id = Guid.NewGuid();
            Revista = revista;
        }
    }
}
