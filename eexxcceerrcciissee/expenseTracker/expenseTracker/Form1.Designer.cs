namespace expenseTracker
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amountLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.selectedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pieChartPanel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.filterCategoryLabel = new System.Windows.Forms.Label();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.filterType = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDatTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.piePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.pieChartPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1360, 65);
            this.topPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(636, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(192, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Expense Tracker";
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.cancelButton);
            this.leftPanel.Controls.Add(this.addButton);
            this.leftPanel.Controls.Add(this.descriptionRichTextBox);
            this.leftPanel.Controls.Add(this.descriptionLabel);
            this.leftPanel.Controls.Add(this.amountNumericUpDown);
            this.leftPanel.Controls.Add(this.amountLabel);
            this.leftPanel.Controls.Add(this.categoryComboBox);
            this.leftPanel.Controls.Add(this.categoryLabel);
            this.leftPanel.Controls.Add(this.typeComboBox);
            this.leftPanel.Controls.Add(this.typeLabel);
            this.leftPanel.Controls.Add(this.selectedDateTimePicker);
            this.leftPanel.Controls.Add(this.dateLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPanel.ForeColor = System.Drawing.Color.White;
            this.leftPanel.Location = new System.Drawing.Point(0, 65);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(266, 527);
            this.leftPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cancelButton.Location = new System.Drawing.Point(33, 422);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 30);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Crimson;
            this.addButton.Location = new System.Drawing.Point(167, 422);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(87, 30);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(57, 315);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(185, 67);
            this.descriptionRichTextBox.TabIndex = 9;
            this.descriptionRichTextBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(15, 281);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(105, 20);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description:";
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.Location = new System.Drawing.Point(54, 241);
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(112, 26);
            this.amountNumericUpDown.TabIndex = 7;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(15, 218);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(76, 20);
            this.amountLabel.TabIndex = 6;
            this.amountLabel.Text = "Amount:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(54, 176);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(172, 28);
            this.categoryComboBox.TabIndex = 5;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(15, 153);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(86, 20);
            this.categoryLabel.TabIndex = 4;
            this.categoryLabel.Text = "Category:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(54, 111);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(172, 28);
            this.typeComboBox.TabIndex = 3;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(15, 88);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(52, 20);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "Type:";
            // 
            // selectedDateTimePicker
            // 
            this.selectedDateTimePicker.Location = new System.Drawing.Point(54, 46);
            this.selectedDateTimePicker.Name = "selectedDateTimePicker";
            this.selectedDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.selectedDateTimePicker.TabIndex = 1;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(15, 23);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(53, 20);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date:";
            // 
            // bottomPanel
            // 
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomPanel.Controls.Add(this.dataPanel);
            this.bottomPanel.Controls.Add(this.pieChartPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(266, 65);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1094, 527);
            this.bottomPanel.TabIndex = 3;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.dataGridView);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 363);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(1090, 160);
            this.dataPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1090, 160);
            this.dataGridView.TabIndex = 0;
            // 
            // pieChartPanel
            // 
            this.pieChartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieChartPanel.Controls.Add(this.panel1);
            this.pieChartPanel.Controls.Add(this.piePanel);
            this.pieChartPanel.Controls.Add(this.filterPanel);
            this.pieChartPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pieChartPanel.Location = new System.Drawing.Point(0, 0);
            this.pieChartPanel.Name = "pieChartPanel";
            this.pieChartPanel.Size = new System.Drawing.Size(1090, 363);
            this.pieChartPanel.TabIndex = 0;
            // 
            // filterPanel
            // 
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.filterButton);
            this.filterPanel.Controls.Add(this.clearButton);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Controls.Add(this.filterCategoryComboBox);
            this.filterPanel.Controls.Add(this.filterCategoryLabel);
            this.filterPanel.Controls.Add(this.filterTypeComboBox);
            this.filterPanel.Controls.Add(this.filterType);
            this.filterPanel.Controls.Add(this.endDateTimePicker);
            this.filterPanel.Controls.Add(this.endDateLabel);
            this.filterPanel.Controls.Add(this.startDatTimePicker);
            this.filterPanel.Controls.Add(this.startDateLabel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.filterPanel.ForeColor = System.Drawing.Color.White;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(322, 361);
            this.filterPanel.TabIndex = 0;
            // 
            // filterButton
            // 
            this.filterButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.filterButton.ForeColor = System.Drawing.Color.Transparent;
            this.filterButton.Location = new System.Drawing.Point(214, 322);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 33);
            this.filterButton.TabIndex = 11;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = false;
            this.filterButton.Click += new System.EventHandler(this.FilterButtonClick);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.clearButton.Location = new System.Drawing.Point(20, 321);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 34);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.filterLabel.Location = new System.Drawing.Point(119, 0);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(56, 22);
            this.filterLabel.TabIndex = 10;
            this.filterLabel.Text = "Filter";
            // 
            // filterCategoryComboBox
            // 
            this.filterCategoryComboBox.FormattingEnabled = true;
            this.filterCategoryComboBox.Location = new System.Drawing.Point(66, 274);
            this.filterCategoryComboBox.Name = "filterCategoryComboBox";
            this.filterCategoryComboBox.Size = new System.Drawing.Size(172, 28);
            this.filterCategoryComboBox.TabIndex = 9;
            // 
            // filterCategoryLabel
            // 
            this.filterCategoryLabel.AutoSize = true;
            this.filterCategoryLabel.Location = new System.Drawing.Point(27, 241);
            this.filterCategoryLabel.Name = "filterCategoryLabel";
            this.filterCategoryLabel.Size = new System.Drawing.Size(86, 20);
            this.filterCategoryLabel.TabIndex = 8;
            this.filterCategoryLabel.Text = "Category:";
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Location = new System.Drawing.Point(66, 210);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(172, 28);
            this.filterTypeComboBox.TabIndex = 7;
            // 
            // filterType
            // 
            this.filterType.AutoSize = true;
            this.filterType.Location = new System.Drawing.Point(27, 178);
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(52, 20);
            this.filterType.TabIndex = 6;
            this.filterType.Text = "Type:";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(66, 149);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.endDateTimePicker.TabIndex = 5;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(27, 117);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(90, 20);
            this.endDateLabel.TabIndex = 4;
            this.endDateLabel.Text = "End Date:";
            // 
            // startDatTimePicker
            // 
            this.startDatTimePicker.Location = new System.Drawing.Point(66, 76);
            this.startDatTimePicker.Name = "startDatTimePicker";
            this.startDatTimePicker.Size = new System.Drawing.Size(200, 26);
            this.startDatTimePicker.TabIndex = 3;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(27, 43);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(98, 20);
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "Start Date:";
            // 
            // piePanel
            // 
            this.piePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.piePanel.Location = new System.Drawing.Point(625, 0);
            this.piePanel.Name = "piePanel";
            this.piePanel.Size = new System.Drawing.Size(463, 361);
            this.piePanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(322, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 361);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1360, 592);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.pieChartPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.DateTimePicker selectedDateTimePicker;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.NumericUpDown amountNumericUpDown;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel pieChartPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.ComboBox filterCategoryComboBox;
        private System.Windows.Forms.Label filterCategoryLabel;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.Label filterType;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker startDatTimePicker;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel piePanel;
        private System.Windows.Forms.Panel panel1;
    }
}

