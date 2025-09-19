namespace NetworkManagement
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


        


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginPagePanel = new System.Windows.Forms.Panel();
            this.LoginPageGroupBox = new System.Windows.Forms.GroupBox();
            this.LoginPageLabel = new System.Windows.Forms.Label();
            this.UserEmailLabel = new System.Windows.Forms.Label();
            this.UserPasswordLabel = new System.Windows.Forms.Label();
            this.UserEmailTextBox = new System.Windows.Forms.TextBox();
            this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPagePanel.SuspendLayout();
            this.LoginPageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPagePanel
            // 
            this.LoginPagePanel.Controls.Add(this.LoginPageGroupBox);
            this.LoginPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPagePanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPagePanel.Name = "LoginPagePanel";
            this.LoginPagePanel.Size = new System.Drawing.Size(800, 450);
            this.LoginPagePanel.TabIndex = 0;
            // 
            // LoginPageGroupBox
            // 
            this.LoginPageGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginPageGroupBox.Controls.Add(this.LoginPageLabel);
            this.LoginPageGroupBox.Controls.Add(this.UserEmailLabel);
            this.LoginPageGroupBox.Controls.Add(this.UserPasswordLabel);
            this.LoginPageGroupBox.Controls.Add(this.UserEmailTextBox);
            this.LoginPageGroupBox.Controls.Add(this.UserPasswordTextBox);
            this.LoginPageGroupBox.Controls.Add(this.LoginButton);
            this.LoginPageGroupBox.Location = new System.Drawing.Point(142, 83);
            this.LoginPageGroupBox.Name = "LoginPageGroupBox";
            this.LoginPageGroupBox.Size = new System.Drawing.Size(336, 249);
            this.LoginPageGroupBox.TabIndex = 0;
            this.LoginPageGroupBox.TabStop = false;
            // 
            // LoginPageLabel
            // 
            this.LoginPageLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LoginPageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginPageLabel.Location = new System.Drawing.Point(0, 0);
            this.LoginPageLabel.Name = "LoginPageLabel";
            this.LoginPageLabel.Size = new System.Drawing.Size(336, 31);
            this.LoginPageLabel.TabIndex = 0;
            this.LoginPageLabel.Text = "User Sign In";
            this.LoginPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserEmailLabel
            // 
            this.UserEmailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.UserEmailLabel.Location = new System.Drawing.Point(56, 68);
            this.UserEmailLabel.Name = "UserEmailLabel";
            this.UserEmailLabel.Size = new System.Drawing.Size(39, 20);
            this.UserEmailLabel.TabIndex = 1;
            this.UserEmailLabel.Text = "Email:";
            // 
            // UserPasswordLabel
            // 
            this.UserPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.UserPasswordLabel.Location = new System.Drawing.Point(56, 111);
            this.UserPasswordLabel.Name = "UserPasswordLabel";
            this.UserPasswordLabel.Size = new System.Drawing.Size(73, 17);
            this.UserPasswordLabel.TabIndex = 2;
            this.UserPasswordLabel.Text = "Password:";
            // 
            // UserEmailTextBox
            // 
            this.UserEmailTextBox.Location = new System.Drawing.Point(138, 68);
            this.UserEmailTextBox.Name = "UserEmailTextBox";
            this.UserEmailTextBox.Size = new System.Drawing.Size(162, 20);
            this.UserEmailTextBox.TabIndex = 3;
            // 
            // UserPasswordTextBox
            // 
            this.UserPasswordTextBox.Location = new System.Drawing.Point(138, 111);
            this.UserPasswordTextBox.Name = "UserPasswordTextBox";
            this.UserPasswordTextBox.Size = new System.Drawing.Size(162, 17);
            this.UserPasswordTextBox.TabIndex = 4;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.AliceBlue;
            this.LoginButton.Location = new System.Drawing.Point(138, 167);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginPagePanel);
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.LoginPagePanel.ResumeLayout(false);
            this.LoginPageGroupBox.ResumeLayout(false);
            this.LoginPageGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel LoginPagePanel;
        private System.Windows.Forms.GroupBox LoginPageGroupBox;
        private System.Windows.Forms.Label LoginPageLabel;
        private System.Windows.Forms.Label UserEmailLabel;
        private System.Windows.Forms.Label UserPasswordLabel;
        private System.Windows.Forms.TextBox UserEmailTextBox;
        private System.Windows.Forms.TextBox UserPasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
    }
}