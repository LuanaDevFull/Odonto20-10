using Odonto20_10.Dados;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Odonto20_10.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        AcLogin acLog = new AcLogin();

        [HttpPost]
        public ActionResult Index(ModelLogin verLogin){
            acLog.TestarUsuario(verLogin);

            if(verLogin.usuario != null && verLogin.senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.usuario, false);

                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString(); 

                if(verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString(); //=1
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();//=2
                }

                return RedirectToAction("About", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
        }


        public ActionResult About()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
        }

        public ActionResult menuOpcoes()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Session["tipoLogado2"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                else
                {
                    ViewBag.Message = "Your contact page.";
                    return View();
                }
            }
        }

        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Sem acesso!')</script>");
            ViewBag.Message = "Você não tem acesso a essa página";
            return View();
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}