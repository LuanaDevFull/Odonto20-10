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
         AcPaciente acPac = new AcPaciente();      
        public ActionResult cadPaciente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
       
        [HttpPost]
        public ActionResult cadPaciente(ModelPaciente mdPac)
        {
                mdPac.sexoPaciente = Request["sexoPaciente"];
                acPac.inserirPaciente(mdPac);
                ViewBag.msg = "Cadastro efetuado com sucesso";
                return View();
        }

        public ActionResult ListarPaciente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(acPac.GetPaciente());
            }
        }

        public ActionResult excluirPaciente(int id)
        {
            acPac.DeletePaciente(id);
            return RedirectToAction("ListarPaciente");
        }



        public ActionResult editarPaciente(string id)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(acPac.GetPaciente().Find(model => model.codPaciente == id));
            }
        }

        [HttpPost]
        public ActionResult editarPaciente(int id, ModelPaciente cm)
        {
            cm.sexoPaciente = Request["sexoPaciente"];
            cm.codPaciente = id.ToString();
            acPac.atualizaPaciente(cm);
            ViewBag.msg = "Cadastro Atualizado com sucesso";
            return View();
        }


    }
}