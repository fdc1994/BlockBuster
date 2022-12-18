using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Reservas
    {
        public static DataTable ObterTodasAsReservas(out string erro)
        {
            bool resultado = false;
            erro = string.Empty;


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ListarReservas", sqlCon);
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

        public static Boolean ApagarReserva(int id, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("ApagarReserva", sqlCon);
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

        public static Boolean TerminarReserva(int id, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("TerminarReserva", sqlCon);
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


