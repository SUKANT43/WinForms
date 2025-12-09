namespace StickyNotes
{
    partial class MainForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.addLabel = new System.Windows.Forms.Label();
            this.stickyNotesLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.selectAllCheckBox);
            this.topPanel.Controls.Add(this.addLabel);
            this.topPanel.Controls.Add(this.stickyNotesLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(13, 9, 13, 9);
            this.topPanel.Size = new System.Drawing.Size(429, 68);
            this.topPanel.TabIndex = 0;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAllCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.selectAllCheckBox.Location = new System.Drawing.Point(322, 41);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(82, 21);
            this.selectAllCheckBox.TabIndex = 2;
            this.selectAllCheckBox.Text = "Select all";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBoxClicked);
            // 
            // addLabel
            // 
            this.addLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLabel.AutoSize = true;
            this.addLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.addLabel.Location = new System.Drawing.Point(291, 27);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(36, 37);
            this.addLabel.TabIndex = 1;
            this.addLabel.Text = "+";
            this.addLabel.Click += new System.EventHandler(this.AddLabelClick);
            // 
            // stickyNotesLabel
            // 
            this.stickyNotesLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.stickyNotesLabel.Location = new System.Drawing.Point(156, 9);
            this.stickyNotesLabel.Name = "stickyNotesLabel";
            this.stickyNotesLabel.Size = new System.Drawing.Size(141, 31);
            this.stickyNotesLabel.TabIndex = 0;
            this.stickyNotesLabel.Text = "Sticky Notes";
            this.stickyNotesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoScroll = true;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(0, 68);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(429, 452);
            this.bottomPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 520);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "MainForm";
            this.Text = "Sticky Notes";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label stickyNotesLabel;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Label addLabel;
    }
}
