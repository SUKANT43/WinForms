namespace StickyNotes
{
    partial class SubForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.contentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.headerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.okButton);
            this.mainPanel.Controls.Add(this.saveButton);
            this.mainPanel.Controls.Add(this.addButton);
            this.mainPanel.Controls.Add(this.contentRichTextBox);
            this.mainPanel.Controls.Add(this.contentLabel);
            this.mainPanel.Controls.Add(this.headerRichTextBox);
            this.mainPanel.Controls.Add(this.headerLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(17);
            this.mainPanel.Size = new System.Drawing.Size(274, 329);
            this.mainPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(182, 278);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(41, 31);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Navy;
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(12, 278);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(103, 31);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(151, 278);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 31);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // contentRichTextBox
            // 
            this.contentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentRichTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contentRichTextBox.Location = new System.Drawing.Point(20, 147);
            this.contentRichTextBox.Name = "contentRichTextBox";
            this.contentRichTextBox.Size = new System.Drawing.Size(235, 96);
            this.contentRichTextBox.TabIndex = 3;
            this.contentRichTextBox.Text = "";
            // 
            // contentLabel
            // 
            this.contentLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.contentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.contentLabel.Location = new System.Drawing.Point(17, 126);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(86, 17);
            this.contentLabel.TabIndex = 2;
            this.contentLabel.Text = "Content";
            // 
            // headerRichTextBox
            // 
            this.headerRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerRichTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.headerRichTextBox.Location = new System.Drawing.Point(20, 61);
            this.headerRichTextBox.Name = "headerRichTextBox";
            this.headerRichTextBox.Size = new System.Drawing.Size(235, 40);
            this.headerRichTextBox.TabIndex = 1;
            this.headerRichTextBox.Text = "";
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.headerLabel.Location = new System.Drawing.Point(17, 39);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(86, 17);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header";
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(274, 329);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sticky Note";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.RichTextBox headerRichTextBox;
        private System.Windows.Forms.RichTextBox contentRichTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button okButton;
    }
}
