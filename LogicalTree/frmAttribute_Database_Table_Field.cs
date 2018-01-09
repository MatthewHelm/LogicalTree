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
using LogicalTree.Data_Layer;
using LogicalTree.Business_Layer;

namespace LogicalTree
{
   public partial class frmAttribute_Database_Table_Field : Form
   {
      List<Attribute_Db_Table_Field> lstAttribute_Db_Table_Field = null;
      Attribute_Db_Table_Field objAttribute_Db_Table_Field = new Attribute_Db_Table_Field();

      List<Support_Classes.Attribute> lstAttribute;
      Support_Classes.Attribute objAttribute;

      private BindingSource bnsAttribute_Db_Table_Field;

      private BindingSource bnsAttribute;
      List<String> lstDatabases;
      List<String> lstTables;
      List<String> lstColumns;

      String objDatabase;
      String objTable;

      private String item;

      private int idx;

      public frmAttribute_Database_Table_Field()
      {
         InitializeComponent();
      }


      private void frmAttribute_Database_Table_Field_Load(object sender, EventArgs e)
      {
         item = null;
         idx = 0;

         this.BindCmbAttribute();

         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Support_Classes.Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;

         bnsAttribute_Db_Table_Field = new BindingSource();

         lstAttribute_Db_Table_Field = Attribute_Db_Table_Field_BL.GetAttributeDbTableFieldList();

         bnsAttribute_Db_Table_Field.DataSource = lstAttribute_Db_Table_Field;

         bnvAttributeDatabaseTableField.BindingSource = bnsAttribute_Db_Table_Field;

         txtApplicationName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bnsAttribute_Db_Table_Field, "Application_Name", true));

         this.SetComboBoxes();

         this.SetLocation();

         return;
      }


      private void SetComboBoxes()
      {
         objAttribute_Db_Table_Field = BusinessLayer<Attribute_Db_Table_Field>.ReturnCurrentTypeObject(bnsAttribute_Db_Table_Field);

         this.BindCmbAttribute();

         Support_Classes.Attribute tmpAttribute = Attribute_BL.GetAttribute(objAttribute_Db_Table_Field.Attribute_Id);

         idx = cmbAttribute.FindString(tmpAttribute.Attribute_Name);
         cmbAttribute.SelectedIndex = idx;
   
         this.BindCmbDatabases();

         String dbObject = Business_Layer.BusinessLayer<Attribute_Db_Table_Field>.TrimDatabaseObjectDelimiters(objAttribute_Db_Table_Field.Attribute_Db);

         idx = cmbDatabases.FindString(dbObject);
         cmbDatabases.SelectedIndex = idx;

         this.BindCmbTables();

         dbObject = Business_Layer.BusinessLayer<Attribute_Db_Table_Field>.TrimDatabaseObjectDelimiters(objAttribute_Db_Table_Field.Attribute_Table);

         idx = cmbTables.FindString(dbObject);
         cmbTables.SelectedIndex = idx;

         return;
      }


      private void btnsave_Click(object sender, EventArgs e)
      {
         switch (BusinessLayer<Attribute_Db_Table_Field>.recordSaveType)
         {
            case BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.InsertObject:
               objAttribute_Db_Table_Field.Attribute_Id = (int)cmbAttribute.SelectedValue;   // The volume id has not been set.  This is where it gets assigned.
               objAttribute_Db_Table_Field.Attribute_Db = (string)cmbDatabases.SelectedItem;
               objAttribute_Db_Table_Field.Attribute_Table = (string)cmbTables.SelectedItem;
               objAttribute_Db_Table_Field.Attribute_Field_Id = (String) cmbFieldIds.SelectedItem;
               objAttribute_Db_Table_Field.Attribute_Field_Desc = (String) cmbFieldDescs.SelectedItem;
               Attribute_Db_Table_Field_BL.InsertAttributeDbTableField(objAttribute_Db_Table_Field);
               break;
            case BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject:
               objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
               Attribute_Db_Table_Field_BL.UpdateAttributeDbTableField(objAttribute_Db_Table_Field);
               break;
         }

         lstAttribute_Db_Table_Field = Attribute_Db_Table_Field_BL.GetAttributeDbTableFieldList();
         bnsAttribute_Db_Table_Field.DataSource = lstAttribute_Db_Table_Field;
         bnvAttributeDatabaseTableField.BindingSource = bnsAttribute_Db_Table_Field;
      }


      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void lblTable_Click(object sender, EventArgs e)
      {
      }


      private void BindCmbAttribute()
      {
         bnsAttribute = new BindingSource();
         lstAttribute = Attribute_BL.GetAttributeList();
         bnsAttribute.DataSource = lstAttribute;
         cmbAttribute.DataSource = bnsAttribute.DataSource;
         cmbAttribute.DisplayMember = "Attribute_Name";
         cmbAttribute.ValueMember = "Attribute_Id";
      }


      private void BindCmbDatabases()
      {
         lstDatabases = Business_Layer.Attribute_Db_Table_Field_BL.GetDatabases();
         cmbDatabases.DataSource = lstDatabases;
      }

      private void BindCmbTables()
      {
         lstTables = Business_Layer.Attribute_Db_Table_Field_BL.GetTables(objDatabase);
         cmbTables.DataSource = lstTables;
      }

      private void BindIdCmbColumns()
      {
         var lstIdColumns = from l in lstColumns where l.Contains("_id") select l;
         cmbFieldIds.DataSource = lstIdColumns.ToList();
      }


      private void BindDescCmbColumns()
      {
         var lstDescColumns = from l in lstColumns where l.Contains("_id") != true select l;
         cmbFieldDescs.DataSource = lstDescColumns.ToList();
      }


      private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
      {
         objDatabase = Convert.ToString(cmbDatabases.SelectedItem);
         this.BindCmbTables();
      }

      private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
      {
         objTable = Convert.ToString(cmbTables.SelectedItem);
         lstColumns = Business_Layer.Attribute_Db_Table_Field_BL.GetColumns(objTable);
         this.BindIdCmbColumns();
         this.BindDescCmbColumns();
      }

      private void cmbFieldIds_SelectedIndexChanged(object sender, EventArgs e)
      {
      }

      private void cmbFieldDescs_SelectedIndexChanged(object sender, EventArgs e)
      {
      }

      private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;
         Attribute_Db_Table_Field_BL.DeleteAttributeDbTableField(objAttribute_Db_Table_Field);
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field) bnsAttribute_Db_Table_Field.Current;
      }

      private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.InsertObject;
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
      }

      private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
         this.SetComboBoxes();
      }

      private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
         this.SetComboBoxes();
      }

      private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
         this.SetComboBoxes();
      }

      private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
      {
         BusinessLayer<Attribute_Db_Table_Field>.recordSaveType = BusinessLayer<Attribute_Db_Table_Field>.ObjectSaveType.UpdateObject;
         objAttribute_Db_Table_Field = (Attribute_Db_Table_Field)bnsAttribute_Db_Table_Field.Current;
         this.SetComboBoxes();
      }

      private void SetLocation()
      {
         Point stndrdPoint = new Point();

         stndrdPoint.X = 200;
         stndrdPoint.Y = 250;

         this.Location = stndrdPoint;
      }

   }
}
