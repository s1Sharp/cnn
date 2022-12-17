using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TorchSharp.torch;

namespace CnnModule
{
    public class CELoss
    {
        public Tensor forward(Tensor input, Tensor target)
        {
            var result = (input.squeeze(-1) - target).pow(2.0).mean();
            return result;
        }

        public double forward_double(Tensor input, Tensor target)
        {
            var result = (double)(input.squeeze(-1) - target).pow(2.0).mean();
            return result;
        }

        public Tensor backward(Tensor output, Tensor target)
        {
            // grad of loss with respect to output of previous layer
            return 2.0 * (output.squeeze() - target).unsqueeze(-1) / output.shape[0];
        }
    }
}
