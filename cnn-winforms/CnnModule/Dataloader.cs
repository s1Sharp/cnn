using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;

namespace CnnModule
{
    public class Dataloader : IDatasetReader
    {
        public Tuple<Tensor, Tensor> GetDataBatch(uint batchSize)
        {
            return new Tuple<Tensor, Tensor>(tensor(0), tensor(0));
        }

        public bool IsDataAvailable()
        {
            return false;
        }

        public bool Restart()
        {
            return true;
        }
    }
}
