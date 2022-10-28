using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Odonto20_10.Models
{
    public class ModelPaciente
    {
        [Display(Name = "Código do Paciente")]
        public string codPaciente { get; set; }

        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "Insira o Nome")]
        public string nmPaciente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Insira o CPF")]
        public string CPFPaciente { get; set; }

        [Required(ErrorMessage = "Insira o E-mail")]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", ErrorMessage = "use '@' e '.com'")]
        public string emailPaciente { get; set; }

        [Required(ErrorMessage = "Insira o Telefone")]
        [Display(Name = "Telefone")]
        public string telPaciente { get; set; }

        [Display(Name = "Sexo")]
        public string sexoPaciente { get; set; }

    }
}