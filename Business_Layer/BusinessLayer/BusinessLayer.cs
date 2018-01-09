using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicalTree.Business_Layer

{
    public class BusinessLayer<T>
    {
      static public ObjectSaveType recordSaveType = ObjectSaveType.UpdateObject;

      public enum ObjectSaveType
      {
         InsertObject = 1,
         UpdateObject = 2
      }


      public static T ReturnCurrentTypeObject(BindingSource bindingSource)
      {
         T obj;
         obj = (T) bindingSource.Current;
         return obj;
      }


      public static String TrimDatabaseObjectDelimiters(String dbObject)
      {
         String tmpStr = null;

         if (string.IsNullOrEmpty(dbObject))
         {
            return tmpStr;
         }

         if (dbObject.Contains("dbo"))
         {
            String[] arr = dbObject.Split('.');
          //  arr[0] = arr[0].Trim('[');
           // arr[0] = arr[0].Trim(']');

            arr[1] = arr[1].Trim('[');
            arr[1] = arr[1].Trim(']');

            tmpStr = arr[1];
         }
         else
         {

            tmpStr = dbObject.Trim('[');
          //  tmpStr = dbObject.Trim('[');
            tmpStr = tmpStr.Trim(']');
          //  tmpStr = tmpStr.Trim(']');
         }
         return tmpStr;
      }

      //public static string TrimDatabaseObjectDelimitersTrimDatabaseObjectDelimiters(string attribute_Db)
      //{
      //   throw new NotImplementedException();
      //}
   }
}
