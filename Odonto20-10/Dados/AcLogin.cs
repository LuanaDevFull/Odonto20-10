using MySql.Data.MySqlClient;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Odonto20_10.Dados
{
    
    public class AcLogin
    {
        Conexao con = new Conexao();

        public void TestarLogin(ModelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where usuario = @user", con.MyConectarBD());

            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user.usuario;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {

                    user.confUsuario = "0";
                }
            }
            else
            {
                user.confUsuario = "1";
            }

            con.MyDesconectarBD();
        }

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

        // INSERIR NA TABELA LOGIN
        public void inserirLogin(ModelLogin mdLog)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLogin values(@usuario, @senha, @tipo)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = mdLog.usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = mdLog.senha;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = mdLog.tipo;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        //DELETAR LOGIN
        public bool DeletarLogin(string id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbLogin where usuario=@id", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }


        //ATUALIZAR LOGIN
        public bool atualizaLogin(ModelLogin mdLog)
        {
            MySqlCommand cmd = new MySqlCommand("update tbLogin set usuario=@usuario, senha=@senha, tipo=@tipo where usuario=@usuario", con.MyConectarBD());
           
            cmd.Parameters.AddWithValue("@senha", mdLog.senha);
            cmd.Parameters.AddWithValue("@tipo", mdLog.tipo);
            cmd.Parameters.AddWithValue("@usuario", mdLog.usuario);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<ModelLogin> GetModelLogins()
        {

            List<ModelLogin> LoginList = new List<ModelLogin>();
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();
            foreach (DataRow dr in dt.Rows)
            {
                LoginList.Add(

                    new ModelLogin
                    {
                        usuario = Convert.ToString(dr["usuario"]),
                        senha = Convert.ToString(dr["senha"]),
                        tipo = Convert.ToString(dr["tipo"]),
                    });

            }
            return LoginList;
        }

    }
}