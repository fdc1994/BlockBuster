using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Ferramenta;
using System.Security.Policy;

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

                    FerramentaSQl.GravarParametro(sqlCommand, id, "ID");
                    FerramentaSQl.GravarParametro(sqlCommand, nome, "NomeUtilizador");
                    FerramentaSQl.GravarParametro(sqlCommand, pass, "Hash");
                    FerramentaSQl.GravarParametro(sqlCommand, cargo, "Cargo");

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
                    FerramentaSQl.GravarParametro(sqlCommand, nome, "NomeUtilizador");
                    FerramentaSQl.GravarParametro(sqlCommand, pass, "Hash");
                    FerramentaSQl.GravarParametro(sqlCommand, cargo, "Cargo");

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
            
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ObterUtilizador", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    FerramentaSQl.GravarParametro(sqlCommand, id, "ID");
           
                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                    {
                        a.Fill(t1);
                    }
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
       
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ObterUtilizadorLogin", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    FerramentaSQl.GravarParametro(sqlCommand, nome, "nome");
                    FerramentaSQl.GravarParametro(sqlCommand, pass, "pass");

                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                    {
                        a.Fill(t1);
                    }
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
                    return t1;
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return null;
        }

        public static DataTable ObterTodosOsClientes(out string erro)
        {
            
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ListarClientes", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(sqlCommand))
                    {
                        a.Fill(t1);
                    }   
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

                    FerramentaSQl.GravarParametro(sqlCommand, id, "ID");

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
