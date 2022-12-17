using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TorchSharp.torch;
using static TorchSharp.torch.nn;
using static TorchSharp.torch.utils.data;
using TorchSharp;

namespace CnnModule.CnnMnist
{
    public class CnnMnistTrainer
    {
        public CnnMnistTrainer()
        {
            // var device = torch.cuda.is_available() ? torch.CUDA : torch.CPU;
            var device = torch.CPU;
            var model = new Model("model", device);
            var dataloader = new CnnDataloader();

            var CnnNeuralNet = new CnnNeuralNet(model, dataloader, device);
        }
    }
}
