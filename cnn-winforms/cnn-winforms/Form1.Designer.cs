using CnnModule;
using CnnModule.CnnMnist;

namespace cnn_winforms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.lossChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.LearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lossChart)).BeginInit();
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
            this.StartLearning.Location = new System.Drawing.Point(437, 403);
            this.StartLearning.Name = "StartLearning";
            this.StartLearning.Size = new System.Drawing.Size(112, 34);
            this.StartLearning.TabIndex = 0;
            this.StartLearning.Text = "Start learning";
            this.StartLearning.UseVisualStyleBackColor = true;
            this.StartLearning.Click += new System.EventHandler(this.StartLearning_Click);
            // 
            // StopLearning
            // 
            this.StopLearning.Location = new System.Drawing.Point(437, 463);
            this.StopLearning.Name = "StopLearning";
            this.StopLearning.Size = new System.Drawing.Size(112, 34);
            this.StopLearning.TabIndex = 1;
            this.StopLearning.Text = "Stop learning";
            this.StopLearning.UseVisualStyleBackColor = true;
            this.StopLearning.Click += new System.EventHandler(this.StopLearning_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(437, 518);
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
            this.LearningRate.Location = new System.Drawing.Point(175, 411);
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
            this.LearningRate.Size = new System.Drawing.Size(120, 27);
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
            this.label2.Location = new System.Drawing.Point(75, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Learning rate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Batch Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Epochs";
            // 
            // Epochs
            // 
            this.Epochs.Location = new System.Drawing.Point(175, 462);
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
            this.Epochs.Size = new System.Drawing.Size(120, 27);
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
            this.BatchSize.Location = new System.Drawing.Point(175, 512);
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
            this.BatchSize.Size = new System.Drawing.Size(120, 27);
            this.BatchSize.TabIndex = 8;
            this.BatchSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BatchSize.ValueChanged += new System.EventHandler(this.BatchSize_ValueChanged);
            // 
            // lossChart
            // 
            chartArea2.Name = "ChartArea1";
            this.lossChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.lossChart.Legends.Add(legend2);
            this.lossChart.Location = new System.Drawing.Point(12, 12);
            this.lossChart.Name = "lossChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.lossChart.Series.Add(series2);
            this.lossChart.Size = new System.Drawing.Size(600, 375);
            this.lossChart.TabIndex = 9;
            this.lossChart.Text = "lossChart";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1021, 599);
            this.Controls.Add(this.lossChart);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lossChart)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart lossChart;
    }
}