namespace CrudWinforms
{
    partial class AnalyticPage
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
            this.analytic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // analytic
            // 
            this.analytic.Location = new System.Drawing.Point(85, 26);
            this.analytic.Name = "analytic";
            this.analytic.Size = new System.Drawing.Size(87, 163);
            this.analytic.TabIndex = 0;
            this.analytic.Text = "analytic";
            this.analytic.UseVisualStyleBackColor = true;
            // 
            // AnalyticPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.analytic);
            this.Name = "AnalyticPage";
            this.Size = new System.Drawing.Size(310, 265);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button analytic;
    }
}
