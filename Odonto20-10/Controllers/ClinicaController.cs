using Microsoft.Ajax.Utilities;
using Odonto20_10.Dados;
using Odonto20_10.Models;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odonto20_10.Controllers
{
    public class ClinicaController : Controller
    {
        AcLogin acLog = new AcLogin();
        // GET: Clinica
        public ActionResult cadLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadLogin(ModelLogin mdLog)
        {
            acLog.TestarLogin(mdLog);
            if (mdLog.confUsuario == "1")
            {
                acLog.inserirLogin(mdLog);
                ViewBag.msg = "Cadastro realizado com sucesso!";
            }
            else if (mdLog.confUsuario == "0")
            {
                ViewBag.msg = "Usuário já Existe!";
            }

            return View();
        }


        public ActionResult ListarLogin()
        {
            return View(acLog.GetModelLogins());
        }

        public ActionResult excluirLogin(string id)
        {
            acLog.DeletarLogin(id);
            return RedirectToAction("ListarLogin");
        }

        public ActionResult editarLogin(string id)
        {
            return View(acLog.GetModelLogins().Find(model => model.usuario == id));
        }

        [HttpPost]
        public ActionResult editarLogin(string id, ModelLogin cm)
        {
            cm.usuario = id.ToString();
            acLog.atualizaLogin(cm);
            ViewBag.msg = "Cadastro Atualizado com sucesso";
            return View();
        }
    }
}