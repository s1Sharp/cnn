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
            MessageBox.Show("Hello World, " + l.Whoami());
        }

        private void StopLearning_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
