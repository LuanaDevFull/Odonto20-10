using MySql.Data.MySqlClient;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Odonto20_10.Dados
{
    
    public class AcLogin
    {
        Conexao con = new Conexao();

        public void TestarUsuario(ModelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbLogin where usuario = @usuario and senha = @senha", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.usuario = Convert.ToString(leitor["usuario"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }
            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            }
            con.MyDesconectarBD();
        }
    }
}