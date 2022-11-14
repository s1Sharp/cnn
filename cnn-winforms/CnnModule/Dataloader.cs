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
            throw new NotImplementedException();
        }

        public bool IsDataAvailable()
        {
            throw new NotImplementedException();
        }

        public bool Restart()
        {
            throw new NotImplementedException();
        }
    }
}
