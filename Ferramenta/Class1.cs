using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramenta
{
    public enum EnumEncomendas
    {
        [Description("Em Curso")]
        EmCurso = 0,
        [Description("Terminada")]
        Terminada = 1,
        
    }

    public class FerramentaEncomendas
    {
        public static DataTable ResolverEnumsEncomendas(DataTable table)
        {
            table.Columns.Add(new DataColumn("Estado Encomenda"));
            foreach (DataRow row in table.Rows)
            {
                int value = (int)row[7]; //int representation of enum
                row[8] = Enum.GetName(typeof(EnumEncomendas), value);
            }
            //esconder o indíce de utilizador
            table.Columns[7].ColumnMapping = MappingType.Hidden;
            return table;
        }
    }
}
