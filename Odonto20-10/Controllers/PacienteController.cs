using Odonto20_10.Dados;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto20_10.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }
        AcPaciente acPac = new AcPaciente();
        public ActionResult cadPaciente()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult cadPaciente(ModelPaciente mdPac)
        {
                acPac.inserirPaciente(mdPac);
                ViewBag.msg = "Cadastro efetuado com sucesso";
                return View();
        }
    }
}