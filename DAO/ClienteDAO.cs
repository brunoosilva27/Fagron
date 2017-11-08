using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAO
{
    public class ClienteDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

        public List<objCliente> retornaClientes()
        {
            List<objCliente> listaClientes = new List<objCliente>();
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;
            objCliente obj;

            sql = "SELECT * FROM Cliente";
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                SqlDataReader adoDR = cmd.ExecuteReader();

                if (adoDR.HasRows)
                {
                    while (adoDR.Read())
                    {
                        obj = new objCliente();
                        obj.Id = Convert.ToInt32(adoDR["Id"]);
                        obj.Nome = adoDR["Nome"].ToString();
                        obj.SobreNome = adoDR["SobreNome"].ToString();
                        obj.Idade = Convert.ToInt32(adoDR["Idade"]);
                        obj.DataNascimento = Convert.ToDateTime(adoDR["DataNascimento"]);
                        obj.ProfissaoId = Convert.ToInt32(adoDR["ProfissaoId"]);
                        listaClientes.Add(obj);
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaClientes;
        }

        public objCliente buscaClientes(int idCliente)
        {
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;
            objCliente obj = new objCliente(); ;

            sql = string.Format("SELECT * FROM Cliente WHERE Id = {0}" , idCliente);
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                SqlDataReader adoDR = cmd.ExecuteReader();

                if (adoDR.HasRows)
                {
                    while (adoDR.Read())
                    {
                        obj.Id = Convert.ToInt32(adoDR["Id"]);
                        obj.Nome = adoDR["Nome"].ToString();
                        obj.SobreNome = adoDR["SobreNome"].ToString();
                        obj.Idade = Convert.ToInt32(adoDR["Idade"]);
                        obj.DataNascimento = Convert.ToDateTime(adoDR["DataNascimento"]);
                        obj.ProfissaoId = Convert.ToInt32(adoDR["ProfissaoId"]);
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return obj;
        }

        public void deletaCliente(int idCliente)
        {
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;

            sql = string.Format("DELETE FROM Cliente WHERE Id = {0}", idCliente);
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insereCliente(objCliente objCliente)
        {
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;

            sql = string.Format("INSERT INTO Cliente(Nome,SobreNome,DataNascimento,Idade,ProfissaoId) VALUES ('{0}','{1}','{2}',{3},{4})", objCliente.Nome, objCliente.SobreNome, objCliente.DataNascimento, objCliente.Idade, objCliente.ProfissaoId);
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void alteraCliente(objCliente objCliente)
        {
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;

            sql = string.Format("UPDATE Cliente SET Nome = '{0}',SobreNome = '{1}',DataNascimento = '{2}',Idade = {3},ProfissaoId = {4} WHERE Id = {5})", objCliente.Nome, objCliente.SobreNome, objCliente.DataNascimento, objCliente.Idade, objCliente.ProfissaoId,objCliente.Id);
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class objCliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }

        public int ProfissaoId { get; set; }
    }
}