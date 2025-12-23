namespace DragTimer
{
    partial class DragTimerController
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.showLabel = new DragTimer.LabelController();
            this.showValueTextBox = new System.Windows.Forms.TextBox();
            this.decreaseLabel = new DragTimer.CustomButton();
            this.increaseLabel = new DragTimer.CustomButton();
            this.okButton = new DragTimer.CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLabel
            // 
            this.showLabel.DisplayFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.showLabel.DisplayText = "0";
            this.showLabel.Location = new System.Drawing.Point(110, 5);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(45, 30);
            this.showLabel.TabIndex = 0;
            this.showLabel.TextColor = System.Drawing.Color.Black;
            // 
            // showValueTextBox
            // 
            this.showValueTextBox.Location = new System.Drawing.Point(125, 8);
            this.showValueTextBox.Name = "showValueTextBox";
            this.showValueTextBox.Size = new System.Drawing.Size(30, 20);
            this.showValueTextBox.TabIndex = 1;
            this.showValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.showValueTextBox.Visible = false;
            // 
            // decreaseLabel
            // 
            this.decreaseLabel.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.decreaseLabel.CornerRadius = 18;
            this.decreaseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decreaseLabel.Location = new System.Drawing.Point(59, 1);
            this.decreaseLabel.Name = "decreaseLabel";
            this.decreaseLabel.Size = new System.Drawing.Size(45, 34);
            this.decreaseLabel.TabIndex = 4;
            this.decreaseLabel.TextColor = System.Drawing.Color.Black;
            this.decreaseLabel.TextSize = 16F;
            this.decreaseLabel.Click += new System.EventHandler(this.DecreaseLabelClick);
            // 
            // increaseLabel
            // 
            this.increaseLabel.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.increaseLabel.CornerRadius = 18;
            this.increaseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.increaseLabel.Location = new System.Drawing.Point(172, 3);
            this.increaseLabel.Name = "increaseLabel";
            this.increaseLabel.Size = new System.Drawing.Size(55, 32);
            this.increaseLabel.TabIndex = 3;
            this.increaseLabel.TextColor = System.Drawing.Color.Black;
            this.increaseLabel.TextSize = 16F;
            this.increaseLabel.Click += new System.EventHandler(this.IncreaseLabelClick);
            // 
            // okButton
            // 
            this.okButton.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.okButton.CornerRadius = 18;
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.Location = new System.Drawing.Point(172, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(55, 34);
            this.okButton.TabIndex = 2;
            this.okButton.TextColor = System.Drawing.Color.Black;
            this.okButton.TextSize = 12F;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.OkbuttonClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.showLabel);
            this.panel1.Controls.Add(this.showValueTextBox);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.increaseLabel);
            this.panel1.Controls.Add(this.decreaseLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(300, 266);
            this.panel1.TabIndex = 0;
            // 
            // DragTimerController
            // 
            this.Controls.Add(this.panel1);
            this.Name = "DragTimerController";
            this.Size = new System.Drawing.Size(300, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private CustomButton decreaseLabel;
        private LabelController showLabel;
        private System.Windows.Forms.TextBox showValueTextBox;
        private CustomButton increaseLabel;
        internal CustomButton okButton;
        private System.Windows.Forms.Panel panel1;
    }
}
