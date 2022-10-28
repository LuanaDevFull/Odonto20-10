using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Odonto20_10.Models
{
    public class ModelDentista
    {
        [Display(Name = "Código do Dentista")]
        public string codDentista { get; set; }

        [Display(Name = "Nome do Dentista")]
        [Required(ErrorMessage = "Insira o Nome")]
        public string nmDentista { get; set; }

        [Display(Name = "Código da Especialidade")]
        public string codEspecialidade { get; set; }
    }
}