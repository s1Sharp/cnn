using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;

namespace CnnModule
{
    public class Relu : ILayer
    {
        private Tensor _inputs;
        private double leaky_value = 0.0;

        public Relu(double leaky_value = 0.0)
        {
            if (leaky_value < 0.0)
            {
                throw new ArgumentOutOfRangeException("leaky value should be positive or 0");
            }
            throw new NotImplementedException();
        }
        public Relu()
        {
            throw new NotImplementedException();
        }

        public Tensor forward(Tensor input)
        {
            throw new NotImplementedException();
        }

        public Tensor backward(Tensor input)
        {
            throw new NotImplementedException();
        }

        public string Whoami()
        {
            return "Hello, i`m Relu layer";
        }
    }
}
