using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TorchSharp.torch.utils.data;
using static TorchSharp.torchvision;

namespace CnnModule.CnnMnist
{
    public class CnnDataloader
    {
        public ITransform transform;
        public Dataset train_data;
        public Dataset test_data;

        public DataLoader trainLoader;
        public DataLoader testLoader;

        public CnnDataloader(int train_batch_size = 64, int test_batch_size = 64)
        {
            transform = transforms.Compose(
                                transforms.Normalize(new double[] { 0.1307 }, new double[] { 0.3081 })
                                );
            train_data = datasets.MNIST("DATA_MNIST/", true, download: true, target_transform: transform);
            test_data = datasets.MNIST("DATA_MNIST/", true, download: true, target_transform: transform);
            trainLoader = new DataLoader(train_data, train_batch_size, shuffle: true, num_worker: 4);
            testLoader = new DataLoader(test_data, test_batch_size, shuffle: false, num_worker: 4);
        }
    }
}
