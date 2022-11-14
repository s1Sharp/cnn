using CnnModule;

namespace cnn_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartLearning_Click(object sender, EventArgs e)
        {
            Linear l = new Linear();
            MessageBox.Show("Start learning, " + l.Whoami());
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
    }
}
