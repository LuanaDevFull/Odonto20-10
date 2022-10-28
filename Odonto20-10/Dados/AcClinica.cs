using MySql.Data.MySqlClient;
using Odonto20_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odonto20_10.Dados
{
    public class AcClinica
    {
        Conexao con = new Conexao();

        // INSERIR NA TABELA ESPECIALIDADE
        public void inserirEspecialidade(ModelEspecialidade mdEspec)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbEspecialidade values(default, @tipoEspecialidade)", con.MyConectarBD());

            cmd.Parameters.Add("@tipoEspecialidade", MySqlDbType.VarChar).Value = mdEspec.tipoEspecialidade;
            
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        // INSERIR NA TABELA ATENDIMENTO
        public void inserirAtendimento(ModelAtendimento mdAtend)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAtendimento values(default, @dataAtendimento, @horaDentista, @codPaciente, @codDentista)", con.MyConectarBD());

            cmd.Parameters.Add("@dataAtendimento", MySqlDbType.VarChar).Value = mdAtend.dataAtendimento;
            cmd.Parameters.Add("@horaDentista", MySqlDbType.VarChar).Value = mdAtend.horaDentista;
            cmd.Parameters.Add("@codPaciente", MySqlDbType.VarChar).Value = mdAtend.codPaciente;
            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = mdAtend.codDentista;
           
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void TestarAgenda(ModelAtendimento agenda)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAtendimento where dataAtendimento = @data and horaDentista = @hora ", con.MyConectarBD());

            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = agenda.dataAtendimento;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = agenda.horaDentista;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {

                    agenda.confAgendamento = "0";
                }
            }
            else
            {
                agenda.confAgendamento = "1";
            }

            con.MyDesconectarBD();
        }


        // INSERIR NA TABELA DENTISTA
        public void inserirDentista(ModelDentista mdDent)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbDentista values(default, @nmDentista, @codEspecialidade)", con.MyConectarBD());

            cmd.Parameters.Add("@nmDentista", MySqlDbType.VarChar).Value = mdDent.nmDentista;
            cmd.Parameters.Add("@codEspecialidade", MySqlDbType.VarChar).Value = mdDent.codEspecialidade;
            
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
        
        //DELETAR ESPECIALIDADE

        public bool DeletarEspecialidade(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbEspecialidade where codEspecialidade=@id", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //DELETAR DENTISTA

        public bool DeletarDentista(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbDentista where codDentista=@id", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //DELETAR ATENDIMENTO

        public bool DeletarAtendimento(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbAtendimento where codAtendimento=@id", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //ATUALIZAR ESPECIALIDADE

        public bool atualizaEspecialidade(ModelEspecialidade mdEspec)
        {
            MySqlCommand cmd = new MySqlCommand("update tbEspecialidade set tipoEspecialidade=@tipoEspecialidad where codEspecialidade=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@tipoEspecialidade", mdEspec.tipoEspecialidade);
            cmd.Parameters.AddWithValue("@cod", mdEspec.codEspecialidade);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //ATUALIZAR DENTISTA

        public bool atualizaDentista(ModelDentista mdDent)
        {
            MySqlCommand cmd = new MySqlCommand("update tbDentista set nmDentista=@nmDentista, codEspecialidade=@codEspecialidade where codDentista=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@nmDentista", mdDent.nmDentista);
            cmd.Parameters.AddWithValue("@codEspecialidade", mdDent.codEspecialidade);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }

        //ATUALIZAR DENTISTA

        public bool atualizaAtendimento(ModelAtendimento mdAtend)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAtendimento set dataAtendimento=@data, horaDentista=@hora, codPaciente=@codPaciente, codDentista=@codDentista  where codAtendimento=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@data", mdAtend.dataAtendimento);
            cmd.Parameters.AddWithValue("@hora", mdAtend.horaDentista);
            cmd.Parameters.AddWithValue("@codPaciente", mdAtend.codPaciente);
            cmd.Parameters.AddWithValue("@codDentista", mdAtend.codDentista);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}