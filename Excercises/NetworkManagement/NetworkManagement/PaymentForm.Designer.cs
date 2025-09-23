namespace NetworkManagement
{
    partial class PaymentForm
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
            this.PaymentPanel = new System.Windows.Forms.Panel();
            this.PaymentDetailsLabel = new System.Windows.Forms.Label();
            this.PaymentMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.UpiRadioButton = new System.Windows.Forms.RadioButton();
            this.NetBankingRadioButton = new System.Windows.Forms.RadioButton();
            this.CardRadioButton = new System.Windows.Forms.RadioButton();
            this.CardPanel = new System.Windows.Forms.Panel();
            this.CardNumberLabel = new System.Windows.Forms.Label();
            this.CardNumberTextBox = new System.Windows.Forms.TextBox();
            this.CvvLabel = new System.Windows.Forms.Label();
            this.NameOnCardTextBox = new System.Windows.Forms.TextBox();
            this.CvvTextBox = new System.Windows.Forms.TextBox();
            this.NameOnCardLabel = new System.Windows.Forms.Label();
            this.NetBankingPanel = new System.Windows.Forms.Panel();
            this.AccountNumberLabel = new System.Windows.Forms.Label();
            this.AccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.IfscLabel = new System.Windows.Forms.Label();
            this.IfscTextBox = new System.Windows.Forms.TextBox();
            this.BranchNameLabel = new System.Windows.Forms.Label();
            this.BranchTextBox = new System.Windows.Forms.TextBox();
            this.UpiPanel = new System.Windows.Forms.Panel();
            this.UpiLabel = new System.Windows.Forms.Label();
            this.UpiIdTextBox = new System.Windows.Forms.TextBox();
            this.PaymentPanel.SuspendLayout();
            this.PaymentMethodGroupBox.SuspendLayout();
            this.CardPanel.SuspendLayout();
            this.NetBankingPanel.SuspendLayout();
            this.UpiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaymentPanel
            // 
            this.PaymentPanel.Controls.Add(this.PaymentDetailsLabel);
            this.PaymentPanel.Controls.Add(this.PaymentMethodGroupBox);
            this.PaymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.PaymentPanel.Location = new System.Drawing.Point(0, 0);
            this.PaymentPanel.Name = "PaymentPanel";
            this.PaymentPanel.Size = new System.Drawing.Size(800, 450);
            this.PaymentPanel.TabIndex = 0;
            // 
            // PaymentDetailsLabel
            // 
            this.PaymentDetailsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.PaymentDetailsLabel.Location = new System.Drawing.Point(47, 23);
            this.PaymentDetailsLabel.Name = "PaymentDetailsLabel";
            this.PaymentDetailsLabel.Size = new System.Drawing.Size(137, 23);
            this.PaymentDetailsLabel.TabIndex = 0;
            this.PaymentDetailsLabel.Text = "Payment Details";
            // 
            // PaymentMethodGroupBox
            // 
            this.PaymentMethodGroupBox.Controls.Add(this.UpiRadioButton);
            this.PaymentMethodGroupBox.Controls.Add(this.NetBankingRadioButton);
            this.PaymentMethodGroupBox.Controls.Add(this.CardRadioButton);
            this.PaymentMethodGroupBox.Location = new System.Drawing.Point(20, 69);
            this.PaymentMethodGroupBox.Name = "PaymentMethodGroupBox";
            this.PaymentMethodGroupBox.Size = new System.Drawing.Size(177, 119);
            this.PaymentMethodGroupBox.TabIndex = 1;
            this.PaymentMethodGroupBox.TabStop = false;
            this.PaymentMethodGroupBox.Text = "Payment Method:";
            // 
            // UpiRadioButton
            // 
            this.UpiRadioButton.Location = new System.Drawing.Point(6, 55);
            this.UpiRadioButton.Name = "UpiRadioButton";
            this.UpiRadioButton.Size = new System.Drawing.Size(104, 24);
            this.UpiRadioButton.TabIndex = 0;
            this.UpiRadioButton.Text = "UPI";
            this.UpiRadioButton.CheckedChanged += new System.EventHandler(this.UpiRadioButton_CheckedChanged);
            // 
            // NetBankingRadioButton
            // 
            this.NetBankingRadioButton.Location = new System.Drawing.Point(6, 25);
            this.NetBankingRadioButton.Name = "NetBankingRadioButton";
            this.NetBankingRadioButton.Size = new System.Drawing.Size(104, 24);
            this.NetBankingRadioButton.TabIndex = 1;
            this.NetBankingRadioButton.Text = "Net Banking";
            this.NetBankingRadioButton.CheckedChanged += new System.EventHandler(this.NetBankingRadioButton_CheckedChanged);
            // 
            // CardRadioButton
            // 
            this.CardRadioButton.Location = new System.Drawing.Point(6, 85);
            this.CardRadioButton.Name = "CardRadioButton";
            this.CardRadioButton.Size = new System.Drawing.Size(104, 24);
            this.CardRadioButton.TabIndex = 2;
            this.CardRadioButton.Text = "Card";
            this.CardRadioButton.CheckedChanged += new System.EventHandler(this.CardRadioButton_CheckedChanged);
            // 
            // CardPanel
            // 
            this.CardPanel.Controls.Add(this.CardNumberLabel);
            this.CardPanel.Controls.Add(this.CardNumberTextBox);
            this.CardPanel.Controls.Add(this.CvvLabel);
            this.CardPanel.Controls.Add(this.NameOnCardTextBox);
            this.CardPanel.Controls.Add(this.CvvTextBox);
            this.CardPanel.Controls.Add(this.NameOnCardLabel);
            this.CardPanel.Location = new System.Drawing.Point(20, 224);
            this.CardPanel.Name = "CardPanel";
            this.CardPanel.Size = new System.Drawing.Size(275, 121);
            this.CardPanel.TabIndex = 0;
            // 
            // CardNumberLabel
            // 
            this.CardNumberLabel.Location = new System.Drawing.Point(3, 10);
            this.CardNumberLabel.Name = "CardNumberLabel";
            this.CardNumberLabel.Size = new System.Drawing.Size(100, 23);
            this.CardNumberLabel.TabIndex = 0;
            this.CardNumberLabel.Text = "Card Number:";
            // 
            // CardNumberTextBox
            // 
            this.CardNumberTextBox.Location = new System.Drawing.Point(109, 10);
            this.CardNumberTextBox.Name = "CardNumberTextBox";
            this.CardNumberTextBox.Size = new System.Drawing.Size(144, 20);
            this.CardNumberTextBox.TabIndex = 1;
            // 
            // CvvLabel
            // 
            this.CvvLabel.Location = new System.Drawing.Point(3, 42);
            this.CvvLabel.Name = "CvvLabel";
            this.CvvLabel.Size = new System.Drawing.Size(100, 23);
            this.CvvLabel.TabIndex = 2;
            this.CvvLabel.Text = "CVV:";
            // 
            // NameOnCardTextBox
            // 
            this.NameOnCardTextBox.Location = new System.Drawing.Point(109, 77);
            this.NameOnCardTextBox.Name = "NameOnCardTextBox";
            this.NameOnCardTextBox.Size = new System.Drawing.Size(144, 20);
            this.NameOnCardTextBox.TabIndex = 5;
            // 
            // CvvTextBox
            // 
            this.CvvTextBox.Location = new System.Drawing.Point(109, 42);
            this.CvvTextBox.Name = "CvvTextBox";
            this.CvvTextBox.Size = new System.Drawing.Size(144, 20);
            this.CvvTextBox.TabIndex = 3;
            // 
            // NameOnCardLabel
            // 
            this.NameOnCardLabel.Location = new System.Drawing.Point(3, 77);
            this.NameOnCardLabel.Name = "NameOnCardLabel";
            this.NameOnCardLabel.Size = new System.Drawing.Size(100, 23);
            this.NameOnCardLabel.TabIndex = 4;
            this.NameOnCardLabel.Text = "Name on Card:";
            this.NameOnCardLabel.Click += new System.EventHandler(this.NameOnCardLabel_Click);
            // 
            // NetBankingPanel
            // 
            this.NetBankingPanel.Controls.Add(this.AccountNumberLabel);
            this.NetBankingPanel.Controls.Add(this.AccountNumberTextBox);
            this.NetBankingPanel.Controls.Add(this.IfscLabel);
            this.NetBankingPanel.Controls.Add(this.IfscTextBox);
            this.NetBankingPanel.Controls.Add(this.BranchNameLabel);
            this.NetBankingPanel.Controls.Add(this.BranchTextBox);
            this.NetBankingPanel.Location = new System.Drawing.Point(20, 212);
            this.NetBankingPanel.Name = "NetBankingPanel";
            this.NetBankingPanel.Size = new System.Drawing.Size(314, 179);
            this.NetBankingPanel.TabIndex = 2;
            // 
            // AccountNumberLabel
            // 
            this.AccountNumberLabel.Location = new System.Drawing.Point(3, 11);
            this.AccountNumberLabel.Name = "AccountNumberLabel";
            this.AccountNumberLabel.Size = new System.Drawing.Size(107, 23);
            this.AccountNumberLabel.TabIndex = 0;
            this.AccountNumberLabel.Text = "Account Number:";
            // 
            // AccountNumberTextBox
            // 
            this.AccountNumberTextBox.Location = new System.Drawing.Point(116, 11);
            this.AccountNumberTextBox.Name = "AccountNumberTextBox";
            this.AccountNumberTextBox.Size = new System.Drawing.Size(129, 20);
            this.AccountNumberTextBox.TabIndex = 1;
            // 
            // IfscLabel
            // 
            this.IfscLabel.Location = new System.Drawing.Point(3, 46);
            this.IfscLabel.Name = "IfscLabel";
            this.IfscLabel.Size = new System.Drawing.Size(100, 23);
            this.IfscLabel.TabIndex = 0;
            this.IfscLabel.Text = "IFSC Code:";
            // 
            // IfscTextBox
            // 
            this.IfscTextBox.Location = new System.Drawing.Point(116, 43);
            this.IfscTextBox.Name = "IfscTextBox";
            this.IfscTextBox.Size = new System.Drawing.Size(129, 20);
            this.IfscTextBox.TabIndex = 0;
            // 
            // BranchNameLabel
            // 
            this.BranchNameLabel.Location = new System.Drawing.Point(3, 84);
            this.BranchNameLabel.Name = "BranchNameLabel";
            this.BranchNameLabel.Size = new System.Drawing.Size(100, 23);
            this.BranchNameLabel.TabIndex = 0;
            this.BranchNameLabel.Text = "Branch Name:";
            // 
            // BranchTextBox
            // 
            this.BranchTextBox.Location = new System.Drawing.Point(116, 81);
            this.BranchTextBox.Name = "BranchTextBox";
            this.BranchTextBox.Size = new System.Drawing.Size(129, 20);
            this.BranchTextBox.TabIndex = 0;
            // 
            // UpiPanel
            // 
            this.UpiPanel.Controls.Add(this.UpiLabel);
            this.UpiPanel.Controls.Add(this.UpiIdTextBox);
            this.UpiPanel.Location = new System.Drawing.Point(20, 214);
            this.UpiPanel.Name = "UpiPanel";
            this.UpiPanel.Size = new System.Drawing.Size(200, 52);
            this.UpiPanel.TabIndex = 2;
            // 
            // UpiLabel
            // 
            this.UpiLabel.Location = new System.Drawing.Point(3, 17);
            this.UpiLabel.Name = "UpiLabel";
            this.UpiLabel.Size = new System.Drawing.Size(51, 23);
            this.UpiLabel.TabIndex = 0;
            this.UpiLabel.Text = "UPI ID:";
            // 
            // UpiIdTextBox
            // 
            this.UpiIdTextBox.Location = new System.Drawing.Point(60, 14);
            this.UpiIdTextBox.Name = "UpiIdTextBox";
            this.UpiIdTextBox.Size = new System.Drawing.Size(124, 20);
            this.UpiIdTextBox.TabIndex = 0;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PaymentPanel);
            this.Name = "PaymentForm";
            this.Size = new System.Drawing.Size(800, 450);
            this.PaymentPanel.ResumeLayout(false);
            this.PaymentMethodGroupBox.ResumeLayout(false);
            this.CardPanel.ResumeLayout(false);
            this.CardPanel.PerformLayout();
            this.NetBankingPanel.ResumeLayout(false);
            this.NetBankingPanel.PerformLayout();
            this.UpiPanel.ResumeLayout(false);
            this.UpiPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PaymentPanel;
        private System.Windows.Forms.Label PaymentDetailsLabel;
        private System.Windows.Forms.GroupBox PaymentMethodGroupBox;
        private System.Windows.Forms.RadioButton CardRadioButton;
        private System.Windows.Forms.RadioButton UpiRadioButton;
        private System.Windows.Forms.RadioButton NetBankingRadioButton;
        private System.Windows.Forms.Panel UpiPanel;
        private System.Windows.Forms.Label UpiLabel;
        private System.Windows.Forms.TextBox UpiIdTextBox;
        private System.Windows.Forms.Panel NetBankingPanel;
        private System.Windows.Forms.Label AccountNumberLabel;
        private System.Windows.Forms.Label IfscLabel;
        private System.Windows.Forms.Label BranchNameLabel;
        private System.Windows.Forms.TextBox AccountNumberTextBox;
        private System.Windows.Forms.TextBox IfscTextBox;
        private System.Windows.Forms.TextBox BranchTextBox;
        private System.Windows.Forms.Panel CardPanel;
        private System.Windows.Forms.Label CardNumberLabel;
        private System.Windows.Forms.Label CvvLabel;
        private System.Windows.Forms.Label NameOnCardLabel;
        private System.Windows.Forms.TextBox CardNumberTextBox;
        private System.Windows.Forms.TextBox CvvTextBox;
        private System.Windows.Forms.TextBox NameOnCardTextBox;

    }
}