using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAO
{
    public class ProfissaoDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

        public List<objProfissao> retornaProfissoes()
        {
            List<objProfissao> listaProfissoes = new List<objProfissao>();
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string sql = null;
            objProfissao obj;

            sql = "SELECT * FROM Profissao";
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
                        obj = new objProfissao();
                        obj.Id = Convert.ToInt32(adoDR["Id"]);
                        obj.Descricao = adoDR["Descricao"].ToString();
                        listaProfissoes.Add(obj);
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaProfissoes;
        }

    }

    public class objProfissao
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}