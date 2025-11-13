namespace LineGame
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.level2button = new System.Windows.Forms.Button();
            this.level3Button = new System.Windows.Forms.Button();
            this.level4Button = new System.Windows.Forms.Button();
            this.level5Butoon = new System.Windows.Forms.Button();
            this.level1Button = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.LightGray;
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightPanel.Controls.Add(this.level2button);
            this.rightPanel.Controls.Add(this.level3Button);
            this.rightPanel.Controls.Add(this.level4Button);
            this.rightPanel.Controls.Add(this.level5Butoon);
            this.rightPanel.Controls.Add(this.level1Button);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(662, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(138, 450);
            this.rightPanel.TabIndex = 0;
            // 
            // level2button
            // 
            this.level2button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.level2button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level2button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level2button.Location = new System.Drawing.Point(29, 92);
            this.level2button.Name = "level2button";
            this.level2button.Size = new System.Drawing.Size(86, 31);
            this.level2button.TabIndex = 4;
            this.level2button.Text = "Level 2";
            this.level2button.UseVisualStyleBackColor = false;
            this.level2button.Click += new System.EventHandler(this.Level2buttonClick);
            // 
            // level3Button
            // 
            this.level3Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.level3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level3Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level3Button.Location = new System.Drawing.Point(29, 129);
            this.level3Button.Name = "level3Button";
            this.level3Button.Size = new System.Drawing.Size(86, 31);
            this.level3Button.TabIndex = 3;
            this.level3Button.Text = "Level 3";
            this.level3Button.UseVisualStyleBackColor = false;
            this.level3Button.Click += new System.EventHandler(this.Level3ButtonClick);
            // 
            // level4Button
            // 
            this.level4Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.level4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level4Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level4Button.Location = new System.Drawing.Point(29, 172);
            this.level4Button.Name = "level4Button";
            this.level4Button.Size = new System.Drawing.Size(86, 31);
            this.level4Button.TabIndex = 2;
            this.level4Button.Text = "Level 4";
            this.level4Button.UseVisualStyleBackColor = false;
            this.level4Button.Click += new System.EventHandler(this.Level4ButtonClick);
            // 
            // level5Butoon
            // 
            this.level5Butoon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.level5Butoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level5Butoon.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level5Butoon.Location = new System.Drawing.Point(29, 209);
            this.level5Butoon.Name = "level5Butoon";
            this.level5Butoon.Size = new System.Drawing.Size(86, 31);
            this.level5Butoon.TabIndex = 1;
            this.level5Butoon.Text = "Level 5";
            this.level5Butoon.UseVisualStyleBackColor = false;
            this.level5Butoon.Click += new System.EventHandler(this.Level5ButoonClick);
            // 
            // level1Button
            // 
            this.level1Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.level1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level1Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level1Button.Location = new System.Drawing.Point(29, 55);
            this.level1Button.Name = "level1Button";
            this.level1Button.Size = new System.Drawing.Size(86, 31);
            this.level1Button.TabIndex = 0;
            this.level1Button.Text = "Level 1";
            this.level1Button.UseVisualStyleBackColor = false;
            this.level1Button.Click += new System.EventHandler(this.Level1ButtonClick);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(662, 450);
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

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button level1Button;
        private System.Windows.Forms.Button level2button;
        private System.Windows.Forms.Button level3Button;
        private System.Windows.Forms.Button level4Button;
        private System.Windows.Forms.Button level5Butoon;
    }
}

