namespace ToogleButton
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
            this.toogleButtonControl3 = new ToogleButton.ToogleButtonControl();
            this.toogleButtonControl2 = new ToogleButton.ToogleButtonControl();
            this.toogleButtonControl1 = new ToogleButton.ToogleButtonControl();
            this.SuspendLayout();
            // 
            // toogleButtonControl3
            // 
            this.toogleButtonControl3.Location = new System.Drawing.Point(314, 30);
            this.toogleButtonControl3.Name = "toogleButtonControl3";
            this.toogleButtonControl3.Size = new System.Drawing.Size(125, 41);
            this.toogleButtonControl3.TabIndex = 2;
            this.toogleButtonControl3.Text = "toogleButtonControl3";
            // 
            // toogleButtonControl2
            // 
            this.toogleButtonControl2.Location = new System.Drawing.Point(126, 203);
            this.toogleButtonControl2.Name = "toogleButtonControl2";
            this.toogleButtonControl2.Size = new System.Drawing.Size(388, 76);
            this.toogleButtonControl2.TabIndex = 1;
            this.toogleButtonControl2.Text = "toogleButtonControl2";
            // 
            // toogleButtonControl1
            // 
            this.toogleButtonControl1.Location = new System.Drawing.Point(180, 116);
            this.toogleButtonControl1.Name = "toogleButtonControl1";
            this.toogleButtonControl1.Size = new System.Drawing.Size(318, 81);
            this.toogleButtonControl1.TabIndex = 0;
            this.toogleButtonControl1.Text = "toogleButtonControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toogleButtonControl3);
            this.Controls.Add(this.toogleButtonControl2);
            this.Controls.Add(this.toogleButtonControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ToogleButtonControl toogleButtonControl1;
        private ToogleButtonControl toogleButtonControl2;
        private ToogleButtonControl toogleButtonControl3;
    }
}

