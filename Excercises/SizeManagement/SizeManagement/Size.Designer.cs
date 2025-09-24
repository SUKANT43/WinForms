namespace SizeManagement
{
    partial class GenerateSize
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.rowLabel = new System.Windows.Forms.Label();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.genertaeSizeButton = new System.Windows.Forms.Button();
            this.colLabel = new System.Windows.Forms.Label();
            this.colTextBox = new System.Windows.Forms.TextBox();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.rowLabel);
            this.controlPanel.Controls.Add(this.rowTextBox);
            this.controlPanel.Controls.Add(this.genertaeSizeButton);
            this.controlPanel.Controls.Add(this.colLabel);
            this.controlPanel.Controls.Add(this.colTextBox);
            this.controlPanel.Location = new System.Drawing.Point(600, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(200, 137);
            this.controlPanel.TabIndex = 1;

            // 
            // rowLabel
            // 
            this.rowLabel.Location = new System.Drawing.Point(9, 6);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(36, 23);
            this.rowLabel.TabIndex = 0;
            this.rowLabel.Text = "Row:";
            // 
            // rowTextBox
            // 
            this.rowTextBox.Location = new System.Drawing.Point(51, 6);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(100, 20);
            this.rowTextBox.TabIndex = 1;
            // 
            // genertaeSizeButton
            // 
            this.genertaeSizeButton.Location = new System.Drawing.Point(51, 68);
            this.genertaeSizeButton.Name = "genertaeSizeButton";
            this.genertaeSizeButton.Size = new System.Drawing.Size(75, 23);
            this.genertaeSizeButton.TabIndex = 4;
            this.genertaeSizeButton.Text = "Generate";
            this.genertaeSizeButton.Click += new System.EventHandler(this.genertaeSizeButton_Click);
            // 
            // colLabel
            // 
            this.colLabel.Location = new System.Drawing.Point(9, 29);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(42, 23);
            this.colLabel.TabIndex = 2;
            this.colLabel.Text = "Col:";
            // 
            // colTextBox
            // 
            this.colTextBox.Location = new System.Drawing.Point(51, 32);
            this.colTextBox.Name = "colTextBox";
            this.colTextBox.Size = new System.Drawing.Size(100, 20);
            this.colTextBox.TabIndex = 3;
            // 
            // GenerateSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlPanel);
            this.Name = "GenerateSize";
            this.Text = "Form1";
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.MaximumSize = new System.Drawing.Size(850,500);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.TextBox rowTextBox;
        private System.Windows.Forms.TextBox colTextBox;
        private System.Windows.Forms.Button genertaeSizeButton;
    }
}

