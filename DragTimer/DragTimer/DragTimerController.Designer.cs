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
            this.panel1 = new System.Windows.Forms.Panel();
            this.decreaseLabel = new DragTimer.CustomButton();
            this.increaseLabel = new DragTimer.CustomButton();
            this.okButton = new DragTimer.CustomButton();
            this.showLabel = new DragTimer.LabelController();
            this.showValueTextBox = new System.Windows.Forms.TextBox();

            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.BackColor = System.Drawing.Color.Transparent;

            // decreaseLabel (-)
            this.decreaseLabel.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.decreaseLabel.CornerRadius = 18;
            this.decreaseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decreaseLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.decreaseLabel.Size = new System.Drawing.Size(45, 35);
            this.decreaseLabel.Text = "-";
            this.decreaseLabel.TextColor = System.Drawing.Color.Black;
            this.decreaseLabel.TextSize = 16F;
            this.decreaseLabel.Click += new System.EventHandler(this.DecreaseLabelClick);

            // increaseLabel (+)
            this.increaseLabel.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.increaseLabel.CornerRadius = 18;
            this.increaseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.increaseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.increaseLabel.Size = new System.Drawing.Size(45, 35);
            this.increaseLabel.Text = "+";
            this.increaseLabel.TextColor = System.Drawing.Color.Black;
            this.increaseLabel.TextSize = 16F;
            this.increaseLabel.Click += new System.EventHandler(this.IncreaseLabelClick);

            // okButton
            this.okButton.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.okButton.CornerRadius = 18;
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.okButton.Size = new System.Drawing.Size(55, 35);
            this.okButton.Text = "OK";
            this.okButton.TextColor = System.Drawing.Color.Black;
            this.okButton.TextSize = 12F;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.OkbuttonClick);

            // showLabel (display)
            this.showLabel.DisplayFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.showLabel.DisplayText = "0";
            this.showLabel.TextColor = System.Drawing.Color.Black;
            this.showLabel.Dock = System.Windows.Forms.DockStyle.Fill;

            // showValueTextBox (edit)
            this.showValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showValueTextBox.Visible = false;
            this.showValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // add controls (order matters!)
            this.panel1.Controls.Add(this.showLabel);
            this.panel1.Controls.Add(this.showValueTextBox);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.increaseLabel);
            this.panel1.Controls.Add(this.decreaseLabel);

            // DragTimerController
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(300, 50);

            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private CustomButton decreaseLabel;
        private CustomButton increaseLabel;
        internal CustomButton okButton;
        private LabelController showLabel;
        private System.Windows.Forms.TextBox showValueTextBox;
    }
}
