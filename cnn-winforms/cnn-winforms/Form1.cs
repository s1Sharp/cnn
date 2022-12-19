using CnnModule.CnnMnist;
using System.Windows.Forms.DataVisualization.Charting;
using Contracts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using System.Drawing.Imaging;
using TorchSharp;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torchvision;
using SkiaSharp;

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


        // Canvas
        private bool isMouseDown = false;
        Point startPosition = Point.Empty;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPosition = e.Location;
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            startPosition = Point.Empty;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isMouseDown == true)
                {
                    if (startPosition != null)
                    {
                        if (pictureBox1.Image == null)
                        {
                            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            pictureBox1.Image = bmp;
                        }
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.DrawLine(new Pen(Color.White, 5), startPosition, e.Location);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        }
                        pictureBox1.Invalidate();
                        startPosition = e.Location;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                Invalidate();
            }
        }

        //private torch.Tensor = new torch.Tensor();
        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Canvas is empty!!!\nDraw the image!!!\n");
                } else
                {

                    var bitmap = new Bitmap(pictureBox1.Image, new Size(28, 28));
                    var newimage = (Image)(bitmap);
                    var barray = converterImageToByteArray(newimage);
                    pictureBox2.Image = newimage;
                    using (var inputTensor = torch.tensor(GetBytesWithoutAlpha(SKBitmap.Decode(barray))))
                    {
                        Console.WriteLine($"Image shape {inputTensor.ToString()}");
                    }

                    //var inputTensor_ = torch.tensor(GetBytesWithoutAlpha(SKBitmap.Decode(barray)));
                    //// byte[] arr = ImageToByteArray(newimage);
                    ///
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static byte[] GetBytesWithoutAlpha(SKBitmap bitmap)
        {
            var height = bitmap.Height;
            var width = bitmap.Width;

            var inputBytes = bitmap.Bytes;

            if (bitmap.ColorType == SKColorType.Gray8)
                return inputBytes;

            if (bitmap.BytesPerPixel != 4 && bitmap.BytesPerPixel != 1)
                throw new ArgumentException("Conversion only supports grayscale and ARGB");

            var channelLength = height * width;

            var channelCount = 3;

            int inputBlue = 0, inputGreen = 0, inputRed = 0;
            int outputRed = 0, outputGreen = channelLength, outputBlue = channelLength * 2;

            switch (bitmap.ColorType)
            {
                case SKColorType.Bgra8888:
                    inputBlue = 0;
                    inputGreen = 1;
                    inputRed = 2;
                    break;

                default:
                    throw new NotImplementedException($"Conversion from {bitmap.ColorType} to bytes");
            }
            var outBytes = new byte[channelCount * channelLength];

            for (int i = 0, j = 0; i < channelLength; i += 1, j += 4)
            {
                outBytes[outputRed + i] = inputBytes[inputRed + j];
                outBytes[outputGreen + i] = inputBytes[inputGreen + j];
                outBytes[outputBlue + i] = inputBytes[inputBlue + j];
            }

            return outBytes;
        }
        public static byte[] converterImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
