using CamadaDados;
using FerramentaReservas;
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

        private FerramentaUtilizadores.EnumUtilizadores status;

        public FerramentaUtilizadores.EnumUtilizadores Status
        { 
            get { return status; } 
            set { status = value; } 
        }
        #endregion

        #region Construtores

        public Utilizador()
        {

        }

        public Utilizador(int id, string nomeUtilizador, string pass, FerramentaUtilizadores.EnumUtilizadores status)
            : this()
        {
            this.idUtilizador =id;  
            this.nomeUtilizador =nomeUtilizador;    
            this.pass = pass;   
            this.status = status;
        }

        public Utilizador(string nomeUtilizador, string pass, FerramentaUtilizadores.EnumUtilizadores status)
            : this()
        {
            this.nomeUtilizador = nomeUtilizador;
            this.pass = pass;
            this.status = status;
        }

        #endregion

        #region Metodos
        public DataTable ObterTabelaUtilizador(int id, out string erro)
        {
            // Obtem todos os utilizadores
            Utilizador utilizador = new Utilizador();
            erro = string.Empty;

            DataTable t1 = CamadaDados.Utilizadores.ObterUtilizador(id, out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }

        public Utilizador ObterUtilizador(int id, out string erro)
        {
            // Obtem um utilizador especifico
            erro = string.Empty;

            DataTable t1 = CamadaDados.Utilizadores.ObterUtilizador(id, out erro);
            foreach (DataRow item in t1.Rows)
            {
                return new Utilizador((int)item[0], (string)item[1], (string)item[2], (FerramentaUtilizadores.EnumUtilizadores)item[3]);
            }
            return new Utilizador();
        }

        public static Utilizador ObterUtilizadorLogin(string nome, string pass, out string erro)
        {
             /**
              * Obtem um utilizador para o login
              * estes métodos deviam de conter apenas hashs de strings
              * mas para motivos académicos decidi deixar a string em si para análise mais fácil
              **/
             DataTable t1 = CamadaDados.Utilizadores.ObterUtilizadorLogin(nome, pass, out erro);
            if (t1 != null && t1.Rows.Count > 0)
            {
                try
                {
                    DataRow row = t1.Rows[0];
                    //return first result
                    return new Utilizador((int)row[0], (string)row[1], (string)row[2], (FerramentaUtilizadores.EnumUtilizadores)row[3]);
                }
                catch(Exception ex)
                {
                    erro = ex.Message;  
                }
              
            }
            return null;
        }

        public static DataTable ObterTodosOsUtilizadores(out string erro)
        {
            /**
              * Obtem todos os utilizadores
              **/
            Utilizador utilizador = new Utilizador();
            erro = string.Empty;
            DataTable t1 = CamadaDados.Utilizadores.ObterTodosOsUtilizadores(out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }

        public static DataTable ObterTodosOsClientes(out string erro)
        {
            /**
              * Obtem Apenas os utilizadores clientes
              * 
              * (para as reservas)
              **/
            Utilizador utilizador = new Utilizador();   
            erro = string.Empty;
            DataTable t1 = CamadaDados.Utilizadores.ObterTodosOsClientes(out erro);
            foreach (DataRow item in t1.Rows)
            {
                utilizador.idUtilizador = (int)item[0];
                Console.WriteLine(utilizador.ToString());
            }
            return t1;
        }

        public void GravarUtilizador(string nome, string pass, int cargo, out string erro)
        {
            /**
              * Atualiza um novo utilizador
              **/
            CamadaDados.Utilizadores.GravarUtilizador(this.idUtilizador, nome, pass, cargo, out erro);
        }

        public bool GravarNovoUtilizador(out string erro)
        {
            return CamadaDados.Utilizadores.GravarNovoUtilizador(this.NomeUtilizador, this.pass, (int)this.status, out erro);
        }

        public Boolean UtilizadorECliente()
        {
            return FerramentaUtilizadores.FerramentaUtilizadores.EUtilizador(this.status);
        }

        public Boolean UtilizadorEAdmin()
        {
            return FerramentaUtilizadores.FerramentaUtilizadores.EAdmin(this.status);
        }
        public Boolean UtilizadorEColaborador()
        {
            return FerramentaUtilizadores.FerramentaUtilizadores.EColaborador(this.status);
        }
    }

      
        #endregion
}

