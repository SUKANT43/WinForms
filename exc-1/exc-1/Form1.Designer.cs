namespace exc_1
{
    partial class Form1
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.colNum = new System.Windows.Forms.NumericUpDown();
            this.rowGap = new System.Windows.Forms.NumericUpDown();
            this.colGap = new System.Windows.Forms.NumericUpDown();
            this.rowNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNum)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.generateButton);
            this.sidePanel.Controls.Add(this.colNum);
            this.sidePanel.Controls.Add(this.rowGap);
            this.sidePanel.Controls.Add(this.colGap);
            this.sidePanel.Controls.Add(this.rowNum);
            this.sidePanel.Controls.Add(this.label4);
            this.sidePanel.Controls.Add(this.label3);
            this.sidePanel.Controls.Add(this.label2);
            this.sidePanel.Controls.Add(this.label1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidePanel.Location = new System.Drawing.Point(957, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(233, 627);
            this.sidePanel.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(95, 164);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(86, 34);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // colNum
            // 
            this.colNum.Location = new System.Drawing.Point(88, 81);
            this.colNum.Name = "colNum";
            this.colNum.Size = new System.Drawing.Size(119, 20);
            this.colNum.TabIndex = 7;
            this.colNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rowGap
            // 
            this.rowGap.Location = new System.Drawing.Point(88, 107);
            this.rowGap.Name = "rowGap";
            this.rowGap.Size = new System.Drawing.Size(119, 20);
            this.rowGap.TabIndex = 6;
            this.rowGap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colGap
            // 
            this.colGap.Location = new System.Drawing.Point(88, 133);
            this.colGap.Name = "colGap";
            this.colGap.Size = new System.Drawing.Size(119, 20);
            this.colGap.TabIndex = 5;
            this.colGap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rowNum
            // 
            this.rowNum.Location = new System.Drawing.Point(88, 55);
            this.rowNum.Name = "rowNum";
            this.rowNum.Size = new System.Drawing.Size(119, 20);
            this.rowNum.TabIndex = 4;
            this.rowNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Col Gap:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Row Gap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Col:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Row:";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(957, 627);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.AutoScroll = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 627);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.NumericUpDown colNum;
        private System.Windows.Forms.NumericUpDown rowGap;
        private System.Windows.Forms.NumericUpDown colGap;
        private System.Windows.Forms.NumericUpDown rowNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

