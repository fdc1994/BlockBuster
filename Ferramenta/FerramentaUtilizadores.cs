﻿using FerramentaReservas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaUtilizadores
{
    public enum EnumUtilizadores
    {
        [Description("Admin")]
        Admin = 0,
        [Description("Gerente")]
        Gerente = 1,
        [Description("Colaborador")]
        Colaborador = 2,
        [Description("Cliente")]
        Cliente = 3
    }

    public class FerramentaUtilizadores
    {

        /**
         * 
         * Oculta a tabela com o valor enum e substitui por uma nova tabela com significado para o utilizador
         * 
         * **/
        public static DataTable ResolverEnumsUtilizadores(DataTable table)
        {
            table.Columns.Add(new DataColumn("Descrição Cargo"));
            foreach (DataRow row in table.Rows)
            {
                EnumUtilizadores value = (EnumUtilizadores)row[3]; //int representation of enum

                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                row[4] = descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
            }
            //esconder o indíce de utilizador
            table.Columns[3].ColumnMapping = MappingType.Hidden;
            return table;
        }

        /**
         * 
         * Lógica de comparação de utilizadores
         * 
         * **/

        public static bool EUtilizador(EnumUtilizadores status)
        {
            return status == EnumUtilizadores.Cliente;
        }

        public static bool EAdmin(EnumUtilizadores status)
        {
            return status == EnumUtilizadores.Admin || status == EnumUtilizadores.Gerente;
        }

        public static bool EColaborador(EnumUtilizadores status)
        {
            return status == EnumUtilizadores.Colaborador;
        }


    }
}
