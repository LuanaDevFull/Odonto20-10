using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odonto20_10.Models
{
    public class ModelLogin
    {
        public string usuario { get; set; }

        public string senha { get; set; }

        public string confSenha { get; set; }

        public string tipo { get; set; }
    }
}