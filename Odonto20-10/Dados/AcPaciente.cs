using MySql.Data.MySqlClient;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Odonto20_10.Dados
{
    public class AcPaciente
    {
        Conexao con = new Conexao();

        public void inserirPaciente(ModelPaciente mdPac)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPaciente values(default, @nmPaciente, @CPFPaciente, @emailPaciente, @telPaciente, @sexoPaciente)", con.MyConectarBD());

            cmd.Parameters.Add("@nmPaciente", MySqlDbType.VarChar).Value = mdPac.nmPaciente;
            cmd.Parameters.Add("@CPFPaciente", MySqlDbType.VarChar).Value = mdPac.CPFPaciente;
            cmd.Parameters.Add("@emailPaciente", MySqlDbType.VarChar).Value = mdPac.emailPaciente;
            cmd.Parameters.Add("@telPaciente", MySqlDbType.VarChar).Value = mdPac.telPaciente;
            cmd.Parameters.Add("@sexoPaciente", MySqlDbType.VarChar).Value = mdPac.sexoPaciente;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<ModelPaciente> GetPaciente()
        {

            List<ModelPaciente> PacienteList = new List<ModelPaciente>();
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();
            foreach (DataRow dr in dt.Rows)
            {
                PacienteList.Add(

                    new ModelPaciente
                    {
                        codPaciente = Convert.ToString(dr["codPaciente"]),
                        nmPaciente = Convert.ToString(dr["nmPaciente"]),
                        CPFPaciente = Convert.ToString(dr["CPFPaciente"]),
                        emailPaciente = Convert.ToString(dr["emailPaciente"]),
                        telPaciente = Convert.ToString(dr["telPaciente"]),
                        sexoPaciente = Convert.ToString(dr["sexoPaciente"]),
                    });

            }
            return PacienteList;
        }
        
        public bool DeletePaciente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbPaciente where codPaciente=@id", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizaPaciente(ModelPaciente mdPac)
        {
            MySqlCommand cmd = new MySqlCommand("update tbPaciente set nmPaciente=@nmPaciente, CPFPaciente=@CPFPaciente, emailPaciente=@emailPaciente, telPaciente=@telPaciente, sexoPaciente=@sexoPaciente where codPaciente=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@nmPaciente", mdPac.nmPaciente);
            cmd.Parameters.AddWithValue("@CPFPaciente", mdPac.CPFPaciente);
            cmd.Parameters.AddWithValue("@emailPaciente", mdPac.emailPaciente);
            cmd.Parameters.AddWithValue("@telPaciente", mdPac.telPaciente);
            cmd.Parameters.AddWithValue("@sexoPaciente", mdPac.sexoPaciente);
            cmd.Parameters.AddWithValue("@cod", mdPac.codPaciente);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}