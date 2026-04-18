namespace CrudWinforms
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
            this.authPanel = new System.Windows.Forms.Panel();
            this.signUpPage = new CrudWinforms.SignUpPage();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.crudTabPage = new System.Windows.Forms.TabPage();
            this.crudPage1 = new CrudWinforms.CrudPage();
            this.analytiTabPage = new System.Windows.Forms.TabPage();
            this.analyticPage1 = new CrudWinforms.AnalyticPage();
            this.navBar = new CrudWinforms.NavBar();
            this.loginPage = new CrudWinforms.LoginPage();
            this.authPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.crudTabPage.SuspendLayout();
            this.analytiTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // authPanel
            // 
            this.authPanel.CausesValidation = false;
            this.authPanel.Controls.Add(this.loginPage);
            this.authPanel.Controls.Add(this.signUpPage);
            this.authPanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.authPanel.Location = new System.Drawing.Point(698, 72);
            this.authPanel.Name = "authPanel";
            this.authPanel.Size = new System.Drawing.Size(522, 502);
            this.authPanel.TabIndex = 0;
            // 
            // signUpPage
            // 
            this.signUpPage.Location = new System.Drawing.Point(53, 208);
            this.signUpPage.Name = "signUpPage";
            this.signUpPage.Size = new System.Drawing.Size(448, 277);
            this.signUpPage.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.CausesValidation = false;
            this.mainPanel.Controls.Add(this.tabControl);
            this.mainPanel.Controls.Add(this.navBar);
            this.mainPanel.Location = new System.Drawing.Point(113, 82);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(416, 326);
            this.mainPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.crudTabPage);
            this.tabControl.Controls.Add(this.analytiTabPage);
            this.tabControl.Location = new System.Drawing.Point(129, 11);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(253, 72);
            this.tabControl.TabIndex = 1;
            // 
            // crudTabPage
            // 
            this.crudTabPage.Controls.Add(this.crudPage1);
            this.crudTabPage.Location = new System.Drawing.Point(4, 22);
            this.crudTabPage.Name = "crudTabPage";
            this.crudTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.crudTabPage.Size = new System.Drawing.Size(245, 46);
            this.crudTabPage.TabIndex = 0;
            this.crudTabPage.Text = "crudPage";
            this.crudTabPage.UseVisualStyleBackColor = true;
            // 
            // crudPage1
            // 
            this.crudPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crudPage1.Location = new System.Drawing.Point(3, 3);
            this.crudPage1.Name = "crudPage1";
            this.crudPage1.Size = new System.Drawing.Size(239, 40);
            this.crudPage1.TabIndex = 0;
            // 
            // analytiTabPage
            // 
            this.analytiTabPage.Controls.Add(this.analyticPage1);
            this.analytiTabPage.Location = new System.Drawing.Point(4, 22);
            this.analytiTabPage.Name = "analytiTabPage";
            this.analytiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.analytiTabPage.Size = new System.Drawing.Size(245, 46);
            this.analytiTabPage.TabIndex = 1;
            this.analytiTabPage.Text = "analyticPage";
            this.analytiTabPage.UseVisualStyleBackColor = true;
            // 
            // analyticPage1
            // 
            this.analyticPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyticPage1.Location = new System.Drawing.Point(3, 3);
            this.analyticPage1.Name = "analyticPage1";
            this.analyticPage1.Size = new System.Drawing.Size(239, 40);
            this.analyticPage1.TabIndex = 0;
            // 
            // navBar
            // 
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(137, 326);
            this.navBar.TabIndex = 0;
            // 
            // loginPage
            // 
            this.loginPage.Location = new System.Drawing.Point(41, 36);
            this.loginPage.Name = "loginPage";
            this.loginPage.Size = new System.Drawing.Size(307, 89);
            this.loginPage.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 605);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.authPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.authPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.crudTabPage.ResumeLayout(false);
            this.analytiTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SignUpPage signUpPage;
        private System.Windows.Forms.Panel authPanel;
        private System.Windows.Forms.Panel mainPanel;
        private NavBar navBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage crudTabPage;
        private System.Windows.Forms.TabPage analytiTabPage;
        private CrudPage crudPage1;
        private AnalyticPage analyticPage1;
        private LoginPage loginPage;
    }
}

