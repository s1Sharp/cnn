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
        public double learning_rate = 0.0;
        public uint epoch_num = 5;

        public NeuralNet(List<Size> in_shape, List<Size> hid_shape, List<Size> out_shape,
            IDatasetReader dataloader, double learning_rate, uint epoch_num)
        {
            // init layer seq
            layerSequence.Add(new Linear(784, 10));
        }

        public double train()
        {
            double time = 0.0;
            throw new NotImplementedException();
        }
    }
}
