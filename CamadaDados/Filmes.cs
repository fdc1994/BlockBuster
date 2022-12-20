using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferramenta;

namespace CamadaDados
{
    public class Filmes
    {

        public bool Gravar(int id, string nome, int quantidade, out string erro)
        {
            erro = string.Empty;

            bool resultado = Filmes.AtualizarFilme(id, nome, quantidade, out erro);

            return resultado;
        }

        public static bool AtualizarFilme(int id, string nome, int quantidade, out string erro)
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

                    FerramentaSQl.GravarParametro(sqlCommand, id, "ID");
                    FerramentaSQl.GravarParametro(sqlCommand, nome, "NomeFilme");
                    FerramentaSQl.GravarParametro(sqlCommand, quantidade, "Quantidade");

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

                    FerramentaSQl.GravarParametro(sqlCommand, nome, "NomeFilme");
                    FerramentaSQl.GravarParametro(sqlCommand, quantidade, "Quantidade");

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

                    FerramentaSQl.GravarParametro(sqlCommand, id, "ID");
                    FerramentaSQl.GravarParametro(sqlCommand, nomeFilme, "NomeFilme");
                    FerramentaSQl.GravarParametro(sqlCommand, quantidade, "Quantidade");

                   

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
