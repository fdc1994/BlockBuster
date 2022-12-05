using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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

        private bool admin;

        public bool Admin
        { 
            get { return admin; } 
            set { admin = value; } 
        }
        #endregion

        #region Construtores

        public Utilizador()
        {

        }

        public Utilizador(string nomeUtilizador, string pass, bool administrador)
            : this()
        {
            this.nomeUtilizador =nomeUtilizador;    
            this.pass = pass;   
            this.admin = administrador;
        }

        #endregion

        #region Metodos
        public DataTable ObterUtilizador(int id, out string erro)
        {
            Utilizador utilizador = new Utilizador();
            SqlDataReader dataReader = null;
            erro = string.Empty;

            //V1
            //CamadaDados.Aluno aluno = new CamadaDados.Aluno();
            //ok = aluno.Gravar(this.IDAluno, this.NomeAluno, this.DataNascimento, this.Telefone, out erro);

            //V2

            DataTable t1 = CamadaDados.Utilizadores.ObterUtilizador(id, out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }
        #endregion
    }
}
