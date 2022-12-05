using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Reserva
    {
        #region Propriedades

        private Nullable<int> idReserva;

        public Nullable<int> IDReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }


        private string nomeCliente;

        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        private DateTime dataInicio;

        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        private Nullable<DateTime> dataFim;

        public Nullable<DateTime> DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }
        #endregion

        #region Construtores

        public Reserva()
        {

        }

        public Reserva(string nomeCliente, DateTime dataInicio, Nullable<DateTime> dataFim)
            : this()
        {
            this.idReserva = null;
            this.nomeCliente = nomeCliente;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
        }

        #endregion

        #region Metodos
        public void Novo()
        {
            this.IDReserva = null;
            this.NomeCliente = string.Empty;
            this.DataInicio = DateTime.Today;
            this.dataFim = null;
        }
        public static Reserva NovaReserva()
        {
            Reserva reserva = new Reserva();

            //V1
            //aluno.IDAluno = string.Empty;
            //aluno.NomeAluno = string.Empty;
            //aluno.DataNascimento = DateTime.Today;
            //aluno.Telefone = "+351 ";

            //V2
            reserva.Novo();

            return reserva;
        }

        public bool Gravar(out string erro)
        {
            bool ok = false;
            erro = string.Empty;

            //V1
            //CamadaDados.Aluno aluno = new CamadaDados.Aluno();
            //ok = aluno.Gravar(this.IDAluno, this.NomeAluno, this.DataNascimento, this.Telefone, out erro);

            //V2
           // ok = CamadaDados.Aluno.GravarAluno(this.IDAluno, this.NomeAluno, this.DataNascimento, this.Telefone, out erro);

            return ok;
        }

        public bool Eliminar(out string erro)
        {
            bool ok = false;
            erro = string.Empty;

           // ok = CamadaDados.Aluno.Eliminar(this.IDAluno, out erro);

            return ok;
        }

        public static Reserva ObterReserva(int id, out string erro)
        {
            Reserva reserva = null;
            erro = string.Empty;
            string nomeAluno = string.Empty;
            DateTime dataNascimento = DateTime.Today;
            string telefone = string.Empty;
            bool ok = true;
           // bool ok = CamadaDados.Reserva.Obter(ref id,out erro);

            if (ok)
            {
                //V1
                //aluno = new Aluno();

                //aluno.IDAluno = idAluno;
                //aluno.NomeAluno = nomeAluno;
                //aluno.DataNascimento = dataNascimento;
                //aluno.Telefone = telefone;

                //V2
                //reserva = new Reserva();

            }

            return reserva;
        }
        #endregion
    }

}
