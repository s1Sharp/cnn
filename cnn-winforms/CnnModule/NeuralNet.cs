using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;

namespace CnnModule
{
    public class NeuralNet
    {
        public List<ILayer> layerSequence = new List<ILayer>();
        public NeuralNet(List<Size> in_shape, List<Size> hid_shape, List<Size> out_shape)
        {
            // init layer seq
            layerSequence.Add(new Linear());
        }

        public double train()
        {
            double time = 0;
            return time;
        }
    }
}
