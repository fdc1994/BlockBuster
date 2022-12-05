using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Utilizadores
    {
        public bool Gravar(string idAluno, string nomeAluno, DateTime dataNascimento, string telefone, out string erro)
        {
            erro = string.Empty;

            bool resultado = Utilizadores.GravarUtilizador(idAluno, nomeAluno, dataNascimento, telefone, out erro);

            return resultado;
        }

        public static bool GravarUtilizador(string id, string nomeAluno, DateTime dataNascimento, string telefone, out string erro)
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

                    sqlParameter = new SqlParameter("NomeAluno", System.Data.SqlDbType.NVarChar, 80);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = nomeAluno;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("DataNascimento", System.Data.SqlDbType.DateTime);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = dataNascimento;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter("Telefone", System.Data.SqlDbType.NVarChar, 30);
                    sqlParameter.Direction = System.Data.ParameterDirection.Input;
                    sqlParameter.Value = telefone;

                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlCommand.ExecuteNonQuery();
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
    }
}
