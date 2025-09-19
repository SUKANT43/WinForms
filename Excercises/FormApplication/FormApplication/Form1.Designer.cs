using System.Drawing;

namespace FormApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.RootPanel = new System.Windows.Forms.Panel();
            this.FormOrganizePanel = new System.Windows.Forms.Panel();
            this.InputFiledPanel = new System.Windows.Forms.Panel();
            this.NameInputPanel = new System.Windows.Forms.Panel();
            this.NameLable = new System.Windows.Forms.Label();
            this.NameInputBox = new System.Windows.Forms.TextBox();
            this.DesignationInputPanel = new System.Windows.Forms.Panel();
            this.DesignationLable = new System.Windows.Forms.Label();
            this.DesignationTextInput = new System.Windows.Forms.TextBox();
            this.FeedbackInputPanel = new System.Windows.Forms.Panel();
            this.FeedbackLable = new System.Windows.Forms.Label();
            this.FeedbackTextInput = new System.Windows.Forms.RichTextBox();
            this.SubmitButtonPanel = new System.Windows.Forms.Panel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.FeedBackPanel = new System.Windows.Forms.Panel();
            this.RootPanel.SuspendLayout();
            this.FormOrganizePanel.SuspendLayout();
            this.InputFiledPanel.SuspendLayout();
            this.NameInputPanel.SuspendLayout();
            this.DesignationInputPanel.SuspendLayout();
            this.FeedbackInputPanel.SuspendLayout();
            this.SubmitButtonPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootPanel
            // 
            this.RootPanel.AutoSize = true;
            this.RootPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.RootPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RootPanel.Controls.Add(this.FormOrganizePanel);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Size = new System.Drawing.Size(760, 765);
            this.RootPanel.TabIndex = 0;
            this.RootPanel.Visible = false;
            this.RootPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RootPanel_Paint);
            // 
            // FormOrganizePanel
            // 
            this.FormOrganizePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormOrganizePanel.Controls.Add(this.InputFiledPanel);
            this.FormOrganizePanel.Controls.Add(this.SubmitButtonPanel);
            this.FormOrganizePanel.Controls.Add(this.TitlePanel);
            this.FormOrganizePanel.Location = new System.Drawing.Point(95, 35);
            this.FormOrganizePanel.Name = "FormOrganizePanel";
            this.FormOrganizePanel.Size = new System.Drawing.Size(515, 512);
            this.FormOrganizePanel.TabIndex = 1;
            // 
            // InputFiledPanel
            // 
            this.InputFiledPanel.AutoSize = true;
            this.InputFiledPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.InputFiledPanel.Controls.Add(this.NameInputPanel);
            this.InputFiledPanel.Controls.Add(this.DesignationInputPanel);
            this.InputFiledPanel.Controls.Add(this.FeedbackInputPanel);
            this.InputFiledPanel.Location = new System.Drawing.Point(152, 117);
            this.InputFiledPanel.Name = "InputFiledPanel";
            this.InputFiledPanel.Size = new System.Drawing.Size(224, 309);
            this.InputFiledPanel.TabIndex = 0;
            // 
            // NameInputPanel
            // 
            this.NameInputPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.NameInputPanel.Controls.Add(this.NameLable);
            this.NameInputPanel.Controls.Add(this.NameInputBox);
            this.NameInputPanel.Location = new System.Drawing.Point(0, 51);
            this.NameInputPanel.Name = "NameInputPanel";
            this.NameInputPanel.Size = new System.Drawing.Size(218, 49);
            this.NameInputPanel.TabIndex = 0;
            // 
            // NameLable
            // 
            this.NameLable.Location = new System.Drawing.Point(3, 14);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(43, 20);
            this.NameLable.TabIndex = 0;
            this.NameLable.Text = "Name:";
            // 
            // NameInputBox
            // 
            this.NameInputBox.BackColor = System.Drawing.Color.White;
            this.NameInputBox.Location = new System.Drawing.Point(106, 14);
            this.NameInputBox.Name = "NameInputBox";
            this.NameInputBox.Size = new System.Drawing.Size(100, 20);
            this.NameInputBox.TabIndex = 0;
            this.NameInputBox.TextChanged += new System.EventHandler(this.NameInputBox_TextChanged);
            // 
            // DesignationInputPanel
            // 
            this.DesignationInputPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.DesignationInputPanel.Controls.Add(this.DesignationLable);
            this.DesignationInputPanel.Controls.Add(this.DesignationTextInput);
            this.DesignationInputPanel.Location = new System.Drawing.Point(3, 106);
            this.DesignationInputPanel.Name = "DesignationInputPanel";
            this.DesignationInputPanel.Size = new System.Drawing.Size(218, 49);
            this.DesignationInputPanel.TabIndex = 1;
            // 
            // DesignationLable
            // 
            this.DesignationLable.ForeColor = System.Drawing.Color.Black;
            this.DesignationLable.Location = new System.Drawing.Point(0, 17);
            this.DesignationLable.Name = "DesignationLable";
            this.DesignationLable.Size = new System.Drawing.Size(97, 23);
            this.DesignationLable.TabIndex = 0;
            this.DesignationLable.Text = "Designation:";
            // 
            // DesignationTextInput
            // 
            this.DesignationTextInput.Location = new System.Drawing.Point(103, 17);
            this.DesignationTextInput.Name = "DesignationTextInput";
            this.DesignationTextInput.Size = new System.Drawing.Size(100, 20);
            this.DesignationTextInput.TabIndex = 0;
            this.DesignationTextInput.TextChanged += new System.EventHandler(this.DesignationTextInput_TextChanged);
            // 
            // FeedbackInputPanel
            // 
            this.FeedbackInputPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.FeedbackInputPanel.Controls.Add(this.FeedbackLable);
            this.FeedbackInputPanel.Controls.Add(this.FeedbackTextInput);
            this.FeedbackInputPanel.Location = new System.Drawing.Point(3, 161);
            this.FeedbackInputPanel.Name = "FeedbackInputPanel";
            this.FeedbackInputPanel.Size = new System.Drawing.Size(218, 103);
            this.FeedbackInputPanel.TabIndex = 2;
            // 
            // FeedbackLable
            // 
            this.FeedbackLable.Location = new System.Drawing.Point(-3, 37);
            this.FeedbackLable.Name = "FeedbackLable";
            this.FeedbackLable.Size = new System.Drawing.Size(100, 23);
            this.FeedbackLable.TabIndex = 0;
            this.FeedbackLable.Text = "Feedback:";
            // 
            // FeedbackTextInput
            // 
            this.FeedbackTextInput.Location = new System.Drawing.Point(103, 4);
            this.FeedbackTextInput.Name = "FeedbackTextInput";
            this.FeedbackTextInput.Size = new System.Drawing.Size(100, 96);
            this.FeedbackTextInput.TabIndex = 1;
            this.FeedbackTextInput.Text = "";
            this.FeedbackTextInput.TextChanged += new System.EventHandler(this.FeedbackTextInput_TextChanged);
            // 
            // SubmitButtonPanel
            // 
            this.SubmitButtonPanel.Controls.Add(this.SubmitButton);
            this.SubmitButtonPanel.Location = new System.Drawing.Point(236, 432);
            this.SubmitButtonPanel.Name = "SubmitButtonPanel";
            this.SubmitButtonPanel.Size = new System.Drawing.Size(80, 28);
            this.SubmitButtonPanel.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.SubmitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubmitButton.Location = new System.Drawing.Point(3, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Location = new System.Drawing.Point(218, 83);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(98, 28);
            this.TitlePanel.TabIndex = 2;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(100, 23);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Feedback Form";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FeedBackPanel
            // 
            this.FeedBackPanel.Location = new System.Drawing.Point(0, 0);
            this.FeedBackPanel.Name = "FeedBackPanel";
            this.FeedBackPanel.Size = new System.Drawing.Size(200, 100);
            this.FeedBackPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(760, 765);
            this.Controls.Add(this.RootPanel);
            this.Name = "Form1";
            this.RootPanel.ResumeLayout(false);
            this.FormOrganizePanel.ResumeLayout(false);
            this.FormOrganizePanel.PerformLayout();
            this.InputFiledPanel.ResumeLayout(false);
            this.NameInputPanel.ResumeLayout(false);
            this.NameInputPanel.PerformLayout();
            this.DesignationInputPanel.ResumeLayout(false);
            this.DesignationInputPanel.PerformLayout();
            this.FeedbackInputPanel.ResumeLayout(false);
            this.SubmitButtonPanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FormOrganizePanel;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.Panel FeedBackPanel;
        private System.Windows.Forms.Panel InputFiledPanel;
        private System.Windows.Forms.Panel NameInputPanel;
        private System.Windows.Forms.Panel DesignationInputPanel;
        private System.Windows.Forms.Panel FeedbackInputPanel;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.TextBox NameInputBox;
        private System.Windows.Forms.Label DesignationLable;
        private System.Windows.Forms.TextBox DesignationTextInput;
        private System.Windows.Forms.Label FeedbackLable;
        private System.Windows.Forms.RichTextBox FeedbackTextInput;
        private System.Windows.Forms.Panel SubmitButtonPanel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label TitleLabel;
    }
}
