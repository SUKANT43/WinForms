namespace StickyNotesFull
{
    partial class SubForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubForm));
            this.colorPanel = new System.Windows.Forms.Panel();
            this.validatePanel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.greenLabel = new System.Windows.Forms.Label();
            this.purpleLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.contentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.headerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.validatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorPanel
            // 
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorPanel.Location = new System.Drawing.Point(0, 0);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(484, 29);
            this.colorPanel.TabIndex = 0;
            // 
            // validatePanel
            // 
            this.validatePanel.Controls.Add(this.AddButton);
            this.validatePanel.Controls.Add(this.greenLabel);
            this.validatePanel.Controls.Add(this.purpleLabel);
            this.validatePanel.Controls.Add(this.redLabel);
            this.validatePanel.Controls.Add(this.contentRichTextBox);
            this.validatePanel.Controls.Add(this.contentLabel);
            this.validatePanel.Controls.Add(this.headerRichTextBox);
            this.validatePanel.Controls.Add(this.headerLabel);
            this.validatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validatePanel.Location = new System.Drawing.Point(0, 29);
            this.validatePanel.Name = "validatePanel";
            this.validatePanel.Size = new System.Drawing.Size(484, 382);
            this.validatePanel.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(348, 308);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(98, 37);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // greenLabel
            // 
            this.greenLabel.BackColor = System.Drawing.Color.Green;
            this.greenLabel.Location = new System.Drawing.Point(116, 268);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(26, 23);
            this.greenLabel.TabIndex = 6;
            this.greenLabel.Click += new System.EventHandler(this.GreenLabelClick);
            // 
            // purpleLabel
            // 
            this.purpleLabel.BackColor = System.Drawing.Color.BlueViolet;
            this.purpleLabel.Location = new System.Drawing.Point(84, 268);
            this.purpleLabel.Name = "purpleLabel";
            this.purpleLabel.Size = new System.Drawing.Size(26, 23);
            this.purpleLabel.TabIndex = 5;
            this.purpleLabel.Click += new System.EventHandler(this.PurpleLabelClick);
            // 
            // redLabel
            // 
            this.redLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.redLabel.Location = new System.Drawing.Point(52, 268);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(26, 23);
            this.redLabel.TabIndex = 4;
            this.redLabel.Click += new System.EventHandler(this.RedLabelClick);
            // 
            // ContentRichTextBox
            // 
            this.contentRichTextBox.Location = new System.Drawing.Point(46, 140);
            this.contentRichTextBox.Name = "ContentRichTextBox";
            this.contentRichTextBox.Size = new System.Drawing.Size(400, 98);
            this.contentRichTextBox.TabIndex = 3;
            this.contentRichTextBox.Text = "";
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentLabel.Location = new System.Drawing.Point(10, 113);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(93, 24);
            this.contentLabel.TabIndex = 2;
            this.contentLabel.Text = "Content :";
            // 
            // headerRichTextBox
            // 
            this.headerRichTextBox.Location = new System.Drawing.Point(46, 44);
            this.headerRichTextBox.Name = "headerRichTextBox";
            this.headerRichTextBox.Size = new System.Drawing.Size(400, 48);
            this.headerRichTextBox.TabIndex = 1;
            this.headerRichTextBox.Text = "";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(10, 17);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(87, 24);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header :";
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.validatePanel);
            this.Controls.Add(this.colorPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "SubForm";
            this.Text = "Sticky Notes";
            this.validatePanel.ResumeLayout(false);
            this.validatePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Panel validatePanel;
        private System.Windows.Forms.RichTextBox headerRichTextBox;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.RichTextBox contentRichTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label purpleLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Button AddButton;
    }
}