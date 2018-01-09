using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalTree.Support_Classes
{
    public class Attribute
    {
      private int _attribute_id;
      private string _attribute_name;
      private string _application_name;


      public Attribute()
      {

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

      public string Attribute_Name
      {
         get
         {
            return _attribute_name;
         }

         set
         {
            _attribute_name = value;
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
