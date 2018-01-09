using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalTree.Support_Classes
{
    public class Attribute_Db_Table_Field
    {
      private int _attribute_db_table_field_id;
      private string _attribute_db;
      private string _attribute_table;
      private String _attribute_field_id;
      private String _attribute_field_desc;
      private int _attribute_id;
      private String _application_name;



      public Attribute_Db_Table_Field()
      {

      }


      public int Attribute_Db_Table_Field_Id
      {
         get
         {
            return _attribute_db_table_field_id;
         }

         set
         {
            _attribute_db_table_field_id = value;
         }
      }

      public string Attribute_Db
      {
         get
         {
            return _attribute_db;
         }

         set
         {
            _attribute_db = value;
         }
      }

      public string Attribute_Table
      {
         get
         {
            return _attribute_table;
         }

         set
         {
            _attribute_table = value;
         }
      }

      public String Attribute_Field_Desc
      {
         get
         {
            return _attribute_field_desc;
         }

         set
         {
            _attribute_field_desc = value;
         }
      }

      public String Attribute_Field_Id
      {
         get
         {
            return _attribute_field_id;
         }

         set
         {
            _attribute_field_id = value;
         }
      }





      public int Attribute_Id
      {
         get
         {
            return _attribute_id;
         }

         set
         {
            _attribute_id = value;
         }
      }

      public string Application_Name
      {
         get
         {
            return _application_name;
         }

         set
         {
            _application_name = value;
         }
      }

   }
}
