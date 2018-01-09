using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalTree.Support_Classes;


namespace LogicalTree.Data_Layer
{
    public class Attribute_Db_Table_Field_DL
    {

      public static string ConnectionString = "Data Source=BCSWS7;Initial Catalog=\"LogicalTree\";Integrated Security=True";

      public static bool InsertAttributeDbTableFieldRecord(Attribute_Db_Table_Field objAttribute_Db_Table_Field)
      {
         bool insertSuccessful = false;

         if (objAttribute_Db_Table_Field == (Attribute_Db_Table_Field)null)
         {
            return insertSuccessful;
         }

         objAttribute_Db_Table_Field.Attribute_Db = "\'[" + objAttribute_Db_Table_Field.Attribute_Db + "]\'";
         objAttribute_Db_Table_Field.Attribute_Table = "\'[" + "dbo" + "].[" + objAttribute_Db_Table_Field.Attribute_Table + "]\'";
         objAttribute_Db_Table_Field.Attribute_Field_Id = "\'[" + objAttribute_Db_Table_Field.Attribute_Field_Id + "]\'";


         string insertString = "INSERT INTO dbo.tblAttribute_Db_Table_Field (attribute_id, attribute_database, attribute_table, attribute_field_id, attribute_field_description, application_name) VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}')";

         insertString = string.Format(insertString, objAttribute_Db_Table_Field.Attribute_Id, objAttribute_Db_Table_Field.Attribute_Db, objAttribute_Db_Table_Field.Attribute_Table, objAttribute_Db_Table_Field.Attribute_Field_Id, objAttribute_Db_Table_Field.Attribute_Field_Desc, objAttribute_Db_Table_Field.Application_Name);

         insertSuccessful = Data_Layer.InsertTypeRecord(insertString, Data_Layer.ltConnectionString);

         return insertSuccessful;
      }


      public static bool UpdateAttributeDbTableFieldRecord(Attribute_Db_Table_Field objAttribute_Db_Table_Field)
      {
         bool updateSuccessful = false;

         if (objAttribute_Db_Table_Field == null)
         {
            return updateSuccessful;
         }

         if (objAttribute_Db_Table_Field.Attribute_Id == 0)
         {
            return updateSuccessful;
         }

         if (string.IsNullOrEmpty(objAttribute_Db_Table_Field.Attribute_Db) || string.IsNullOrEmpty(objAttribute_Db_Table_Field.Attribute_Table) || string.IsNullOrEmpty(objAttribute_Db_Table_Field.Attribute_Field_Id) || string.IsNullOrEmpty(objAttribute_Db_Table_Field.Attribute_Field_Desc))
         {
            return updateSuccessful;
         }

         string updateString = "UPDATE tblAttribute_Db_Table_Field SET attribute_id = {0}, attribute_database = '{1}', attribute_table = '{2}', attribute_field_id = '{3}', attribute_field_description = '{4}', application_name = '{5}' WHERE attribute_db_table_field_id = {6}";
         updateString = string.Format(updateString, objAttribute_Db_Table_Field.Attribute_Id, objAttribute_Db_Table_Field.Attribute_Db, objAttribute_Db_Table_Field.Attribute_Table, objAttribute_Db_Table_Field.Attribute_Field_Id, objAttribute_Db_Table_Field.Attribute_Field_Desc, objAttribute_Db_Table_Field.Application_Name, objAttribute_Db_Table_Field.Attribute_Db_Table_Field_Id);

         updateSuccessful = Data_Layer.UpdateTypeRecord(updateString, Data_Layer.ltConnectionString);

         return updateSuccessful;
      }

      public static bool DeleteAttributeDbTableFieldRecord(Attribute_Db_Table_Field objAttribute_Db_Table_Field)
      {
         bool deleteSuccessful = false;

         if (objAttribute_Db_Table_Field == (Attribute_Db_Table_Field)null)
         {
            return deleteSuccessful;
         }

         string deleteStatement = string.Format("DELETE FROM tblAttribute_Db_Table_Field WHERE attribute_db_table_field_id = {0}", objAttribute_Db_Table_Field.Attribute_Db_Table_Field_Id.ToString());

         deleteSuccessful = Data_Layer.DeleteTypeRecord(deleteStatement, Data_Layer.ltConnectionString);

         return deleteSuccessful;
      }


