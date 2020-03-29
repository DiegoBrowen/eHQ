using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.Model
{
    public class Revista
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public string Desenhista { get; set; }
    }
}
