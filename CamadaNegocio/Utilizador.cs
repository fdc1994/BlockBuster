using CamadaDados;
using Ferramenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CamadaNegocio
{
    public class Utilizador
    {
        #region Propriedades
        private int idUtilizador;

        public int IdUtilizador
        {
            get { return idUtilizador; }
            set { idUtilizador = value; }
        }


        private string nomeUtilizador;

        public string NomeUtilizador
        {
            get { return nomeUtilizador; }
            set { nomeUtilizador = value; }
        }

        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        private EnumUtilizadores status;

        public EnumUtilizadores Status
        { 
            get { return status; } 
            set { status = value; } 
        }
        #endregion

        #region Construtores

        public Utilizador()
        {

        }

        public Utilizador(int id, string nomeUtilizador, string pass, EnumUtilizadores status)
            : this()
        {
            this.idUtilizador =id;  
            this.nomeUtilizador =nomeUtilizador;    
            this.pass = pass;   
            this.status = status;
        }

        #endregion

        #region Metodos
        public DataTable ObterUtilizador(int id, out string erro)
        {
            Utilizador utilizador = new Utilizador();
            SqlDataReader dataReader = null;
            erro = string.Empty;

            DataTable t1 = CamadaDados.Utilizadores.ObterUtilizador(id, out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }

        public static int ObterUtilizadorLogin(string nome, string pass, out string erro)
        {
            DataTable t1 = CamadaDados.Utilizadores.ObterUtilizadorLogin(nome, pass, out erro);
            if (t1 != null && t1.Rows.Count > 0)
            {
                //return first result
                return (int)t1.Rows[0][0];
            }
            return -1;
           
        }

        public static DataTable ObterTodosOsUtilizadores(out string erro)
        {
            Utilizador utilizador = new Utilizador();
            SqlDataReader dataReader = null;
            erro = string.Empty;
            DataTable t1 = CamadaDados.Utilizadores.ObterTodosOsUtilizadores(out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }

        public void GravarUtilizador(string nome, string pass, int cargo, out string erro)
        {
            CamadaDados.Utilizadores.GravarUtilizador(this.idUtilizador, nome, pass, cargo, out erro);
        }

        public void GravarUtilizador(out string erro)
        {
            CamadaDados.Utilizadores.GravarUtilizador(this.idUtilizador, this.NomeUtilizador, this.pass, (int)this.status, out erro);
        }
        #endregion
    }
}
