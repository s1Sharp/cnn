using static TorchSharp.torch;
using static TorchSharp.torch.utils.data;
using static TorchSharp.torchvision;

namespace CnnModule
{
    public class Dataloader : IDatasetReader
    {
        long tCount = 0;
        long tCurI = 0;
        long rshape = 0;
        public long picShape
        {
            get 
            {
                return this.rshape;
            }
            set
            {
                this.rshape = value;
            }
        }
        public long Shape
        {
            get {
                return this.tCount;
            }
            set {
                this.tCount = value;
            }
        }
        TorchSharp.torch.Tensor tData;
        TorchSharp.torch.Tensor tLabel;

        public Dataloader(bool train = true, bool shuffle = false)
        {
            var cwd = @"..\..\..";//i do not know 

            var datasetPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var normImage = transforms.Normalize(new double[] { 0.1307 }, new double[] { 0.3081 });
            Dataset tdata = datasets.MNIST(cwd, train: train, download: true, target_transform: normImage);

            tCount = tdata.Count;
            this.picShape = tdata.GetTensor(0)["data"].shape[1];
            var qwe = tdata.GetTensor(0)["data"];
            tData = zeros(tCount, picShape, picShape, dtype: float32);
            tLabel = zeros(tCount, 10, dtype: float32);
            for (int i = 0; i < tCount; i++)
            {
                var tt = tdata.GetTensor(i)["label"];
                tLabel[i, tt.data<Int64>()[0]] = 1;
                tData[i] = tdata.GetTensor(i)["data"][0];
            }
            if (shuffle)
                Restart();
        }
        public Tuple<Tensor, Tensor> GetDataBatch(uint batchSize)
        {
            batchSize = CountDataAvailable(batchSize);
            var bData = zeros(batchSize, picShape, picShape, dtype: float32);
            var bLabel = zeros(batchSize, 10, dtype: float32);
            for (long i = 0; i < batchSize; i++)
            {
                bData[i] = tData[tCurI + i];
                bLabel[i] = tLabel[tCurI + i];
            }
            tCurI += batchSize;
            return Tuple.Create(bData, bLabel);
        }

        public bool IsDataAvailable()
        {

            return tCount > tCurI;
        }

        public bool Restart()
        {
            tCurI = 0;
            var tempData = tData.clone();
            var tempLabel = tLabel.clone();
            var rp = randperm(tCount).data<Int64>();
            for (long i = 0; i < tCount; i++)
            {
                tData[rp[i]] = tempData[rp[i]];
                tLabel[rp[i]] = tempLabel[rp[i]];
            }
            return true;
        }

        public bool IsDataAvailable(uint batchSize = 1)
        {
            return tCount > tCurI + batchSize;
        }

        public uint CountDataAvailable(uint batchSize = 1)
        {
                //not safe c'est la vie
            return Math.Min(Convert.ToUInt32(tCount - tCurI),batchSize);

        }
    }
}
