using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalTree.Support_Classes;
using LogicalTree.Data_Layer;

namespace LogicalTree.Business_Layer
{
    public class Attribute_BL
    {

      public static Boolean InsertAttribute(LogicalTree.Support_Classes.Attribute objAttribute)
      {
         bool insertSuccessful = false;
         insertSuccessful = Attribute_DL.InsertAttributeRecord(objAttribute);
         return insertSuccessful;
      }

      public static List<Support_Classes.Attribute> GetAttributeList()
      {
         List<Support_Classes.Attribute> lstAttribute = null;
         lstAttribute = Data_Layer.Attribute_DL.GetAttributeRecordList();
         return lstAttribute;
      }




      public static Support_Classes.Attribute GetAttribute(int attributeId)
      {
         Support_Classes.Attribute objAttribute = null;
         objAttribute = Data_Layer.Attribute_DL.GetAttributeRecord(attributeId);
         return objAttribute;
      }


      public static Boolean UpdateAttribute(Support_Classes.Attribute objAttribute)
      {
         Boolean updateSuccessful = false;
         updateSuccessful = Attribute_DL.UpdateAttributeRecord(objAttribute);
         return updateSuccessful;
      }





    }
}
