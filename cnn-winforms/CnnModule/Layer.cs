using Tensorflow.Operations.Activation;

namespace CnnModule
{
    public class Layer: linear
    {
        public Layer() { }

        public string HelloWorld()
        {
            return "Hello, i`m Linear";
        }
    }
}