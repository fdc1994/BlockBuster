using Ferramenta;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Filme
    {
        #region Propriedades
        private int idFilme;

        public int IdFilme
        {
            get { return idFilme; }
            set { idFilme = value; }
        }


        private string nomeFilme;

        public string NomeFilme
        {
            get { return nomeFilme; }
            set { nomeFilme = value; }
        }

        private int quantidade;

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        #endregion

        #region Construtores

        public Filme()
        {

        }

        public Filme(int id, string nomeFilme, int quantidade)
            : this()
        {
            this.idFilme = id;
            this.nomeFilme = nomeFilme;
            this.quantidade = quantidade;
        }

        public Filme(string nomeFilme, int quantidade)
            : this()
        {
            this.nomeFilme = nomeFilme;
            this.quantidade = quantidade;
        }
        #endregion

        #region Metodos

        public static DataTable ObterTodosOsFilmes(out string erro)
        {
            erro = string.Empty;
            DataTable t1 = CamadaDados.Filmes.ObterTodosOsFilmes(out erro);
            return t1;
        }

        public void GravarFilme(int id, string nome, int quantidade, out string erro) { 
            CamadaDados.Filmes.GravarFilme(id, nome, quantidade, out erro );
        }

        public bool GravarNovoFilme(string nome, int quantidade, out string erro)
        {
            return CamadaDados.Filmes.GravarNovoFilme(nome, quantidade, out erro);
        }


        public void ApagarFilme(int id, out string erro)
        {
            CamadaDados.Filmes.ApagarFilme(id, out erro);
        }
        #endregion
    }
}
