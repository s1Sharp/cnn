using static TorchSharp.torch;

namespace CnnModule
{
    public class Linear: ILayer 
    {
        public double lambda;

        public Tensor weights;
        public Tensor bias;

        private Tensor _inputs;
        private int _input_size = 0;
        private int _output_size = 0;

        public Linear(Size input_size, Size output_size) { }
        public Linear(int input_size, int output_size) { }
        public Linear() // create imput arguments, shape for example
        {
            lambda = 0;
            weights = tensor(0);
            bias = tensor(0);
            _inputs = tensor(0);
        }

        public Tensor forward(Tensor input)
        {
            return tensor(0);
        }

        public Tensor backward(Tensor input)
        {
            return tensor(0);
        }

        public string Display()
        {
            return weights.ToString(TorchSharp.TensorStringStyle.Numpy);
        }

        public Size Shape()
        {
            return new Size(new[] { _input_size, _output_size });
        }

        public string Whoami()
        {
            return "Hello, i`m Linear layer, shape=" + '(' + _input_size + ',' + _output_size + ')';
        }
    }
}