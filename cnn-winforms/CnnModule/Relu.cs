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

        public Relu()
        {
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

        public string Whoami()
        {
            return "Hello, i`m Relu layer";
        }
    }
}
