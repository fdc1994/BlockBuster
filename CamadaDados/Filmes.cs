using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Filmes
    {

        public bool Gravar(int id, string nome, int quantidade, out string erro)
        {
            erro = string.Empty;

            bool resultado = Filmes.GravarFilme(id, nome, quantidade, out erro);

            return resultado;
        }

        public static bool GravarFilme(int id, string nome, int cargo, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarFilme", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("ID", SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = id;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("NomeFilme", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nome;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Quantidade", System.Data.SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = cargo;

                    sqlCommand.Parameters.Add(sqlParameter);

                    int result = sqlCommand.ExecuteNonQuery();
                    sqlCon.Close();

                    resultado = true;

                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }
        public static bool GravarNovoFilme(string nome, int quantidade, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarNovoFilme", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = sqlParameter = new SqlParameter("NomeFilme", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nome;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Quantidade", System.Data.SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = quantidade;

                    sqlCommand.Parameters.Add(sqlParameter);

                    int result = sqlCommand.ExecuteNonQuery();
                    sqlCon.Close();

                    resultado = true;

                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }

        public static DataTable ObterTodosOsFilmes(out string erro)
        {
            bool resultado = false;
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ListarFilmes", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                    {
                        a.Fill(t1);
                    }
                    resultado = true;
                    return t1;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return null;
        }

        public static bool ApagarFilme(int id, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("EliminarFilme", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("ID", SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = id;
                    sqlCommand.Parameters.Add(sqlParameter);

                    int result = sqlCommand.ExecuteNonQuery();
                    sqlCon.Close();

                    resultado = true;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }

        public static Boolean AtualizarFilme(int id, int quantidade, string nomeFilme, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarNovaQuantidadeFilme", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("ID", SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = id;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Quantidade", SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = quantidade;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = sqlParameter = new SqlParameter("NomeFilme", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nomeFilme;
                    sqlCommand.Parameters.Add(sqlParameter);

                    int result = sqlCommand.ExecuteNonQuery();
                    sqlCon.Close();

                    resultado = true;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }
    }



  
}
