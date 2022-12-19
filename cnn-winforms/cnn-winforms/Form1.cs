using CnnModule.CnnMnist;
using System.Windows.Forms.DataVisualization.Charting;
using Contracts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;

namespace cnn_winforms
{
    public partial class Form1 : Form
    {
        private CnnMnistTrainer trainer;
        private List<TrainigResult> trainigResults = new();

        public Form1()
        {
            InitializeComponent();
            var learningRate = (double)this.LearningRate.Value;
            var epochNumber = (int)this.Epochs.Value;
            var batchSize = (int)this.BatchSize.Value;

            var validateResult = ValidateCnnParams(learningRate, epochNumber, batchSize);
            if(validateResult.IsSuccess)
                this.trainer = new CnnMnistTrainer(learningRate, epochNumber, batchSize);
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show( validateResult.ErrorMessage, validateResult.ErrorTitle, buttons);
            }
        }
        private void StartLearning_Click(object sender, EventArgs e)
        {
            var learningRate = (double)this.LearningRate.Value;
            var epochNumber = (int)this.Epochs.Value;
            var batchSize = (int)this.BatchSize.Value;

            var validateResult = ValidateCnnParams(learningRate, epochNumber, batchSize);
            if (validateResult.IsSuccess)
            {
                this.trainer = new CnnMnistTrainer(learningRate, epochNumber, batchSize);
                this.trainigResults = this.trainer.Train();
                CreateChart();
            } else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(validateResult.ErrorMessage, validateResult.ErrorTitle, buttons);
            }
            
        }

        private void StopLearning_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LearningRate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Epochs_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BatchSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CreateChart()
        {
            if (this.trainigResults.Any())
            {
                this.lossChart.Series[0].ChartType = SeriesChartType.Spline;
                this.lossChart.Series[0].Points.DataBindXY(this.trainigResults.Select(x => x.IterationNumber).ToList(), this.trainigResults.Select(x => x.LossValue).ToList());
            }
            else
            {
                string message = "Training results was not found";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                var msgBox = MessageBox.Show(message, caption, buttons);
            }
        }

        private ValidateParamsResult ValidateCnnParams(double learningRate, int epochNumber, int batchSize)
        {
            ValidateParamsResult validateParamsResult = new();
            validateParamsResult.IsSuccess = true;

            if (learningRate < 0.000001)
            {
                validateParamsResult.ErrorMessage += "The value of learning rate is too small. \n";
                validateParamsResult.IsSuccess = false;
            }

            if (learningRate > 0.1)
            {
                validateParamsResult.ErrorMessage += "The value of learning rate is too much. \n";
                validateParamsResult.IsSuccess = false;
            }

            if (epochNumber <= 0)
            {
                validateParamsResult.ErrorMessage += "The number of epoch cannot be less or equal than 0. \n";
                validateParamsResult.IsSuccess = false;
            }

            if (batchSize <= 0)
            {
                validateParamsResult.ErrorMessage += "The size of batches cannot be less or equal than 0. \n";
                validateParamsResult.IsSuccess = false;
            }

            if (!validateParamsResult.IsSuccess)
                validateParamsResult.ErrorTitle = "Validation params error";

            return validateParamsResult;
        }

        private void btnTestModelClick(object sender, EventArgs e)
        {
            this.trainer.Test();
        }

        private void btnSaveModelClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.trainer.Save(fbd.SelectedPath);
                }
            }
        }

        private void btnLoadModelClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.DefaultExt = "bin";
            openFileDialog1.Filter = "bin files (*.bin)|*.bin";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var spath = openFileDialog1.FileName;
                this.trainer.Load(spath);
            }
        }
    }
}
