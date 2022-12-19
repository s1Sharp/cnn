using Contracts;
using TorchSharp;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torch;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

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

        public void Test()
        {
            Console.WriteLine("Testing started!!");
            CnnNeuralNet.Test(this.model, nn.NLLLoss(reduction: nn.Reduction.Sum), dataloader.testLoader, dataloader.test_data.Count);
            Console.WriteLine("Testing ended!!");
        }

        public void Load(string cwd)
        {
            Console.WriteLine("Loading model!!");
            try
            {
                this.model.load(cwd);
            } 
            catch
            {
                Console.WriteLine("Model was NOT saved!!");
            }

            Console.WriteLine("Model was loaded!!");
        }

        public void Save(string cwd)
        {
            Console.WriteLine("Saving model!!");
            try
            {
                string s = cwd + "\\" + "mnist" + ".model.bin";
                this.model.save(s);
                Console.WriteLine("Model was saved!!");
            }
            catch
            {
                Console.WriteLine("Model was NOT saved!!");
            }
            
        }
        
    }
}
