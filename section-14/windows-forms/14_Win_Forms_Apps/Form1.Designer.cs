namespace _14_Win_Forms_Apps
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CounterLabel = new Label();
            IncreaseCounterButton = new Button();
            SuspendLayout();
            // 
            // CounterLabel
            // 
            CounterLabel.AutoSize = true;
            CounterLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            CounterLabel.Location = new Point(169, 84);
            CounterLabel.Name = "CounterLabel";
            CounterLabel.Size = new Size(40, 46);
            CounterLabel.TabIndex = 0;
            CounterLabel.Text = "0";
            CounterLabel.Click += label1_Click;
            // 
            // IncreaseCounterButton
            // 
            IncreaseCounterButton.Location = new Point(308, 97);
            IncreaseCounterButton.Name = "IncreaseCounterButton";
            IncreaseCounterButton.Size = new Size(138, 56);
            IncreaseCounterButton.TabIndex = 1;
            IncreaseCounterButton.Text = "Click me!";
            IncreaseCounterButton.UseVisualStyleBackColor = true;
            IncreaseCounterButton.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(IncreaseCounterButton);
            Controls.Add(CounterLabel);
            Name = "Form1";
            Text = "Windows Form App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CounterLabel;
        private Button IncreaseCounterButton;
    }
}
