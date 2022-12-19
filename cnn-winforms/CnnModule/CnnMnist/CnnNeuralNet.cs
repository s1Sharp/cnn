using System.Diagnostics;
using static TorchSharp.torch;
using static TorchSharp.torch.nn;
using static TorchSharp.torch.utils.data;
using TorchSharp;
using Contracts;

namespace CnnModule.CnnMnist
{
    public class Model : Module<Tensor, Tensor>
    {
        private Module<Tensor, Tensor> conv1 = Conv2d(1, 32, 3);
        private Module<Tensor, Tensor> conv2 = Conv2d(32, 64, 3);
        private Module<Tensor, Tensor> fc1 = Linear(9216, 128);
        private Module<Tensor, Tensor> fc2 = Linear(128, 10);

        // These don't have any parameters, so the only reason to instantiate
        // them is performance, since they will be used over and over.
        private Module<Tensor, Tensor> pool1 = MaxPool2d(kernelSize: new long[] { 2, 2 });

        private Module<Tensor, Tensor> relu1 = ReLU();
        private Module<Tensor, Tensor> relu2 = ReLU();
        private Module<Tensor, Tensor> relu3 = ReLU();

        private Module<Tensor, Tensor> dropout1 = Dropout(0.25);
        private Module<Tensor, Tensor> dropout2 = Dropout(0.5);

        private Module<Tensor, Tensor> flatten = Flatten();
        private Module<Tensor, Tensor> logsm = LogSoftmax(1);

        public Model(string name) : base(name)
        {
            RegisterComponents();
        }
        public Model(string name, Device device) : base(name)
        {
            RegisterComponents();
        }

        public override Tensor forward(Tensor input)
        {
            var l11 = conv1.forward(input);
            var l12 = relu1.forward(l11);

            var l21 = conv2.forward(l12);
            var l22 = relu2.forward(l21);
            var l23 = pool1.forward(l22);
            var l24 = dropout1.forward(l23);

            var x = flatten.forward(l24);

            var l31 = fc1.forward(x);
            var l32 = relu3.forward(l31);
            var l33 = dropout2.forward(l32);

            var l41 = fc2.forward(l33);

            return logsm.forward(l41);
        }
    }

    public class CnnNeuralNet
    {
        private static int _epochs = 5;
        private static int iterationNumber = 0;
        private static List<TrainigResult> traingnResults = new List<TrainigResult>();
        private readonly double _learningRate;

        private readonly static int _logInterval = 100;

        public CnnNeuralNet(Model model, CnnDataloader dataloader, Device device, int epochNumber, double learningRate)
        {
            _epochs = epochNumber;
            _learningRate = learningRate;
        }

        public List<TrainigResult> TrainingLoop(string dataset, Device device, Model model, CnnDataloader dataloader)
        {
            List<TrainigResult> result = new List<TrainigResult>();

            using var train = dataloader.trainLoader;
            using var test = dataloader.testLoader;

            var optimizer = optim.Adam(model.parameters(), lr: _learningRate);

            var scheduler = optim.lr_scheduler.StepLR(optimizer, 1, 0.85);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (var epoch = 1; epoch <= _epochs; epoch++)
            {

                using (var d = NewDisposeScope())
                {

                    result = Train(model, optimizer, nn.NLLLoss(reduction: Reduction.Mean), train, epoch, dataloader.train_data.Count);
                    Test(model, nn.NLLLoss(reduction: nn.Reduction.Sum), test, dataloader.test_data.Count);

                    Console.WriteLine($"End-of-epoch memory use: {GC.GetTotalMemory(false)}");
                    scheduler.step();
                }
            }

            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalSeconds:F1} s.");

            Console.WriteLine("Saving model to '{0}'", dataset + ".model.bin");
            model.save(dataset + ".model.bin");
            return result;
        }

        private static List<TrainigResult> Train(
            Model model,
            optim.Optimizer optimizer,
            Loss<torch.Tensor, torch.Tensor, torch.Tensor> loss,
            DataLoader dataLoader,
            int epoch,
            long size)
        {

            model.train();

            int batchId = 1;
            long total = 0;

            Console.WriteLine($"Epoch: {epoch}...");

            using (var d = torch.NewDisposeScope())
            {

                foreach (var data in dataLoader)
                {
                    optimizer.zero_grad();

                    var target = data["label"];
                    var prediction = model.forward(data["data"]);
                    var output = loss.forward(prediction, target);

                    output.backward();

                    optimizer.step();

                    total += target.shape[0];

                    if (batchId % _logInterval == 0 || total == size)
                    {
                        iterationNumber++;
                        Console.WriteLine($"\rTrain: epoch {epoch} [{total} / {size}] Loss: {output.ToSingle():F4}");
                        traingnResults.Add(new TrainigResult() { Epoch = epoch, IterationNumber = iterationNumber, LossValue = output.ToDouble() });
                    }

                    batchId++;

                    d.DisposeEverything();
                }
            }
            return traingnResults;
        }

        private static void Test(
            Model model,
            Loss<torch.Tensor, torch.Tensor, torch.Tensor> loss,
            DataLoader dataLoader,
            long size)
        {
            model.eval();

            double testLoss = 0;
            int correct = 0;

            using (var d = torch.NewDisposeScope())
            {

                foreach (var data in dataLoader)
                {
                    var prediction = model.forward(data["data"]);
                    var output = loss.forward(prediction, data["label"]);
                    testLoss += output.ToSingle();

                    var pred = prediction.argmax(1);
                    correct += pred.eq(data["label"]).sum().ToInt32();

                    d.DisposeEverything();
                }
            }

            Console.WriteLine($"Size: {size}, Total: {size}");

            Console.WriteLine($"\rTest set: Average loss {(testLoss / size):F4} | Accuracy {((double)correct / size):P2}");
        }

        public (double, int) Predict(Model model, torch.Tensor tensor)
        {
            model.eval();
            var prediction = model.forward(tensor);
            var idontknow = prediction.argmax(1);
            var val = idontknow[0].sum().ToInt32();
            int digit = (int)val; 
            double accuracy = prediction[0,digit].ToDouble();
            return (accuracy, digit);
        }

    }
}
