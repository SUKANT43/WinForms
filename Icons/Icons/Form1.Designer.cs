namespace Icons
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
            this.cloudDownloadCircleIcon1 = new Icons.CloudDownloadCircleIcon();
            this.instaLogoControl1 = new Icons.InstaLogoControl();
            this.rssIconControl1 = new Icons.RssIconControl();
            this.SuspendLayout();
            // 
            // cloudDownloadCircleIcon1
            // 
            this.cloudDownloadCircleIcon1.BackColor = System.Drawing.Color.Black;
            this.cloudDownloadCircleIcon1.Location = new System.Drawing.Point(81, 213);
            this.cloudDownloadCircleIcon1.Name = "cloudDownloadCircleIcon1";
            this.cloudDownloadCircleIcon1.Size = new System.Drawing.Size(85, 83);
            this.cloudDownloadCircleIcon1.TabIndex = 0;
            // 
            // instaLogoControl1
            // 
            this.instaLogoControl1.Location = new System.Drawing.Point(575, 40);
            this.instaLogoControl1.Name = "instaLogoControl1";
            this.instaLogoControl1.Size = new System.Drawing.Size(145, 147);
            this.instaLogoControl1.TabIndex = 1;
            // 
            // rssIconControl1
            // 
            this.rssIconControl1.BackColor = System.Drawing.Color.LimeGreen;
            this.rssIconControl1.Location = new System.Drawing.Point(396, 265);
            this.rssIconControl1.Name = "rssIconControl1";
            this.rssIconControl1.Size = new System.Drawing.Size(144, 102);
            this.rssIconControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rssIconControl1);
            this.Controls.Add(this.instaLogoControl1);
            this.Controls.Add(this.cloudDownloadCircleIcon1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CloudDownloadCircleIcon cloudDownloadCircleIcon1;
        private InstaLogoControl instaLogoControl1;
        private RssIconControl rssIconControl1;
    }
}

