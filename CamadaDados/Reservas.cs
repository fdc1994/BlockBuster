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
    public class Reservas
    {
        public static DataTable ObterTodasAsReservas(out string erro)
        {
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

        public static Boolean GravarReserva(int idCliente, string nomeCliente, int idFilme, string nomeFilme, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString))

                {
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("GravarNovaReserva", sqlCon);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    FerramentaSQl.GravarParametro(sqlCommand, idCliente, "IDCliente");
                    FerramentaSQl.GravarParametro(sqlCommand, idFilme, "IDFilme");
                    FerramentaSQl.GravarParametro(sqlCommand, nomeCliente, "NomeCliente");
                    FerramentaSQl.GravarParametro(sqlCommand, nomeFilme, "NomeFilme");

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


