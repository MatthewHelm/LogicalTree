namespace LogicalTree
{
   partial class frmMain
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.btnAttribute = new System.Windows.Forms.Button();
         this.btnAttributeTableField = new System.Windows.Forms.Button();
         this.btnClose = new System.Windows.Forms.Button();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.btnApplication = new System.Windows.Forms.Button();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnAttribute
         // 
         this.btnAttribute.Location = new System.Drawing.Point(12, 98);
         this.btnAttribute.Name = "btnAttribute";
         this.btnAttribute.Size = new System.Drawing.Size(132, 23);
         this.btnAttribute.TabIndex = 0;
         this.btnAttribute.Text = "Attribute";
         this.btnAttribute.UseVisualStyleBackColor = true;
         this.btnAttribute.Click += new System.EventHandler(this.btnAttribute_Click);
         // 
         // btnAttributeTableField
         // 
         this.btnAttributeTableField.Location = new System.Drawing.Point(12, 138);
         this.btnAttributeTableField.Name = "btnAttributeTableField";
         this.btnAttributeTableField.Size = new System.Drawing.Size(132, 23);
         this.btnAttributeTableField.TabIndex = 1;
         this.btnAttributeTableField.Text = "AttributeTableField";
         this.btnAttributeTableField.UseVisualStyleBackColor = true;
         this.btnAttributeTableField.Click += new System.EventHandler(this.btnAttributeTableField_Click);
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(350, 171);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(75, 23);
         this.btnClose.TabIndex = 2;
         this.btnClose.Text = "Close";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(449, 24);
         this.menuStrip1.TabIndex = 3;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.closeToolStripMenuItem.Text = "Close";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
         this.aboutToolStripMenuItem.Text = "About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // btnApplication
         // 
         this.btnApplication.Location = new System.Drawing.Point(12, 59);
         this.btnApplication.Name = "btnApplication";
         this.btnApplication.Size = new System.Drawing.Size(132, 23);
         this.btnApplication.TabIndex = 4;
         this.btnApplication.Text = "Application";
         this.btnApplication.UseVisualStyleBackColor = true;
         this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
         // 
         // frmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(449, 210);
         this.Controls.Add(this.btnApplication);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.btnAttributeTableField);
         this.Controls.Add(this.btnAttribute);
         this.Controls.Add(this.menuStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Name = "frmMain";
         this.Text = "View and Update LogicalTree Database";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnAttribute;
      private System.Windows.Forms.Button btnAttributeTableField;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.Button btnApplication;
   }
}

