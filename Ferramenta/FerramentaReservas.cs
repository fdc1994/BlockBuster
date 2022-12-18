using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerramentaReservas
{
    public enum EnumEncomendas
    {
        [Description("Em Curso")]
        EmCurso = 0,
        [Description("Terminada")]
        Terminada = 1,
        
    }

    public class FerramentaReservas
    {
        public static DataTable ResolverEnumsEncomendas(DataTable table)
        {
            table.Columns.Add(new DataColumn("Estado Encomenda"));
            foreach (DataRow row in table.Rows)
            {
                EnumEncomendas value = (EnumEncomendas)row[7]; //int representation of enum

                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                row[8] = descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
            }
            //esconder o indíce de utilizador
            table.Columns[7].ColumnMapping = MappingType.Hidden;
            return table;
        }

        public static List<KeyValuePair<string, int>> GetEnumValuesAndDescriptions()
        {
            Type enumType = typeof (EnumEncomendas);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            List<KeyValuePair<string, int>> enumValList = new List<KeyValuePair<string, int>>();

            foreach (var e in Enum.GetValues(typeof(EnumEncomendas)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<string, int>((attributes.Length > 0) ? attributes[0].Description : e.ToString(), (int)e));
            }

            return enumValList;
        }
    }
}
