namespace StopWatchC
{
    partial class StopWatchControl
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
            this.timerLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(81, 22);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(99, 26);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "00:00:00.000";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(19, 64);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(96, 33);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(146, 64);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(96, 33);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(84, 103);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(96, 33);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButtonClick);
            // 
            // StopWatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.timerLabel);
            this.Name = "StopWatchControl";
            this.Size = new System.Drawing.Size(258, 161);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resetButton;
    }
}
