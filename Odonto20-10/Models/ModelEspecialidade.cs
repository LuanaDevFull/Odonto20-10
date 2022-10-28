using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Odonto20_10.Models
{
    public class ModelEspecialidade
    {
        [Display(Name = "Código da Especialidade")]
        public string codEspecialidade { get; set; }

        [Display(Name = "Tipo da Especialidade")]
        [Required(ErrorMessage = "Insira o Tipo")]
        public string tipoEspecialidade { get; set; }   
    }
}