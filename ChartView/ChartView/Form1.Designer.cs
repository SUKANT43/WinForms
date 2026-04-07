namespace ChartView
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
            this.chartDataViewer1 = new ChartView.ChartDataViewer();
            this.barChart1 = new ChartView.BarChart();
            this.SuspendLayout();
            // 
            // chartDataViewer1
            // 
            this.chartDataViewer1.Location = new System.Drawing.Point(497, 181);
            this.chartDataViewer1.Name = "chartDataViewer1";
            this.chartDataViewer1.Size = new System.Drawing.Size(186, 257);
            this.chartDataViewer1.TabIndex = 1;
            this.chartDataViewer1.Text = "chartDataViewer1";
            // 
            // barChart1
            // 
            this.barChart1.Location = new System.Drawing.Point(56, 149);
            this.barChart1.Name = "barChart1";
            this.barChart1.Size = new System.Drawing.Size(410, 289);
            this.barChart1.TabIndex = 0;
            this.barChart1.Text = "barChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartDataViewer1);
            this.Controls.Add(this.barChart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private BarChart barChart1;
        private ChartDataViewer chartDataViewer1;
    }
}