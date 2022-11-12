using static TorchSharp.torch;

namespace CnnModule
{
    public class Linear: ILayer 
    {
        public double lambda;

        public Tensor weights;
        public Tensor bias;

        private Tensor _inputs;

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

        public string Whoami()
        {
            return "Hello, i`m Linear layer," + tensor(new[] {1, 2}).ToString(TorchSharp.TensorStringStyle.Numpy);
        }
    }
}