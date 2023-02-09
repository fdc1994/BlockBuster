using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramenta
{
    public class FerramentaSQl
    {

        /**
        * 
        * Simplifica o código para evitar repetição e verbosidade
        * 
        * Tem overload de int e string
        * 
        * **/
        public static void GravarParametro(SqlCommand comando, int valor, string nomeParametro)
        {
            SqlParameter sqlParameter = new SqlParameter(nomeParametro, SqlDbType.Int);
            sqlParameter.Direction = System.Data.ParameterDirection.Input;
            sqlParameter.Value = valor;
            comando.Parameters.Add(sqlParameter);
        }

        public static void GravarParametro(SqlCommand comando, string valor, string nomeParametro)
        {
            SqlParameter sqlParameter = new SqlParameter(nomeParametro, SqlDbType.NVarChar, 80);
            sqlParameter.Direction = System.Data.ParameterDirection.Input;
            sqlParameter.Value = valor;
            comando.Parameters.Add(sqlParameter);
        }
    }
}
