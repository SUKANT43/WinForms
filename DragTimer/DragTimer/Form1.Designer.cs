namespace DragTimer
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
            this.minNumeric = new System.Windows.Forms.NumericUpDown();
            this.stepNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxNumeric = new System.Windows.Forms.NumericUpDown();
            this.speedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dragTimerController1 = new DragTimer.DragTimerController();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // minNumeric
            // 
            this.minNumeric.Location = new System.Drawing.Point(279, 114);
            this.minNumeric.Name = "minNumeric";
            this.minNumeric.Size = new System.Drawing.Size(56, 20);
            this.minNumeric.TabIndex = 1;
            // 
            // stepNumeric
            // 
            this.stepNumeric.Location = new System.Drawing.Point(279, 184);
            this.stepNumeric.Name = "stepNumeric";
            this.stepNumeric.Size = new System.Drawing.Size(56, 20);
            this.stepNumeric.TabIndex = 2;
            // 
            // maxNumeric
            // 
            this.maxNumeric.Location = new System.Drawing.Point(279, 149);
            this.maxNumeric.Name = "maxNumeric";
            this.maxNumeric.Size = new System.Drawing.Size(56, 20);
            this.maxNumeric.TabIndex = 3;
            // 
            // speedNumeric
            // 
            this.speedNumeric.Location = new System.Drawing.Point(279, 221);
            this.speedNumeric.Name = "speedNumeric";
            this.speedNumeric.Size = new System.Drawing.Size(56, 20);
            this.speedNumeric.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speed";
            // 
            // dragTimerController1
            // 
            this.dragTimerController1.Location = new System.Drawing.Point(122, 62);
            this.dragTimerController1.Max = 100;
            this.dragTimerController1.Min = 0;
            this.dragTimerController1.Name = "dragTimerController1";
            this.dragTimerController1.Size = new System.Drawing.Size(242, 46);
            this.dragTimerController1.Speed = 10;
            this.dragTimerController1.Step = 5;
            this.dragTimerController1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedNumeric);
            this.Controls.Add(this.maxNumeric);
            this.Controls.Add(this.stepNumeric);
            this.Controls.Add(this.minNumeric);
            this.Controls.Add(this.dragTimerController1);
            this.Name = "Form1";
            this.Text = "Min";
            ((System.ComponentModel.ISupportInitialize)(this.minNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DragTimerController dragTimerController1;
        private System.Windows.Forms.NumericUpDown minNumeric;
        private System.Windows.Forms.NumericUpDown stepNumeric;
        private System.Windows.Forms.NumericUpDown maxNumeric;
        private System.Windows.Forms.NumericUpDown speedNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

