using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorchSharp;

namespace UnitTest.utils
{
    public class IsTensorAsFloat
    {
        private readonly bool _assert;
        public IsTensorAsFloat(torch.Tensor input)
        {
            _assert = (
                torch.float16 == input.dtype ||
                torch.float32 == input.dtype ||
                torch.float64 == input.dtype
            );
        }
        public static implicit operator bool(IsTensorAsFloat v)
        {
            return v._assert;
        }
        public static bool operator true(IsTensorAsFloat v)
        {
            return v._assert;
        }
        public static bool operator false(IsTensorAsFloat v)
        {
            return v._assert;
        }
    }
}
