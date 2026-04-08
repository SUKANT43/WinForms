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
            this.lineChart1 = new ChartView.LineChart();
            this.chartDataViewer1 = new ChartView.ChartDataViewer();
            this.barChart1 = new ChartView.BarChart();
            this.SuspendLayout();
            // 
            // lineChart1
            // 
            this.lineChart1.Location = new System.Drawing.Point(475, 180);
            this.lineChart1.Name = "lineChart1";
            this.lineChart1.Size = new System.Drawing.Size(332, 239);
            this.lineChart1.TabIndex = 2;
            this.lineChart1.Text = "lineChart1";
            // 
            // chartDataViewer1
            // 
            this.chartDataViewer1.Location = new System.Drawing.Point(273, 51);
            this.chartDataViewer1.Name = "chartDataViewer1";
            this.chartDataViewer1.Size = new System.Drawing.Size(140, 172);
            this.chartDataViewer1.TabIndex = 1;
            this.chartDataViewer1.Text = "chartDataViewer1";
            // 
            // barChart1
            // 
            this.barChart1.Location = new System.Drawing.Point(9, 37);
            this.barChart1.Name = "barChart1";
            this.barChart1.Size = new System.Drawing.Size(181, 172);
            this.barChart1.TabIndex = 0;
            this.barChart1.Text = "barChart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 450);
            this.Controls.Add(this.lineChart1);
            this.Controls.Add(this.chartDataViewer1);
            this.Controls.Add(this.barChart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private BarChart barChart1;
        private ChartDataViewer chartDataViewer1;
        private LineChart lineChart1;
    }
}