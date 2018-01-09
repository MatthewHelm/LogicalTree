using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalTree.Support_Classes;

namespace LogicalTree.Data_Layer
{

    public class Query_Objects_DL
    {

      static public String ConstructQuery(List<Query_Objects> lstQueryObjects)
      {
         String selectString = null;

         if (lstQueryObjects == null)
         {
            return selectString;
         }

         selectString = "SELECT ";

         for (int i = 0; i < lstQueryObjects.Count; i++)
         {
            switch (lstQueryObjects[i].Sql_Object_Type)
            {
               case Sql_Object_Type.MainTable:
                  selectString = selectString + lstQueryObjects[i].QueryObjects_Main_Table + " " + lstQueryObjects[i].QueryObjects_Table_Alias + " CHAR(13)";
                  break;
               case Sql_Object_Type.InnerJoinTable:
                  selectString = selectString + "INNER JOIN dbo." + lstQueryObjects[i].QueryObjects_Table + " ON " + lstQueryObjects[i].QueryObjects_Main_Table + "." + lstQueryObjects[i].QueryObjects_Column + " = " + lstQueryObjects[i].QueryObjects_Table + "." + lstQueryObjects[i].QueryObjects_Column;
                  break;
               case Sql_Object_Type.Column:
                  if (i + 1 > lstQueryObjects.Count)
                  {
                     selectString = selectString + lstQueryObjects[i].QueryObjects_Column + " FROM ";
                  }
                  else
                  {
                     selectString = selectString + lstQueryObjects[i].QueryObjects_Table_Alias + lstQueryObjects[i].QueryObjects_Column + ", ";
                  }
                  break;
               case Sql_Object_Type.ColumnValue:
                  break;
            }
         }
         return selectString;
      }


    }
}
