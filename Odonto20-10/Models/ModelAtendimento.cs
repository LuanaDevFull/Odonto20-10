using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Odonto20_10.Models
{
    public class ModelAtendimento
    {
        [Display(Name = "Código do Atendimento")]
        public string codAtendimento { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Insira uma Data")]
        public string dataAtendimento { get; set; }

        [Required(ErrorMessage = "Insira a Hora")]
        [Display(Name = "Hora")]
        public string horaDentista { get; set; }

        [Display(Name = "Código do Paciente")]
        public string codPaciente { get; set; }

        [Display(Name = "Código do Dentista")]
        public string codDentista { get; set; }

        public string confAgendamento { get; set; }

    }
}