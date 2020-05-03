using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Models
{
    public class Revista
    {
        public Revista(Guid id, int ano, string titulo)
        {
            Id = id;
            Ano = ano;
            Titulo = titulo;
        }

        public Guid Id { get; set; }
        public int Ano { get; set; }
        public string Titulo { get; set; }
    }
}