      public static List<Attribute_Db_Table_Field> GetAttributeDbTableFieldRecordList()
      {
         List<Attribute_Db_Table_Field> lstAttribute_Db_Table_Field = (List<Attribute_Db_Table_Field>)null;

         string selectString = "SELECT attribute_db_table_field_id, attribute_id, attribute_database, attribute_table, attribute_field_id, attribute_field_description, application_name FROM dbo.tblAttribute_Db_Table_Field";

         Attribute_Db_Table_Field objAttribute_Db_Table_Field;

         lstAttribute_Db_Table_Field = new List<Attribute_Db_Table_Field>();

         SqlConnection conn = new SqlConnection(Data_Layer.ltConnectionString);
         SqlCommand comm = new SqlCommand(selectString, conn);
         SqlDataReader rdr;

         try
         {
            conn.Open();
            rdr = comm.ExecuteReader();

            while (rdr.Read())
            {
               objAttribute_Db_Table_Field = new Attribute_Db_Table_Field();

               objAttribute_Db_Table_Field.Attribute_Db_Table_Field_Id = Convert.ToInt32(rdr["attribute_db_table_field_id"]);
               objAttribute_Db_Table_Field.Attribute_Id = Convert.ToInt32(rdr["attribute_id"]);
               objAttribute_Db_Table_Field.Attribute_Db = Convert.ToString(rdr["attribute_database"]);
               objAttribute_Db_Table_Field.Attribute_Table = Convert.ToString(rdr["attribute_table"]);
               objAttribute_Db_Table_Field.Attribute_Field_Id = Convert.ToString(rdr["attribute_field_id"]);
               objAttribute_Db_Table_Field.Attribute_Field_Desc = Convert.ToString(rdr["attribute_field_description"]);
               objAttribute_Db_Table_Field.Application_Name = Convert.ToString(rdr["application_name"]);

               lstAttribute_Db_Table_Field.Add(objAttribute_Db_Table_Field);
            }

         }
         catch (Exception ex)
         {
            lstAttribute_Db_Table_Field = (List<Attribute_Db_Table_Field>)null;
         }
         finally
         {
            conn.Close();
            conn.Dispose();
            comm.Dispose();
         }
         return lstAttribute_Db_Table_Field;
      }



      private static String BuildConnectionString(String ServerName, String DatabaseName)
      {
         String ConnectionString = null;

         if (string.IsNullOrEmpty(ServerName) || string.IsNullOrEmpty(DatabaseName))
         {
            return ConnectionString;
         }

         ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=\"" + DatabaseName + "\";Integrated Security=True;";

         return ConnectionString;
      }


      public static List<String> GetDatabaseList(string ServerName)
      {
         List<String> lstDatabases = null;

         SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
         conn.DataSource = ServerName;


         conn.IntegratedSecurity = true;

         String strConn = conn.ToString();

         //create conn
         SqlConnection sqlConn = new SqlConnection(strConn);

         //open conn
         sqlConn.Open();

         //get lstDatabases
         DataTable tblDatabases = sqlConn.GetSchema("Databases");

         //close conn
         sqlConn.Close();

         lstDatabases = new List<String>();

         //add to list
         foreach (DataRow row in tblDatabases.Rows)
         {
            String strDatabaseName = row["database_name"].ToString();

            lstDatabases.Add(strDatabaseName);
         }

         return lstDatabases;

      }

      public static List<String> GetTableList(String DatabaseName)
      {
         List<string> lstTables = null;

         if (string.IsNullOrEmpty(DatabaseName))
         {
            return lstTables;
         }

         ConnectionString = BuildConnectionString("BCSWS7", DatabaseName);

         SqlConnection connection = new SqlConnection(ConnectionString);
         connection.Open();
         DataTable schema = connection.GetSchema("Tables");
         lstTables = new List<string>();
         foreach (DataRow row in schema.Rows)
         {
            lstTables.Add(row[2].ToString());
         }
         return lstTables;
      }


      public static List<String> GetColumnsList(String tableName)
      {
         List<String> lstColumns = null;

         if (string.IsNullOrEmpty(tableName))
         {
            return lstColumns;
         }

         lstColumns = new List<String>();

         SqlConnection conn = new SqlConnection(Attribute_Db_Table_Field_DL.ConnectionString);

         SqlCommand comm = conn.CreateCommand();


         comm.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = " + "\'" + tableName + "\'";
         conn.Open();

         SqlDataReader rdr = comm.ExecuteReader();

         while (rdr.Read())
         {
            lstColumns.Add(rdr.GetString(0));
         }

         return lstColumns;
      }


   }
}
