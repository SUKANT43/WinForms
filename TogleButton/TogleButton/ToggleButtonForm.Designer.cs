namespace TogleButton
{
    partial class ToggleButtonForm
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
            this.toggleButtonControl1 = new TogleButton.ToggleButtonControl();
            this.SuspendLayout();
            // 
            // toggleButtonControl1
            // 
            this.toggleButtonControl1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButtonControl1.IsOn = false;
            this.toggleButtonControl1.Location = new System.Drawing.Point(219, 118);
            this.toggleButtonControl1.Name = "toggleButtonControl1";
            this.toggleButtonControl1.Size = new System.Drawing.Size(513, 181);
            this.toggleButtonControl1.TabIndex = 0;
            // 
            // ToggleButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toggleButtonControl1);
            this.Name = "ToggleButtonForm";
            this.Text = "ToggleButtonForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ToggleButtonControl toggleButtonControl1;
    }
}