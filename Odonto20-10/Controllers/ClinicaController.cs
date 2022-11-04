using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Odonto20_10.Dados;
using Odonto20_10.Models;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Odonto20_10.Controllers
{
    public class ClinicaController : Controller
    {
        AcLogin acLog = new AcLogin();
        AcClinica acClinic = new AcClinica();
        ModelDentista mdDent = new ModelDentista();

        //LOGIN
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

        //ESPECIALIDADE
        public ActionResult cadEspec()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadEspec(ModelEspecialidade mdEspec)
        {
            acClinic.inserirEspecialidade(mdEspec);
            ViewBag.msg = "Cadastro efetuado com sucesso";
            return View();
        }

        public ActionResult ListarEspec()
        {
            return View(acClinic.GetEspecialidades());
        }

        public ActionResult excluirEspec(int id)
        {
            acClinic.DeletarEspecialidade(id);
            return RedirectToAction("ListarEspec");
        }

        public ActionResult editarEspec(string id)
        {
            return View(acClinic.GetEspecialidades().Find(model => model.codEspecialidade == id));
        }

        [HttpPost]
        public ActionResult editarEspec(int id, ModelEspecialidade cm)
        {
            cm.codEspecialidade = id.ToString();
            acClinic.atualizaEspecialidade(cm);
            ViewBag.msg = "Cadastro Atualizado com sucesso";
            return View();
        }

        //DENTISTA
        public void CarregaEspecialidade()
        {
            List<SelectListItem> especialidades = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdOdonto;User=root;pwd=12345678"))
            {
                con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from tbEspecialidade;", con);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        especialidades.Add(new SelectListItem
                        {
                            Text = rdr[1].ToString(),
                            Value = rdr[0].ToString()
                        });
                    }
                  con.Close();
            }
            ViewBag.especialidades = new SelectList(especialidades, "Value", "Text");
        }
        public ActionResult cadDent()
        {
            CarregaEspecialidade();
            return View();
        }

        [HttpPost]
        public ActionResult cadDent(ModelDentista mdDent)
        {
            CarregaEspecialidade();
            mdDent.codEspecialidade = Request["especialidades"];
            mdDent.nmDentista = Request["txtNmDent"];
            acClinic.inserirDentista(mdDent);
            ViewBag.msg = "Cadastro efetuado com sucesso";
            return View();
        }

        public ActionResult ListarDent()
        {
            return View(acClinic.GetDentistas());
        }

        public ActionResult excluirDent(int id)
        {
            acClinic.DeletarDentista(id);
            return RedirectToAction("ListarDent");
        }

        public ActionResult editarDent(string id)
        {
            CarregaEspecialidade();
            return View(acClinic.GetDentistas().Find(model => model.codDentista == id));
        }

        [HttpPost]
        public ActionResult editarDent(int id, ModelDentista cm)
        {
            CarregaEspecialidade();
            cm.codEspecialidade = Request["especialidades"];
            cm.codDentista = id.ToString();
            acClinic.atualizaDentista(cm);
            ViewBag.msg = "Cadastro Atualizado com sucesso";
            return View();
        }
    }
}