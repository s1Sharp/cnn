using CnnModule;

namespace cnn_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Linear l = new Linear();
            MessageBox.Show("Hello World, " + l.Whoami());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
