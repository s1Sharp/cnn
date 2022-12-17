using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;

namespace CnnModule
{
    public interface ILayer
    {
        public Tensor forward(Tensor input);
        public Tensor backward(Tensor input);
    }
}
