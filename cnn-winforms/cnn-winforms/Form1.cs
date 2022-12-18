using CnnModule.CnnMnist;
using System.Windows.Forms.DataVisualization.Charting;
using Contracts;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;

namespace cnn_winforms
{
    public partial class Form1 : Form
    {
        private readonly CnnMnistTrainer trainer;
        private List<TrainigResult> trainigResults = new List<TrainigResult>();

        public Form1()
        {
            InitializeComponent();
            this.trainer = new CnnMnistTrainer();
        }
        private void StartLearning_Click(object sender, EventArgs e)
        {
            this.trainigResults = this.trainer.Train();
            CreateChart();
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
            startPosition= Point.Empty;
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
                            g.DrawLine(new Pen(Color.Black, 5), startPosition, e.Location);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        }
                        pictureBox1.Invalidate();
                        startPosition = e.Location;
                    }
                }
            } 
            catch (Exception ex)
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

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Canvas is empty!!!\nDraw the image!!!\n");
                } 
                else
                {
                    Bitmap bm = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                    pictureBox1.DrawToBitmap(bm, pictureBox1.ClientRectangle);

                    Image img = (Image)bm;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
