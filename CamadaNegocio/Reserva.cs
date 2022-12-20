using FerramentaReservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Reserva
    {
        #region Propriedades

        private int idReserva;

        public int IDReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
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

        private int idCliente;

        public int IDCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private string nomeCliente;

        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        private int idFilme;
        public int IDFilme
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

        private EnumEncomendas estado;
        public EnumEncomendas Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        #endregion

        #region Construtores

        public Reserva()
        {

        }

        public Reserva(int id, DateTime dataInicio, Nullable<DateTime> dataFim, int idCliente, string nomeCliente, int idFilme, string nomeFilme, EnumEncomendas estado)
            : this()
        {
            this.idReserva = id;
            this.dataInicio= dataInicio;   
            this.dataFim= dataFim;
            this.idCliente= idCliente;
            this.nomeCliente = nomeCliente;
            this.idFilme= idFilme;
            this.nomeFilme=nomeFilme;
            this.estado= estado;
        }

        public Reserva(DateTime dataInicio, DateTime dataFim, int idCliente, string nomeCliente, int idFilme, string nomeFilme, EnumEncomendas estado)
            : this()
        {
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.idCliente = idCliente;
            this.nomeCliente = nomeCliente;
            this.idFilme = idFilme;
            this.nomeFilme = nomeFilme;
            this.estado = estado;
        }

        public Reserva(int idCliente, int idFilme)
            : this()
        {
            this.idCliente = idCliente;
            this.idFilme = idFilme;
        }

        #endregion

        #region Metodos
        public static DataTable ObterTodasAsReservas(out string erro)
        {
            DataTable t1 = CamadaDados.Reservas.ObterTodasAsReservas(out erro);
            return t1;
        }

        public void GravarReserva(int idCliente, string nomeCliente, int idFilme, string nomeFilme, out string erro)
        {
            CamadaDados.Reservas.GravarReserva(idCliente, nomeCliente, idFilme, nomeFilme, out erro);
        }
        #endregion
    }

}
