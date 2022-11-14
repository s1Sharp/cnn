﻿using CnnModule;

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
            this.Exit = new System.Windows.Forms.Button();
            this.LearningRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Epochs = new System.Windows.Forms.NumericUpDown();
            this.BatchSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.LearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchSize)).BeginInit();
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
            this.StartLearning.Location = new System.Drawing.Point(724, 224);
            this.StartLearning.Name = "StartLearning";
            this.StartLearning.Size = new System.Drawing.Size(112, 34);
            this.StartLearning.TabIndex = 0;
            this.StartLearning.Text = "Start learning";
            this.StartLearning.UseVisualStyleBackColor = true;
            this.StartLearning.Click += new System.EventHandler(this.StartLearning_Click);
            // 
            // StopLearning
            // 
            this.StopLearning.Location = new System.Drawing.Point(724, 284);
            this.StopLearning.Name = "StopLearning";
            this.StopLearning.Size = new System.Drawing.Size(112, 34);
            this.StopLearning.TabIndex = 1;
            this.StopLearning.Text = "Stop learning";
            this.StopLearning.UseVisualStyleBackColor = true;
            this.StopLearning.Click += new System.EventHandler(this.StopLearning_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(724, 339);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(112, 34);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // LearningRate
            // 
            this.LearningRate.DecimalPlaces = 6;
            this.LearningRate.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.LearningRate.Location = new System.Drawing.Point(202, 68);
            this.LearningRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LearningRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.LearningRate.Name = "LearningRate";
            this.LearningRate.Size = new System.Drawing.Size(120, 23);
            this.LearningRate.TabIndex = 3;
            this.LearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.LearningRate.ValueChanged += new System.EventHandler(this.LearningRate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Learning rate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Batch Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Epochs";
            // 
            // Epochs
            // 
            this.Epochs.Location = new System.Drawing.Point(202, 119);
            this.Epochs.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Epochs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Epochs.Name = "Epochs";
            this.Epochs.Size = new System.Drawing.Size(120, 23);
            this.Epochs.TabIndex = 7;
            this.Epochs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Epochs.ValueChanged += new System.EventHandler(this.Epochs_ValueChanged);
            // 
            // BatchSize
            // 
            this.BatchSize.Location = new System.Drawing.Point(202, 169);
            this.BatchSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BatchSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BatchSize.Name = "BatchSize";
            this.BatchSize.Size = new System.Drawing.Size(120, 23);
            this.BatchSize.TabIndex = 8;
            this.BatchSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BatchSize.ValueChanged += new System.EventHandler(this.BatchSize_ValueChanged);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1021, 599);
            this.Controls.Add(this.BatchSize);
            this.Controls.Add(this.Epochs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LearningRate);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.StopLearning);
            this.Controls.Add(this.StartLearning);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button Start;
        private Button StartLearning;
        private Button StopLearning;
        private Button Exit;
        private NumericUpDown LearningRate;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown Epochs;
        private NumericUpDown BatchSize;
    }
}