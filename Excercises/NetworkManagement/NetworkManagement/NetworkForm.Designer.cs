namespace NetworkManagement
{
    partial class NetworkForm
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
            this.NetworkFormPanel = new System.Windows.Forms.Panel();
            this.NetworkLabel = new System.Windows.Forms.Label();
            this.personalDetails = new NetworkManagement.PersonalDetails();

            // Panel
            this.NetworkFormPanel.AutoScroll = true;
            this.NetworkFormPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.NetworkFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkFormPanel.Location = new System.Drawing.Point(0, 0);
            this.NetworkFormPanel.Name = "NetworkFormPanel";
            this.NetworkFormPanel.Size = new System.Drawing.Size(800, 450);
            this.NetworkFormPanel.TabIndex = 0;

            // Label
            this.NetworkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.NetworkLabel.Location = new System.Drawing.Point(230, 21);
            this.NetworkLabel.Name = "NetworkLabel";
            this.NetworkLabel.Size = new System.Drawing.Size(200, 30);
            this.NetworkLabel.TabIndex = 0;
            this.NetworkLabel.Text = "Network Form";

            // PersonalDetails UserControl
            this.personalDetails.Location = new System.Drawing.Point(20, 70);
            this.personalDetails.Name = "personalDetails";
            this.personalDetails.Size = new System.Drawing.Size(500, 300);

            // Add controls to Panel
            this.NetworkFormPanel.Controls.Add(this.NetworkLabel);
            this.NetworkFormPanel.Controls.Add(this.personalDetails);

            // Add Panel to Form
            this.Controls.Add(this.NetworkFormPanel);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "NetworkForm";
            this.Text = "Network Form";
        }

        #endregion
        private System.Windows.Forms.Panel NetworkFormPanel;
        private System.Windows.Forms.Label NetworkLabel;
        private PersonalDetails personalDetails;


    }
}