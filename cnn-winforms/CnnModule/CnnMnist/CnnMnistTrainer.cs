using Contracts;
using TorchSharp;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torch;

namespace CnnModule.CnnMnist
{
    public class CnnMnistTrainer
    {
        private readonly Device device;
        private readonly Model model;
        private readonly CnnDataloader dataloader;
        private readonly CnnNeuralNet cnnNeuralNet;
        public CnnMnistTrainer()
        {
            // var device = torch.cuda.is_available() ? torch.CUDA : torch.CPU;
            this.device = torch.CPU;
            this.model = new Model("model", device);
            this.dataloader = new CnnDataloader();
            this.cnnNeuralNet = new CnnNeuralNet(model, dataloader, device);
        }

        public List<TrainigResult> Train()
        {
            return cnnNeuralNet.TrainingLoop("mnist", device, model, dataloader);
        }
    }
}
