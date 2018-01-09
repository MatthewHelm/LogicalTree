using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicalTree
{
   public partial class frmMain : Form
   {
      public frmMain()
      {
         InitializeComponent();
      }

      private void btnAttribute_Click(object sender, EventArgs e)
      {
         frmAttribute f = new frmAttribute();
         f.Show();
      }

      private void btnAttributeTableField_Click(object sender, EventArgs e)
      {
         frmAttribute_Database_Table_Field f = new frmAttribute_Database_Table_Field();
         f.Show();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LogicalTreeAboutBox f = new LogicalTreeAboutBox();
         f.Show();
      }

      private void btnApplication_Click(object sender, EventArgs e)
      {
         frmApplication f = new frmApplication();
         f.Show();
      }
   }
}
