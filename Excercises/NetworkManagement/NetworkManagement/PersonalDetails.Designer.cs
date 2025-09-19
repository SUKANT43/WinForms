namespace NetworkManagement
{
    partial class PersonalDetails
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
            this.PersonalDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.MobileNumberLabel = new System.Windows.Forms.Label();
            this.MobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.ResidentGroupBox = new System.Windows.Forms.GroupBox();
            this.IndiaRadioButton = new System.Windows.Forms.RadioButton();
            this.NriRadioButton = new System.Windows.Forms.RadioButton();
            this.OtherRadioButton = new System.Windows.Forms.RadioButton();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PersonalDetailsGroupBox.SuspendLayout();
            this.ResidentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersonalDetailsGroupBox
            // 
            this.PersonalDetailsGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PersonalDetailsGroupBox.Controls.Add(this.NameLabel);
            this.PersonalDetailsGroupBox.Controls.Add(this.NameTextBox);
            this.PersonalDetailsGroupBox.Controls.Add(this.MobileNumberLabel);
            this.PersonalDetailsGroupBox.Controls.Add(this.MobileNumberTextBox);
            this.PersonalDetailsGroupBox.Controls.Add(this.ResidentGroupBox);
            this.PersonalDetailsGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.PersonalDetailsGroupBox.Location = new System.Drawing.Point(12, 67);
            this.PersonalDetailsGroupBox.Name = "PersonalDetailsGroupBox";
            this.PersonalDetailsGroupBox.Size = new System.Drawing.Size(457, 314);
            this.PersonalDetailsGroupBox.TabIndex = 1;
            this.PersonalDetailsGroupBox.TabStop = false;
            this.PersonalDetailsGroupBox.Text = "Personal Details";
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(6, 36);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(52, 23);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(140, 34);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(160, 25);
            this.NameTextBox.TabIndex = 1;
            // 
            // MobileNumberLabel
            // 
            this.MobileNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MobileNumberLabel.Location = new System.Drawing.Point(6, 72);
            this.MobileNumberLabel.Name = "MobileNumberLabel";
            this.MobileNumberLabel.Size = new System.Drawing.Size(128, 23);
            this.MobileNumberLabel.TabIndex = 2;
            this.MobileNumberLabel.Text = "Mobile Number(+91):";
            // 
            // MobileNumberTextBox
            // 
            this.MobileNumberTextBox.Location = new System.Drawing.Point(140, 70);
            this.MobileNumberTextBox.Name = "MobileNumberTextBox";
            this.MobileNumberTextBox.Size = new System.Drawing.Size(160, 25);
            this.MobileNumberTextBox.TabIndex = 3;
            // 
            // ResidentGroupBox
            // 
            this.ResidentGroupBox.Controls.Add(this.IndiaRadioButton);
            this.ResidentGroupBox.Controls.Add(this.NriRadioButton);
            this.ResidentGroupBox.Controls.Add(this.OtherRadioButton);
            this.ResidentGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ResidentGroupBox.Location = new System.Drawing.Point(0, 114);
            this.ResidentGroupBox.Name = "ResidentGroupBox";
            this.ResidentGroupBox.Size = new System.Drawing.Size(308, 56);
            this.ResidentGroupBox.TabIndex = 6;
            this.ResidentGroupBox.TabStop = false;
            this.ResidentGroupBox.Text = "Resident Type:";
            // 
            // IndiaRadioButton
            // 
            this.IndiaRadioButton.Location = new System.Drawing.Point(155, 22);
            this.IndiaRadioButton.Name = "IndiaRadioButton";
            this.IndiaRadioButton.Size = new System.Drawing.Size(53, 24);
            this.IndiaRadioButton.TabIndex = 0;
            this.IndiaRadioButton.Text = "India";
            // 
            // NriRadioButton
            // 
            this.NriRadioButton.Location = new System.Drawing.Point(92, 22);
            this.NriRadioButton.Name = "NriRadioButton";
            this.NriRadioButton.Size = new System.Drawing.Size(73, 24);
            this.NriRadioButton.TabIndex = 1;
            this.NriRadioButton.Text = "NRI";
            // 
            // OtherRadioButton
            // 
            this.OtherRadioButton.Location = new System.Drawing.Point(222, 22);
            this.OtherRadioButton.Name = "OtherRadioButton";
            this.OtherRadioButton.Size = new System.Drawing.Size(59, 24);
            this.OtherRadioButton.TabIndex = 2;
            this.OtherRadioButton.Text = "Other";
            // 
            // EmailLabel
            // 
            this.EmailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.EmailLabel.Location = new System.Drawing.Point(6, 104);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(100, 23);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email: ";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(140, 104);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(160, 20);
            this.EmailTextBox.TabIndex = 5;
            // 
            // PersonalDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PersonalDetailsGroupBox);
            this.Name = "PersonalDetails";
            this.Text = "NetworkForm";
            this.PersonalDetailsGroupBox.ResumeLayout(false);
            this.PersonalDetailsGroupBox.PerformLayout();
            this.ResidentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PersonalDetailsGroupBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label MobileNumberLabel;
        private System.Windows.Forms.TextBox MobileNumberTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.GroupBox ResidentGroupBox;
        private System.Windows.Forms.RadioButton IndiaRadioButton;
        private System.Windows.Forms.RadioButton NriRadioButton;
        private System.Windows.Forms.RadioButton OtherRadioButton;


    }
}