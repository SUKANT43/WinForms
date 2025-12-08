namespace LineGameWithTimer
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.level3Button = new System.Windows.Forms.Button();
            this.level2Button = new System.Windows.Forms.Button();
            this.level1Button = new System.Windows.Forms.Button();
            this.level5Button = new System.Windows.Forms.Button();
            this.level4Button = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.level3Button);
            this.panel1.Controls.Add(this.level2Button);
            this.panel1.Controls.Add(this.level1Button);
            this.panel1.Controls.Add(this.level5Button);
            this.panel1.Controls.Add(this.level4Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(620, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 450);
            this.panel1.TabIndex = 5;
            // 
            // level3Button
            // 
            this.level3Button.Location = new System.Drawing.Point(37, 175);
            this.level3Button.Name = "level3Button";
            this.level3Button.Size = new System.Drawing.Size(93, 36);
            this.level3Button.TabIndex = 3;
            this.level3Button.Text = "Level 3";
            this.level3Button.UseVisualStyleBackColor = true;
            // 
            // level2Button
            // 
            this.level2Button.Location = new System.Drawing.Point(37, 113);
            this.level2Button.Name = "level2Button";
            this.level2Button.Size = new System.Drawing.Size(93, 36);
            this.level2Button.TabIndex = 4;
            this.level2Button.Text = "Level 2";
            this.level2Button.UseVisualStyleBackColor = true;
            this.level2Button.Click += new System.EventHandler(this.level2ButtonClick);
            // 
            // level1Button
            // 
            this.level1Button.Location = new System.Drawing.Point(37, 58);
            this.level1Button.Name = "level1Button";
            this.level1Button.Size = new System.Drawing.Size(93, 36);
            this.level1Button.TabIndex = 0;
            this.level1Button.Text = "Level 1";
            this.level1Button.UseVisualStyleBackColor = true;
            this.level1Button.Click += new System.EventHandler(this.level1ButtonClick);
            // 
            // level5Button
            // 
            this.level5Button.Location = new System.Drawing.Point(37, 293);
            this.level5Button.Name = "level5Button";
            this.level5Button.Size = new System.Drawing.Size(93, 36);
            this.level5Button.TabIndex = 1;
            this.level5Button.Text = "Level 5";
            this.level5Button.UseVisualStyleBackColor = true;
            this.level5Button.Click += new System.EventHandler(this.level5ButtonClick);
            // 
            // level4Button
            // 
            this.level4Button.Location = new System.Drawing.Point(37, 233);
            this.level4Button.Name = "level4Button";
            this.level4Button.Size = new System.Drawing.Size(93, 36);
            this.level4Button.TabIndex = 2;
            this.level4Button.Text = "Level 4\r\n";
            this.level4Button.UseVisualStyleBackColor = true;
            this.level4Button.Click += new System.EventHandler(this.level4ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button level1Button;
        private System.Windows.Forms.Button level2Button;
        private System.Windows.Forms.Button level3Button;
        private System.Windows.Forms.Button level4Button;
        private System.Windows.Forms.Button level5Button;
        private System.Windows.Forms.Panel panel1;
    }
}

