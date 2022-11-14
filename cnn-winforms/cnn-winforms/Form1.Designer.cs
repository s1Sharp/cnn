using CnnModule;

namespace cnn_winforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Linear testLayer = new Linear();

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
            this.label1 = new System.Windows.Forms.Label();
            this.StartLearning = new System.Windows.Forms.Button();
            this.StopLearning = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 1;
            // 
            // StartLearning
            // 
            this.StartLearning.Location = new System.Drawing.Point(502, 96);
            this.StartLearning.Name = "StartLearning";
            this.StartLearning.Size = new System.Drawing.Size(112, 34);
            this.StartLearning.TabIndex = 0;
            this.StartLearning.Text = "Start learning";
            this.StartLearning.UseVisualStyleBackColor = true;
            this.StartLearning.Click += new System.EventHandler(this.StartLearning_Click);
            // 
            // StopLearning
            // 
            this.StopLearning.Location = new System.Drawing.Point(502, 188);
            this.StopLearning.Name = "StopLearning";
            this.StopLearning.Size = new System.Drawing.Size(112, 34);
            this.StopLearning.TabIndex = 1;
            this.StopLearning.Text = "Stop learning";
            this.StopLearning.UseVisualStyleBackColor = true;
            this.StopLearning.Click += new System.EventHandler(this.StopLearning_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1021, 599);
            this.Controls.Add(this.StopLearning);
            this.Controls.Add(this.StartLearning);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Button Start;
        private Button StartLearning;
        private Button StopLearning;
    }
}