using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torchvision;



namespace CnnModule
{
    public class Relu : ILayer
    {
        private Tensor _inputs;
        private double leaky_value = 0.0;
        private Tensor input;
        public Relu(double leaky_value = 0.0)
        {
            if (leaky_value < 0.0)
            {
                throw new ArgumentOutOfRangeException("leaky value should be positive or 0");
            }
            this.leaky_value = leaky_value;
        }
        public Relu()
        {
            this.leaky_value = 1;
        }

        
        private Tensor ApplyLRelu(Tensor val)
        {
            return maximum(zeros_like(val), val) + minimum(zeros_like(val), val) * leaky_value;
        }
        public Tensor forward(Tensor input)
        {
            this.input = input.clone();
            var result = input.clone();
            
            result = ApplyLRelu(input);
           
            return result;
        }

        public Tensor backward(Tensor input)
        {
            if (input.shape[0] != this.input.shape[0])
            {
                throw new ArgumentOutOfRangeException("Batches must be same size!");
            }

            Tensor result = input.clone();
            for (int i = 0; i < input.shape[0]; ++i)
            {
                result[i] = this.ComputeGradient(this.input[i], input[i]);
            }

            return result;
        }

        public Tensor ComputeGradient(Tensor linput, Tensor input)
        {
            Tensor d = ones_like(linput);
            d = maximum(zeros_like(linput), linput).logical_and(ones_like(linput)) + 
                minimum(zeros_like(linput), linput).logical_and(ones_like(linput)) * leaky_value;
            return d.multiply(input);
        }

        public string Whoami()
        {
            return "Hello, i`m Relu layer";
        }
    }
}
