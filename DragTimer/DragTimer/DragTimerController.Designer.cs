namespace DragTimer
{
    partial class DragTimerController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.decreaseLabel = new System.Windows.Forms.Label();
            this.increaseLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.okLabel = new System.Windows.Forms.Label();
            this.showValueTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // decreaseLabel
            // 
            this.decreaseLabel.AutoSize = true;
            this.decreaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.decreaseLabel.Location = new System.Drawing.Point(48, 14);
            this.decreaseLabel.Name = "decreaseLabel";
            this.decreaseLabel.Size = new System.Drawing.Size(23, 31);
            this.decreaseLabel.TabIndex = 1;
            this.decreaseLabel.Text = "-";
            this.decreaseLabel.Click += new System.EventHandler(this.DecreaseLabelClick);
            // 
            // increaseLabel
            // 
            this.increaseLabel.AutoSize = true;
            this.increaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.increaseLabel.Location = new System.Drawing.Point(224, 14);
            this.increaseLabel.Name = "increaseLabel";
            this.increaseLabel.Size = new System.Drawing.Size(30, 31);
            this.increaseLabel.TabIndex = 2;
            this.increaseLabel.Text = "+";
            this.increaseLabel.Click += new System.EventHandler(this.IncreaseLabelClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okLabel);
            this.panel1.Controls.Add(this.showValueTextBox);
            this.panel1.Controls.Add(this.decreaseLabel);
            this.panel1.Controls.Add(this.increaseLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 51);
            this.panel1.TabIndex = 11;
            // 
            // okLabel
            // 
            this.okLabel.AutoSize = true;
            this.okLabel.Location = new System.Drawing.Point(233, 20);
            this.okLabel.Name = "okLabel";
            this.okLabel.Size = new System.Drawing.Size(21, 13);
            this.okLabel.TabIndex = 3;
            this.okLabel.Text = "Ok";
            this.okLabel.Visible = false;
            this.okLabel.Click += new System.EventHandler(this.OkLabelClick);
            // 
            // showValueTextBox
            // 
            this.showValueTextBox.Location = new System.Drawing.Point(77, 14);
            this.showValueTextBox.Name = "showValueTextBox";
            this.showValueTextBox.ReadOnly = true;
            this.showValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.showValueTextBox.Size = new System.Drawing.Size(141, 20);
            this.showValueTextBox.TabIndex = 0;
            // 
            // DragTimerController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DragTimerController";
            this.Size = new System.Drawing.Size(302, 51);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label decreaseLabel;
        private System.Windows.Forms.Label increaseLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox showValueTextBox;
        private System.Windows.Forms.Label okLabel;
    }
}
