namespace CrudWinforms
{
    partial class NavBar
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
            this.curdButton = new System.Windows.Forms.Button();
            this.analyticButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // curdButton
            // 
            this.curdButton.Location = new System.Drawing.Point(13, 52);
            this.curdButton.Name = "curdButton";
            this.curdButton.Size = new System.Drawing.Size(106, 56);
            this.curdButton.TabIndex = 0;
            this.curdButton.Text = "CRUD";
            this.curdButton.UseVisualStyleBackColor = true;
            this.curdButton.Click += new System.EventHandler(this.CrudButtonClick);
            // 
            // analyticButton
            // 
            this.analyticButton.Location = new System.Drawing.Point(13, 144);
            this.analyticButton.Name = "analyticButton";
            this.analyticButton.Size = new System.Drawing.Size(106, 62);
            this.analyticButton.TabIndex = 1;
            this.analyticButton.Text = "Analytic";
            this.analyticButton.UseVisualStyleBackColor = true;
            this.analyticButton.Click += new System.EventHandler(this.AnalyticButtonClick);
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.analyticButton);
            this.Controls.Add(this.curdButton);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(144, 573);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button curdButton;
        private System.Windows.Forms.Button analyticButton;
    }
}
