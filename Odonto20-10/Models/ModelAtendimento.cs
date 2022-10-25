using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odonto20_10.Models
{
    public class ModelAtendimento
    {
        public string codAtendimento { get; set; } 
        public string dataAtendimento { get; set; } 
        public string horaDentista { get; set; } 
        public string codPaciente { get; set; } 
        public string codDentista { get; set; } 
    }
}