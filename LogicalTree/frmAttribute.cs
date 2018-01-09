using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicalTree.Support_Classes;
using LogicalTree.Business_Layer;


namespace LogicalTree
{
   public partial class frmAttribute : Form
   {

      private Support_Classes.Attribute objAttribute;
      private List<Support_Classes.Attribute> lstAttribute;

      private BindingSource bnsAttribute;



      public frmAttribute()
      {

         BusinessLayer<Support_Classes.Attribute>.recordSaveType = BusinessLayer<Support_Classes.Attribute>.ObjectSaveType.UpdateObject;
         bnsAttribute = new BindingSource();
         lstAttribute = Attribute_BL.GetAttributeList();
         bnsAttribute.DataSource = lstAttribute;
         InitializeComponent();
         bnvAttribute.BindingSource = bnsAttribute;

         txtAttributeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bnsAttribute, "Attribute_Name", true));

         return;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         switch (BusinessLayer<Support_Classes.Attribute>.recordSaveType)
         {
            case BusinessLayer<Support_Classes.Attribute>.ObjectSaveType.InsertObject:
               Attribute_BL.InsertAttribute(objAttribute);
               break;

            case BusinessLayer<Support_Classes.Attribute>.ObjectSaveType.UpdateObject:
               objAttribute = (Support_Classes.Attribute) bnsAttribute.Current;
               Attribute_BL.UpdateAttribute(objAttribute);
               break;
         }

         BusinessLayer<Support_Classes.Attribute>.recordSaveType = BusinessLayer<Support_Classes.Attribute>.ObjectSaveType.UpdateObject;
         lstAttribute = Attribute_BL.GetAttributeList();
         bnsAttribute.DataSource = lstAttribute;
         bnvAttribute.BindingSource = bnsAttribute;
      }

      private void bnvAttribute_Click(object sender, EventArgs e)
      {
      }

      private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Support_Classes.Attribute>.recordSaveType = BusinessLayer<Support_Classes.Attribute>.ObjectSaveType.InsertObject;
         objAttribute = (Support_Classes.Attribute) bnsAttribute.Current;
      }

      private void frmAttribute_Load(object sender, EventArgs e)
      {
         this.SetLocation();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void SetLocation()
      {
         Point stndrdPoint = new Point();

         stndrdPoint.X = 200;
         stndrdPoint.Y = 250;

         this.Location = stndrdPoint;
      }

        private void txtAttributeName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
