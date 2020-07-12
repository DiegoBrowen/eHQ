using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Produto.Api.Model
{
    public class Revista
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O titulo deve ser informado.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O autor deve ser informado.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O ano deve ser informado.")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "A descrição deve ser informada.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O desenhista deve ser informado.")]
        public string Desenhista { get; set; }
        public Revista()
        {
            Id = Guid.NewGuid();
        }
    }
}
