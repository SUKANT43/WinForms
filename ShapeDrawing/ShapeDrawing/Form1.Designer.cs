namespace ShapeDrawing
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
            this.rightPanel = new System.Windows.Forms.Panel();
            this.adjustableRectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightPanel.Controls.Add(this.adjustableRectangleButton);
            this.rightPanel.Controls.Add(this.lineButton);
            this.rightPanel.Controls.Add(this.triangleButton);
            this.rightPanel.Controls.Add(this.rectangleButton);
            this.rightPanel.Controls.Add(this.ellipseButton);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(628, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(172, 450);
            this.rightPanel.TabIndex = 0;
            // 
            // adjustableRectangleButton
            // 
            this.adjustableRectangleButton.Location = new System.Drawing.Point(23, 243);
            this.adjustableRectangleButton.Name = "adjustableRectangleButton";
            this.adjustableRectangleButton.Size = new System.Drawing.Size(121, 23);
            this.adjustableRectangleButton.TabIndex = 4;
            this.adjustableRectangleButton.Text = "Adjustable Rectangle";
            this.adjustableRectangleButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(48, 204);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 3;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButtonClick);
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(48, 164);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(75, 23);
            this.triangleButton.TabIndex = 2;
            this.triangleButton.Text = "Triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButtonClick);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(48, 122);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 1;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButtonClick);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(48, 79);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 0;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButtonClick);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.Window;
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(628, 450);
            this.leftPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.FlowLayoutPanel leftPanel;
        private System.Windows.Forms.Button adjustableRectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button ellipseButton;
    }
}

