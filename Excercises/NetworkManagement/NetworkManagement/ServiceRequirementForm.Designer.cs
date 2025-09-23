namespace NetworkManagement
{
    partial class ServiceRequirementForm
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
            this.ServiceRequirementFormPanel = new System.Windows.Forms.Panel();
            this.ServiceRequirementLabel = new System.Windows.Forms.Label();
            this.SimTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.EsimRadioButton = new System.Windows.Forms.RadioButton();
            this.PhysicalSimRadioButton = new System.Windows.Forms.RadioButton();
            this.ConnectionTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.NewConnectionRadioButton = new System.Windows.Forms.RadioButton();
            this.RelocationRadioButton = new System.Windows.Forms.RadioButton();
            this.IsNew = new System.Windows.Forms.Panel();
            this.NewAddressLabel = new System.Windows.Forms.Label();
            this.NewAddressRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PlanComboBox = new System.Windows.Forms.ComboBox();
            this.PlanDurationLabel = new System.Windows.Forms.Label();
            this.OldAddressLabel = new System.Windows.Forms.Label();
            this.OldAddressRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ServiceRequirementFormPanel.SuspendLayout();
            this.SimTypeGroupBox.SuspendLayout();
            this.ConnectionTypeGroupBox.SuspendLayout();
            this.IsNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServiceRequirementFormPanel
            // 
            this.ServiceRequirementFormPanel.Controls.Add(this.ServiceRequirementLabel);
            this.ServiceRequirementFormPanel.Controls.Add(this.SimTypeGroupBox);
            this.ServiceRequirementFormPanel.Controls.Add(this.ConnectionTypeGroupBox);
            //this.ServiceRequirementFormPanel.Controls.Add(this.IsNew);
            this.ServiceRequirementFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceRequirementFormPanel.Location = new System.Drawing.Point(0, 0);
            this.ServiceRequirementFormPanel.Name = "ServiceRequirementFormPanel";
            this.ServiceRequirementFormPanel.Size = new System.Drawing.Size(1050, 641);
            this.ServiceRequirementFormPanel.TabIndex = 0;
            // 
            // ServiceRequirementLabel
            // 
            this.ServiceRequirementLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ServiceRequirementLabel.Location = new System.Drawing.Point(134, 16);
            this.ServiceRequirementLabel.Name = "ServiceRequirementLabel";
            this.ServiceRequirementLabel.Size = new System.Drawing.Size(172, 23);
            this.ServiceRequirementLabel.TabIndex = 0;
            this.ServiceRequirementLabel.Text = "Service Requirements";
            // 
            // SimTypeGroupBox
            // 
            this.SimTypeGroupBox.Controls.Add(this.EsimRadioButton);
            this.SimTypeGroupBox.Controls.Add(this.PhysicalSimRadioButton);
            this.SimTypeGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SimTypeGroupBox.Location = new System.Drawing.Point(23, 71);
            this.SimTypeGroupBox.Name = "SimTypeGroupBox";
            this.SimTypeGroupBox.Size = new System.Drawing.Size(177, 59);
            this.SimTypeGroupBox.TabIndex = 1;
            this.SimTypeGroupBox.TabStop = false;
            this.SimTypeGroupBox.Text = "SIM Type";
            // 
            // EsimRadioButton
            // 
            this.EsimRadioButton.Location = new System.Drawing.Point(101, 22);
            this.EsimRadioButton.Name = "EsimRadioButton";
            this.EsimRadioButton.Size = new System.Drawing.Size(57, 24);
            this.EsimRadioButton.TabIndex = 0;
            this.EsimRadioButton.Text = "eSim";
            // 
            // PhysicalSimRadioButton
            // 
            this.PhysicalSimRadioButton.Location = new System.Drawing.Point(18, 22);
            this.PhysicalSimRadioButton.Name = "PhysicalSimRadioButton";
            this.PhysicalSimRadioButton.Size = new System.Drawing.Size(77, 24);
            this.PhysicalSimRadioButton.TabIndex = 1;
            this.PhysicalSimRadioButton.Text = "Physical";
            // 
            // ConnectionTypeGroupBox
            // 
            this.ConnectionTypeGroupBox.Controls.Add(this.NewConnectionRadioButton);
            this.ConnectionTypeGroupBox.Controls.Add(this.RelocationRadioButton);
            this.ConnectionTypeGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ConnectionTypeGroupBox.Location = new System.Drawing.Point(23, 156);
            this.ConnectionTypeGroupBox.Name = "ConnectionTypeGroupBox";
            this.ConnectionTypeGroupBox.Size = new System.Drawing.Size(243, 62);
            this.ConnectionTypeGroupBox.TabIndex = 2;
            this.ConnectionTypeGroupBox.TabStop = false;
            this.ConnectionTypeGroupBox.Text = "Connection Type:";
            // 
            // NewConnectionRadioButton
            // 
            this.NewConnectionRadioButton.Location = new System.Drawing.Point(124, 22);
            this.NewConnectionRadioButton.Name = "NewConnectionRadioButton";
            this.NewConnectionRadioButton.Size = new System.Drawing.Size(119, 24);
            this.NewConnectionRadioButton.TabIndex = 0;
            this.NewConnectionRadioButton.Text = "New Connection";
            this.NewConnectionRadioButton.CheckedChanged += new System.EventHandler(this.NewConnectionRadioButton_CheckedChanged);
            // 
            // RelocationRadioButton
            // 
            this.RelocationRadioButton.Location = new System.Drawing.Point(18, 22);
            this.RelocationRadioButton.Name = "RelocationRadioButton";
            this.RelocationRadioButton.Size = new System.Drawing.Size(92, 24);
            this.RelocationRadioButton.TabIndex = 0;
            this.RelocationRadioButton.Text = "Relocation";
            this.RelocationRadioButton.CheckedChanged += new System.EventHandler(this.RelocationRadioButton_CheckedChanged);
            // 
            // IsNew
            // 
            this.IsNew.Controls.Add(this.NewAddressLabel);
            this.IsNew.Controls.Add(this.NewAddressRichTextBox);
            this.IsNew.Controls.Add(this.PlanComboBox);
            this.IsNew.Controls.Add(this.PlanDurationLabel);
            this.IsNew.Controls.Add(this.OldAddressLabel);
            this.IsNew.Controls.Add(this.OldAddressRichTextBox);
            this.IsNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.IsNew.Location = new System.Drawing.Point(23, 244);
            this.IsNew.Name = "IsNew";
            this.IsNew.Size = new System.Drawing.Size(388, 369);
            this.IsNew.TabIndex = 3;
            // 
            // NewAddressLabel
            // 
            this.NewAddressLabel.Location = new System.Drawing.Point(3, 17);
            this.NewAddressLabel.Name = "NewAddressLabel";
            this.NewAddressLabel.Size = new System.Drawing.Size(85, 23);
            this.NewAddressLabel.TabIndex = 0;
            this.NewAddressLabel.Text = "New Address:";
            // 
            // NewAddressRichTextBox
            // 
            this.NewAddressRichTextBox.Location = new System.Drawing.Point(115, 17);
            this.NewAddressRichTextBox.Name = "NewAddressRichTextBox";
            this.NewAddressRichTextBox.Size = new System.Drawing.Size(121, 96);
            this.NewAddressRichTextBox.TabIndex = 0;
            this.NewAddressRichTextBox.Text = "";
            // 
            // PlanComboBox
            // 
            this.PlanComboBox.Items.AddRange(new object[] {
            "Weekly",
            "Monthly",
            "Quarterly"});
            this.PlanComboBox.Location = new System.Drawing.Point(115, 133);
            this.PlanComboBox.Name = "PlanComboBox";
            this.PlanComboBox.Size = new System.Drawing.Size(121, 23);
            this.PlanComboBox.TabIndex = 0;
            // 
            // PlanDurationLabel
            // 
            this.PlanDurationLabel.Location = new System.Drawing.Point(3, 133);
            this.PlanDurationLabel.Name = "PlanDurationLabel";
            this.PlanDurationLabel.Size = new System.Drawing.Size(85, 23);
            this.PlanDurationLabel.TabIndex = 1;
            this.PlanDurationLabel.Text = "Plan Duration:";
            // 
            // OldAddressLabel
            // 
            this.OldAddressLabel.Location = new System.Drawing.Point(3, 180);
            this.OldAddressLabel.Name = "OldAddressLabel";
            this.OldAddressLabel.Size = new System.Drawing.Size(85, 23);
            this.OldAddressLabel.TabIndex = 4;
            this.OldAddressLabel.Text = "Old Address:";
            // 
            // OldAddressRichTextBox
            // 
            this.OldAddressRichTextBox.Location = new System.Drawing.Point(115, 180);
            this.OldAddressRichTextBox.Name = "OldAddressRichTextBox";
            this.OldAddressRichTextBox.Size = new System.Drawing.Size(121, 96);
            this.OldAddressRichTextBox.TabIndex = 5;
            this.OldAddressRichTextBox.Text = "";
            // 
            // ServiceRequirementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ServiceRequirementFormPanel);
            this.Name = "ServiceRequirementForm";
            this.Size = new System.Drawing.Size(1050, 641);
            this.ServiceRequirementFormPanel.ResumeLayout(false);
            this.SimTypeGroupBox.ResumeLayout(false);
            this.ConnectionTypeGroupBox.ResumeLayout(false);
            this.IsNew.ResumeLayout(false);
            this.IsNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ServiceRequirementFormPanel;
        private System.Windows.Forms.Label ServiceRequirementLabel;
        private System.Windows.Forms.GroupBox SimTypeGroupBox;
        private System.Windows.Forms.RadioButton PhysicalSimRadioButton;
        private System.Windows.Forms.RadioButton EsimRadioButton;
        private System.Windows.Forms.GroupBox ConnectionTypeGroupBox;
        private System.Windows.Forms.RadioButton NewConnectionRadioButton;
        private System.Windows.Forms.RadioButton RelocationRadioButton;
        private System.Windows.Forms.Panel IsNew;
        private System.Windows.Forms.Label NewAddressLabel;
        private System.Windows.Forms.RichTextBox NewAddressRichTextBox;
        private System.Windows.Forms.Label PlanDurationLabel;
        private System.Windows.Forms.ComboBox PlanComboBox;
        private System.Windows.Forms.Label OldAddressLabel;
        private System.Windows.Forms.RichTextBox OldAddressRichTextBox;
    }
}