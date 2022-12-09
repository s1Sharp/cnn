using static TorchSharp.torch;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torchvision;

namespace CnnModule
{
    public class Dataloader : IDatasetReader
    {
        long trainCount = 0;
        long testCount = 0;
        long trainCurI = 0;
        long testCurI = 0;
        public long shape
        {
            get 
            {
                return this.shape;
            }
            set
            {
                this.shape = value;
            }
        }
        TorchSharp.torch.Tensor testData;
        TorchSharp.torch.Tensor testLabel;
        TorchSharp.torch.Tensor trainData;
        TorchSharp.torch.Tensor trainLabel;

        public Dataloader(bool train = true, bool shuffle = false)
        {
            throw new NotImplementedException();
        }

        public Dataloader(int DataSet = 0, bool shuffle = false)
        {
            var cwd = @"..\..\..";//i do not know 

            var datasetPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var normImage = transforms.Normalize(new double[] { 0.1307 }, new double[] { 0.3081 });
            Dataset test_data = datasets.MNIST(cwd, train: false, download: true, target_transform: normImage);
            Dataset train_data = datasets.MNIST(cwd, train: true, download: true, target_transform: normImage);

            trainCount = train_data.Count;
            testCount = test_data.Count;
            shape = test_data.GetTensor(0)["data"].shape[1];
            var qwe = test_data.GetTensor(0)["data"];
            testData = zeros(testCount, shape, shape, dtype: float32);
            testLabel = zeros(testCount, 10, dtype: float32);
            for (int i = 0; i < testCount; i++)
            {
                var tt = test_data.GetTensor(i)["label"];
                testLabel[i, tt.data<Int64>()[0]] = 1;
                testData[i] = test_data.GetTensor(i)["data"][0];
            }

            trainData = zeros(trainCount, shape, shape, dtype: float32);
            trainLabel = zeros(trainCount, 10, dtype: float32);
            for (int i = 0; i < trainCount; i++)
            {
                var tt = train_data.GetTensor(i)["label"];
                trainLabel[i, tt.data<Int64>()[0]] = tensor(1);
                trainData[i] = train_data.GetTensor(i)["data"][0];
            }
            if (shuffle)
                Restart();
        }
        public Tuple<Tensor, Tensor> GetDataBatch(uint batchSize)
        {
            var bData = zeros(batchSize, shape, shape, dtype: float32);
            var bLabel = zeros(batchSize, 10, dtype: float32);
            for (long i = 0; i < batchSize; i++)
            {
                bData[i] = trainData[trainCurI + i];
                bLabel[i] = trainLabel[trainCurI + i];
            }
            trainCurI += batchSize;
            return Tuple.Create(bData, bLabel);
        }

        public bool IsDataAvailable()
        {
            return testCount >= testCurI;
        }

        public bool Restart()
        {
            trainCurI = 0;
            RestartTrain();
            return true;
        }


        public bool RestartTest()
        {
            testCurI = 0;
            var tempData = testData.clone();
            var tempLabel = testLabel.clone();
            var rp = randperm(testCount).data<Int64>();
            for (long i = 0; i < testCount; i++)
            {
                testData[rp[i]] = tempData[rp[i]];
                testLabel[rp[i]] = tempLabel[rp[i]];
            }

            return true;
        }


        public bool RestartTrain()
        {
            trainCurI = 0;
            var tempData = trainData.clone();
            var tempLabel = trainLabel.clone();
            var rp = randperm(trainCount).data<Int64>();
            for (long i = 0; i < testCount; i++)
            {
                trainData[rp[i]] = tempData[rp[i]];
                trainLabel[rp[i]] = tempLabel[rp[i]];
            }
            return true;
        }

        public Tuple<Tensor, Tensor> GetDataBatchTest(uint batchSize)
        {
            var bData = zeros(batchSize, shape, shape, dtype: float32);
            var bLabel = zeros(batchSize, 10, dtype: float32);
            for (long i = 0; i < batchSize; i++)
            {
                bData[i] = testData[testCurI + i];
                bLabel[i] = testLabel[testCurI + i];
            }
            testCurI += batchSize;
            return Tuple.Create(bData, bLabel);
        }

        public bool IsDataAvailableTest(uint batchSize = 0)
        {
            return trainCount >= trainCurI + batchSize;
        }

        public bool IsDataAvailableTrain(uint batchSize = 0)
        {
            return trainCount >= trainCurI + batchSize;
        }
    }
}
