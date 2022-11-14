using TorchSharp;
using static TorchSharp.torch;

namespace CnnModule
{
    public class Linear : ILayer
    {
        public double lambda;

        public Tensor weights;
        public Tensor bias;

        private Tensor _inputs;
        private int _input_size = 0;
        private int _output_size = 0;

        public Linear(Size input_size, Size output_size)
        {
            lambda = 0;
            weights = tensor(0);
            bias = tensor(0);
            _inputs = tensor(0);
        }
        public Linear(uint input_size, uint output_size) // Constructor with in and out
        {
            lambda = 0;
            weights = rand(output_size, input_size); // uniform distribution
            bias = ones(input_size); // create bias as vector of ones
            _inputs = ones(input_size); // same for _inputs (temporary)
        }
        public Linear() // create input arguments, shape for example
        {
            lambda = 0;
            weights = tensor(0);
            bias = tensor(0);
            _inputs = tensor(0);
        }

        public Tensor forward(Tensor input) // linear forward function
        {
            return input.mv(weights) + bias; // return output values by linear activation function
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
            return new Size(new long[] { _input_size, _output_size });
        }

        public string Whoami()
        {
            return "Hello, i`m Linear layer, shape=" + '(' + _input_size + ',' + _output_size + ')';
        }
    }
}