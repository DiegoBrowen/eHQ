using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHQ.Estoque.Api.Models
{
    public class EstoqueRevista
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A revista deve ser informada.")]
        public Guid IdRevista { get; set; }
        [Required(ErrorMessage = "A quantidade deve ser informada.")]
        public int Quantidade { get; set; }
    }
}
