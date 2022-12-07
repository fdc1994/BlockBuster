using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CamadaDados
{
    public class Utilizadores
    {
        public bool Gravar(int id, string nome, string pass, int cargo, out string erro)
        {
            erro = string.Empty;

            bool resultado = Utilizadores.GravarUtilizador(id, nome, pass, cargo, out erro);

            return resultado;
        }

        public static bool GravarUtilizador(int id, string nome, string pass, int cargo, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarUtilizador", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("ID", SqlDbType.Int);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = id;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("NomeUtilizador", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nome;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Hash", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = pass;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Cargo", System.Data.SqlDbType.Int);
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

        public static bool GravarNovoUtilizador(string nome, string pass, int cargo, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarNovoUtilizador", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = sqlParameter = new SqlParameter("NomeUtilizador", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nome;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Hash", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = pass;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Cargo", System.Data.SqlDbType.Int);
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

        public static DataTable ObterUtilizador(int id, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ObterUtilizador", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("ID", SqlDbType.NVarChar, 10);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = id;

                    sqlCommand.Parameters.Add(sqlParameter);

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

        public static DataTable ObterUtilizadorLogin(string nome, string pass, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ObterUtilizadorLogin", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("nome", SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nome;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("pass", SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = pass;
                    sqlCommand.Parameters.Add(sqlParameter);

                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                    {
                        a.Fill(t1);
                    }
                    resultado = true;
                    sqlCon.Close();
                    return t1;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return null;
        }

        public static DataTable ObterTodosOsUtilizadores(out string erro)
        {
            bool resultado = false;
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ListarUtilizadores", sqlCon);
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

        public static DataTable ObterUltimoRegistoUtilizador(out string erro)
        {
            bool resultado = false;
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ObterUltimoRegistoUtilizador", sqlCon);
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

        public static bool ApagarUtilizador(int id, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("EliminarUtilizador", sqlCon);
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

    }

}
