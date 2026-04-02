namespace IncrementAndDecrement
{
    partial class Form1
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
            this.incrementAndDecrement1 = new IncrementAndDecrement.Controls.IncrementAndDecrement();
            this.SuspendLayout();
            // 
            // incrementAndDecrement1
            // 
            this.incrementAndDecrement1.CurrentValue = 0;
            this.incrementAndDecrement1.End = 0;
            this.incrementAndDecrement1.Location = new System.Drawing.Point(57, 102);
            this.incrementAndDecrement1.Name = "incrementAndDecrement1";
            this.incrementAndDecrement1.Size = new System.Drawing.Size(264, 51);
            this.incrementAndDecrement1.Start = 0;
            this.incrementAndDecrement1.TabIndex = 0;
            this.incrementAndDecrement1.Text = "incrementAndDecrement1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.incrementAndDecrement1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private IncrementAndDecrement.Controls.IncrementAndDecrement incrementAndDecrement1;
    }
}

