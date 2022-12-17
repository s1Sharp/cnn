using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TorchSharp.torch;

namespace CnnModule
{
    public interface IDatasetReader
    {
        public Tuple<Tensor, Tensor> GetDataBatch(uint batchSize);
        public bool IsDataAvailable();
        public bool Restart();
    }
}
