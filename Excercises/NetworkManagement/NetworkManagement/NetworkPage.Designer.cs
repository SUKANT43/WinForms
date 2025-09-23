namespace NetworkManagement
{
    partial class NetworkPage
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
            this.NetworkPagePanel = new System.Windows.Forms.Panel();
            this.NetworkPageTitleLabel = new System.Windows.Forms.Label();
            this.pd = new NetworkManagement.PersonalDetails();
            this.sr = new NetworkManagement.ServiceRequirementForm();
            this.NetworkPagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NetworkPagePanel
            // 
            this.NetworkPagePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.NetworkPagePanel.Controls.Add(this.NetworkPageTitleLabel);
            this.NetworkPagePanel.Controls.Add(this.pd);
            this.NetworkPagePanel.Controls.Add(this.sr);
            this.NetworkPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkPagePanel.Location = new System.Drawing.Point(0, 0);
            this.NetworkPagePanel.Name = "NetworkPagePanel";
            this.NetworkPagePanel.Size = new System.Drawing.Size(800, 450);
            this.NetworkPagePanel.TabIndex = 0;
            // 
            // NetworkPageTitleLabel
            // 
            this.NetworkPageTitleLabel.AutoSize = true;
            this.NetworkPageTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.NetworkPageTitleLabel.Location = new System.Drawing.Point(147, 26);
            this.NetworkPageTitleLabel.Name = "NetworkPageTitleLabel";
            this.NetworkPageTitleLabel.Size = new System.Drawing.Size(178, 21);
            this.NetworkPageTitleLabel.TabIndex = 1;
            this.NetworkPageTitleLabel.Text = "Network request form";
            // 
            // pd
            // 
            this.pd.Location = new System.Drawing.Point(3, 50);
            this.pd.Name = "pd";
            this.pd.Size = new System.Drawing.Size(470, 388);
            this.pd.TabIndex = 2;
            // 
            // sr
            // 
            this.sr.Location = new System.Drawing.Point(463, 50);
            this.sr.Name = "sr";
            this.sr.Size = new System.Drawing.Size(531, 735);
            this.sr.TabIndex = 3;
            // 
            // NetworkPage
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NetworkPagePanel);
            this.Name = "NetworkPage";
            this.Text = "NetworkPage";
            this.NetworkPagePanel.ResumeLayout(false);
            this.NetworkPagePanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel NetworkPagePanel;
        private System.Windows.Forms.Label NetworkPageTitleLabel;
        private PersonalDetails pd;
        private ServiceRequirementForm sr;
    }
}