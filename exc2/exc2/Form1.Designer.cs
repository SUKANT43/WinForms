﻿namespace exc2
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.removeBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.deleteButton);
            this.leftPanel.Controls.Add(this.removeBox);
            this.leftPanel.Controls.Add(this.label3);
            this.leftPanel.Controls.Add(this.generateButton);
            this.leftPanel.Controls.Add(this.heightBox);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.widthBox);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.leftPanel.Location = new System.Drawing.Point(602, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(198, 450);
            this.leftPanel.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(77, 187);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(85, 29);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteBtn);
            // 
            // removeBox
            // 
            this.removeBox.Location = new System.Drawing.Point(66, 161);
            this.removeBox.Name = "removeBox";
            this.removeBox.Size = new System.Drawing.Size(120, 20);
            this.removeBox.TabIndex = 6;
            this.removeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remove:";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(77, 85);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(85, 29);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateBtn);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(66, 50);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(120, 20);
            this.heightBox.TabIndex = 3;
            this.heightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(66, 24);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(120, 20);
            this.widthBox.TabIndex = 1;
            this.widthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(602, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.NumericUpDown removeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown widthBox;
        private System.Windows.Forms.Label label1;
    }
}

