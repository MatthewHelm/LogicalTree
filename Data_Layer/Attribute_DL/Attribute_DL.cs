using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalTree.Support_Classes;

namespace LogicalTree.Data_Layer
{
    public class Attribute_DL
    {

      public static Boolean InsertAttributeRecord(LogicalTree.Support_Classes.Attribute objAttribute)
      {
         bool insertSuccessful = false;

         if (objAttribute == (LogicalTree.Support_Classes.Attribute)null)
         {
            return insertSuccessful;
         }

         string insertString = "INSERT INTO dbo.tblAttribute (attribute_name) VALUES ('{0}')";

         insertString = string.Format(insertString, objAttribute.Attribute_Name, objAttribute.Application_Name);

         insertSuccessful = Data_Layer.InsertTypeRecord(insertString, Data_Layer.ltConnectionString);

         return insertSuccessful;
      }

      public static List<Support_Classes.Attribute> GetAttributeRecordList()
      {
         List<Support_Classes.Attribute> lstAttribute = null;

         string selectString = "select attribute_id, attribute_name from dbo.tblAttribute";

         Support_Classes.Attribute objAttribute;

         lstAttribute = new List<Support_Classes.Attribute>();

         SqlConnection conn = new SqlConnection(Data_Layer.ltConnectionString);
         SqlCommand comm = new SqlCommand(selectString, conn);
         SqlDataReader rdr;

         try
         {
            conn.Open();
            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
               objAttribute = new Support_Classes.Attribute();

               objAttribute.Attribute_Id = Convert.ToInt32(rdr["attribute_id"]);
               objAttribute.Attribute_Name = Convert.ToString(rdr["attribute_name"]);
     //          objAttribute.Application_Name = Convert.ToString(rdr["application_name"]);

               lstAttribute.Add(objAttribute);

            }
         }
         catch
         {
            lstAttribute = null;
         }
         finally
         {
            conn.Dispose();
            conn.Close();
            comm.Dispose();
         }
         return lstAttribute;
      }


      public static Support_Classes.Attribute GetAttributeRecord(int attributeId)
      {
         Support_Classes.Attribute objAttribute  = null;


         if (attributeId == 0)
         {
            return objAttribute;
         }

         String selectString = "SELECT attribute_id, attribute_name FROM [dbo].[tblAttribute] WHERE attribute_id = {0}";
         selectString = String.Format(selectString, Convert.ToString(attributeId));

         SqlConnection conn = new SqlConnection(Data_Layer.ltConnectionString);
         SqlCommand comm = new SqlCommand(selectString, conn);
         SqlDataReader rdr;

         try
         {
            conn.Open();
            rdr = comm.ExecuteReader();

            rdr.Read();

            objAttribute = new Support_Classes.Attribute();

            objAttribute.Attribute_Id = Convert.ToInt32(rdr["attribute_id"]);
            objAttribute.Attribute_Name = Convert.ToString(rdr["attribute_name"]);
       //     objAttribute.Application_Name = Convert.ToString(rdr["application_name"]);


         }
         catch
         {
            objAttribute = null;
         }
         finally
         {
            conn.Close();
            conn.Dispose();
            comm.Dispose();
         }

         return objAttribute;
      }

      public static Boolean UpdateAttributeRecord(Support_Classes.Attribute objAttribute)
      {

         bool updateSuccessful = false;

         if (objAttribute == null)
         {
            return updateSuccessful;
         }

         if (string.IsNullOrEmpty(objAttribute.Attribute_Name))
         {
            return updateSuccessful;
         }

         string updateString = "UPDATE tblAttribute SET attribute_name = '{0}' WHERE attribute_id = {2}";
         updateString = string.Format(updateString, objAttribute.Attribute_Name, objAttribute.Attribute_Id);

         updateSuccessful = Data_Layer.UpdateTypeRecord(updateString, Data_Layer.ltConnectionString);

         return updateSuccessful;
      }





    }
}
