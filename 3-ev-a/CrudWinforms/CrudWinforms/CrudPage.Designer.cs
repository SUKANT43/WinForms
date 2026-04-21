namespace CrudWinforms
{
    partial class CrudPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.createData = new System.Windows.Forms.Button();
            this.dataControl1 = new CrudWinforms.DataControl();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(312, 78);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(151, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(312, 126);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(151, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // createData
            // 
            this.createData.Location = new System.Drawing.Point(329, 179);
            this.createData.Name = "createData";
            this.createData.Size = new System.Drawing.Size(114, 35);
            this.createData.TabIndex = 2;
            this.createData.Text = "button1";
            this.createData.UseVisualStyleBackColor = true;
            this.createData.Click += new System.EventHandler(this.CreateDataClick);
            // 
            // dataControl1
            // 
            this.dataControl1.Location = new System.Drawing.Point(107, 345);
            this.dataControl1.Name = "dataControl1";
            this.dataControl1.Size = new System.Drawing.Size(125, 44);
            this.dataControl1.TabIndex = 3;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(149, 179);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(59, 20);
            this.searchTextBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(601, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 265);
            this.panel1.TabIndex = 5;
            // 
            // CrudPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataControl1);
            this.Controls.Add(this.createData);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "CrudPage";
            this.Size = new System.Drawing.Size(1059, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button createData;
        private DataControl dataControl1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}
