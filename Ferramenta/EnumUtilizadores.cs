using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramenta
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
        public static DataTable ResolverEnumsUtilizadores(DataTable table)
        {
            table.Columns.Add(new DataColumn("Descrição Cargo"));
            foreach (DataRow row in table.Rows)
            {
                int value = (int)row[3]; //int representation of enum
                row[4] = Enum.GetName(typeof(EnumUtilizadores), value);
            }
            //esconder o indíce de utilizador
            table.Columns[3].ColumnMapping = MappingType.Hidden;
            return table;
        }
    }
}
