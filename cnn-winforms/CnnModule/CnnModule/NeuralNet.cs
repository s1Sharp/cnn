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
        public CELoss loss_f = new CELoss();
        public List<ILayer> layerSequence = new List<ILayer>();
        public double learning_rate = 0.0;
        public uint epoch_num = 5;

        public NeuralNet(List<Size> in_shape, List<Size> hid_shape, List<Size> out_shape,
            IDatasetReader dataloader, double learning_rate, uint epoch_num)
        {
            // init layer seq
            layerSequence.Add(new Linear(784, 10));
            //layerSequence.Add(new Relu(128));
        }

        public double trainStep(Tensor inData, Tensor targetData)
        {
            var x = inData;
            foreach (var layer in layerSequence)
            {
                x = layer.forward(inData);
            }
            double error = loss_f.forward_double(x, targetData);
            var loss_f_grad = loss_f.backward(x, targetData);
            foreach (var layer in layerSequence)
            {
                x = layer.backward(inData);
            }
            return 0.0;
        }

        public double trainLoop()
        {

            return 0.0;
        }

        public double train()
        {
            double time = 0.0;

            throw new NotImplementedException();
        }
    }
}
