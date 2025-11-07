namespace Graph
{
    partial class DragDropCanvas
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
            this.rightPanel = new System.Windows.Forms.Panel();
            this.triangleGenerator = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.generateEllipseButton = new System.Windows.Forms.Button();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.generateEllipseButton);
            this.rightPanel.Controls.Add(this.triangleGenerator);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(619, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(181, 450);
            this.rightPanel.TabIndex = 0;
            // 
            // triangleGenerator
            // 
            this.triangleGenerator.Location = new System.Drawing.Point(47, 82);
            this.triangleGenerator.Name = "triangleGenerator";
            this.triangleGenerator.Size = new System.Drawing.Size(92, 30);
            this.triangleGenerator.TabIndex = 0;
            this.triangleGenerator.Text = "Triangle";
            this.triangleGenerator.UseVisualStyleBackColor = true;
            this.triangleGenerator.Click += new System.EventHandler(this.TriangleGeneratorButton);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(619, 450);
            this.leftPanel.TabIndex = 1;
            // 
            // generateEllipseButton
            // 
            this.generateEllipseButton.Location = new System.Drawing.Point(47, 151);
            this.generateEllipseButton.Name = "generateEllipseButton";
            this.generateEllipseButton.Size = new System.Drawing.Size(92, 30);
            this.generateEllipseButton.TabIndex = 1;
            this.generateEllipseButton.Text = "Ellipse";
            this.generateEllipseButton.UseVisualStyleBackColor = true;
            // 
            // DragDropCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.Name = "DragDropCanvas";
            this.Text = "DragDropCanvas";
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button triangleGenerator;
        private System.Windows.Forms.Button generateEllipseButton;
    }
}