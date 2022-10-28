using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Odonto20_10.Models
{
    public class ModelLogin
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Insira o Usuário")]
        public string usuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Insira a Senha")]
        public string senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("senha", ErrorMessage = "Senhas não correspondem!")]
        public string confSenha { get; set; }

        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        public string confUsuario { get; set; }
        
    }
}