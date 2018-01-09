using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalTree.Support_Classes
{

   public enum Sql_Object_Type
   {
      MainTable,
      InnerJoinTable,
      Column,
      ColumnValue
   }
   public class Query_Objects
    {
      private int _query_object_id;
      private String _queryobjects_database;
      private String _queryobjects_main_table;
      private String _queryobjects_table;
      private String _queryobjects_table_alias;
      private String _queryobjects_column;
      private Sql_Object_Type _sql_object_type;
      private String _queryobjects_column_value;
      private int _attribute_db_table_field_id;
      private int _seq_no;


      public Query_Objects()
      {
      }

      public int Query_Object_Id
      {
         get
         {
            return _query_object_id;
         }

         set
         {
            _query_object_id = value;
         }
      }

      public String QueryObjects_database
      {
         get
         {
            return _queryobjects_database;
         }

         set
         {
            _queryobjects_database = value;
         }
      }

      public String QueryObjects_Main_Table
      {
         get
         {
            return _queryobjects_main_table;
         }

         set
         {
            _queryobjects_main_table = value;
         }
      }

      public String QueryObjects_Table
      {
         get
         {
            return _queryobjects_table;
         }

         set
         {
            _queryobjects_table = value;
         }
      }

      public String QueryObjects_Table_Alias
      {
         get
         {
            return _queryobjects_table_alias;
         }

         set
         {
            _queryobjects_table_alias = value;
         }
      }



      public String QueryObjects_Column
      {
         get
         {
            return _queryobjects_column;
         }

         set
         {
            _queryobjects_column = value;
         }
      }


      public String QueryObjects_Column_Value
      {
         get
         {
            return _queryobjects_column_value;
         }

         set
         {
            _queryobjects_column_value = value;
         }
      }


      public Sql_Object_Type Sql_Object_Type
      {
         get
         {
            return _sql_object_type;
         }

         set
         {
            _sql_object_type = value;
         }
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

      public int Seq_No
      {
         get
         {
            return _seq_no;
         }

         set
         {
            _seq_no = value;
         }
      }
   }
}
