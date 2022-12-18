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
        public CnnMnistTrainer(double learningRate, int epochNumber, int batchSize)
        {
            // var device = torch.cuda.is_available() ? torch.CUDA : torch.CPU;
            this.device = torch.CPU;
            this.model = new Model("model", device);
            this.dataloader = new CnnDataloader(batchSize, batchSize);
            this.cnnNeuralNet = new CnnNeuralNet(model, dataloader, device, epochNumber, learningRate);
        }

        public List<TrainigResult> Train()
        {
            return cnnNeuralNet.TrainingLoop("mnist", device, model, dataloader);
        }
    }
}
