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
        public int _input_size = 0;
        public int _output_size = 0;

        public Linear(Size input_size, Size output_size)
        {
            lambda = 0;
            weights = tensor(0);
            bias = tensor(0);
            _inputs = tensor(0);
        }
        public Linear(uint input_size, uint output_size) // Constructor with in and out
        {
            double scale_min = -Math.Sqrt(1.0 / input_size);
            lambda = 0;
            weights = rand(output_size, input_size); // uniform distribution
            weights -= scale_min;
            bias = rand(input_size); // create bias as vector of uniform distribution
            bias -= scale_min;
            _inputs = ones(input_size); // same for _inputs (temporary)
        }

        public Tensor forward(Tensor input) // linear forward function
        {
            this._inputs = input;
            return input.mv(weights) + bias; // return output values by linear activation function
        }

        private void updateW(Tensor d_w)
        {
            return;
        }

        private void updateB(Tensor d_b)
        {
            return;
        }

        public Tensor backward(Tensor input_grad)
        {
            Tensor inplase_grad = input_grad.matmul(this.weights.T);

            Tensor w_grad = (inplase_grad.unsqueeze(-1) * input_grad.unsqueeze(1)).sum(0);
            Tensor b_grad = input_grad.sum(0);

            updateW(w_grad); // should check it
            updateB(b_grad); // should check it
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