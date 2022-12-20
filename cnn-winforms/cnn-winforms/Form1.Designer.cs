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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.predictionLabel = new System.Windows.Forms.Label();
            this.digitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lossChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.StartLearning.Location = new System.Drawing.Point(353, 400);
            this.StartLearning.Name = "StartLearning";
            this.StartLearning.Size = new System.Drawing.Size(112, 34);
            this.StartLearning.TabIndex = 0;
            this.StartLearning.Text = "Start learning";
            this.StartLearning.UseVisualStyleBackColor = true;
            this.StartLearning.Click += new System.EventHandler(this.StartLearning_Click);
            // 
            // StopLearning
            // 
            this.StopLearning.Location = new System.Drawing.Point(353, 460);
            this.StopLearning.Name = "StopLearning";
            this.StopLearning.Size = new System.Drawing.Size(112, 34);
            this.StopLearning.TabIndex = 1;
            this.StopLearning.Text = "Stop learning";
            this.StopLearning.UseVisualStyleBackColor = true;
            this.StopLearning.Click += new System.EventHandler(this.StopLearning_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(353, 515);
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
            458752});
            this.LearningRate.Name = "LearningRate";
            this.LearningRate.Size = new System.Drawing.Size(120, 23);
            this.LearningRate.TabIndex = 3;
            this.LearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.LearningRate.ValueChanged += new System.EventHandler(this.LearningRate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Learning rate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Batch Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
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
            this.BatchSize.Location = new System.Drawing.Point(175, 512);
            this.BatchSize.Maximum = new decimal(new int[] {
            128,
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
            64,
            0,
            0,
            0});
            this.BatchSize.ValueChanged += new System.EventHandler(this.BatchSize_ValueChanged);
            // 
            // lossChart
            // 
            this.lossChart.AccessibleDescription = "";
            chartArea1.AxisX.Title = "Iteration number";
            chartArea1.AxisY.Title = "Loss value";
            chartArea1.Name = "ChartArea1";
            this.lossChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.lossChart.Legends.Add(legend1);
            this.lossChart.Location = new System.Drawing.Point(12, 12);
            this.lossChart.Name = "lossChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsXValueIndexed = true;
            series1.LabelForeColor = System.Drawing.Color.BlanchedAlmond;
            series1.Legend = "Legend1";
            series1.Name = "LossValue";
            series1.YValuesPerPoint = 2;
            this.lossChart.Series.Add(series1);
            this.lossChart.Size = new System.Drawing.Size(600, 375);
            this.lossChart.TabIndex = 9;
            this.lossChart.Text = "lossChart";
            title1.BorderWidth = 2;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            title1.Name = "Title1";
            title1.Text = "Loss chart";
            this.lossChart.Titles.Add(title1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Test model";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnTestModelClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "Load model";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLoadModelClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(488, 460);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "Save model";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnSaveModelClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(723, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(723, 209);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(88, 34);
            this.Clear.TabIndex = 12;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(815, 209);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(88, 34);
            this.Confirm.TabIndex = 13;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(949, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(723, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Digit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(723, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Prediction:";
            // 
            // predictionLabel
            // 
            this.predictionLabel.AutoSize = true;
            this.predictionLabel.Location = new System.Drawing.Point(815, 279);
            this.predictionLabel.Name = "predictionLabel";
            this.predictionLabel.Size = new System.Drawing.Size(28, 15);
            this.predictionLabel.TabIndex = 18;
            this.predictionLabel.Text = "0.00";
            // 
            // digitLabel
            // 
            this.digitLabel.AutoSize = true;
            this.digitLabel.Location = new System.Drawing.Point(815, 314);
            this.digitLabel.Name = "digitLabel";
            this.digitLabel.Size = new System.Drawing.Size(36, 15);
            this.digitLabel.TabIndex = 19;
            this.digitLabel.Text = "None";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1021, 599);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.digitLabel);
            this.Controls.Add(this.predictionLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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

        private Button button1;
        private Button button2;
        private Button button3;

        private PictureBox pictureBox1;
        private Button Clear;
        private Button Confirm;
        private PictureBox pictureBox2;
        private Label label6;
        private Label label5;
        private Label predictionLabel;
        private Label digitLabel;

    }
}