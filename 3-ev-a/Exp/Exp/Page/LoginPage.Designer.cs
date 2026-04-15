namespace Exp.Page
{
    partial class LoginPage
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.quoteLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.quoteLabel);
            this.topPanel.Controls.Add(this.welcomeLabel);
            this.topPanel.Location = new System.Drawing.Point(94, 25);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(241, 82);
            this.topPanel.TabIndex = 0;
            // 
            // quoteLabel
            // 
            this.quoteLabel.AutoSize = true;
            this.quoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.quoteLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.quoteLabel.Location = new System.Drawing.Point(23, 52);
            this.quoteLabel.Name = "quoteLabel";
            this.quoteLabel.Size = new System.Drawing.Size(203, 17);
            this.quoteLabel.TabIndex = 1;
            this.quoteLabel.Text = "Continue your financial journey";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.Location = new System.Drawing.Point(20, 12);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(206, 31);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome Back";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(27, 134);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(390, 406);
            this.mainPanel.TabIndex = 1;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(445, 571);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label quoteLabel;
        private System.Windows.Forms.Panel mainPanel;
    }
}
