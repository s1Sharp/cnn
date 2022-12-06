using CnnModule;
using Moq;
using UnitTest.utils;
using TorchSharp;

namespace NeuralNetTest
{
    [TestClass]
    public class NeuralNetConstruct
    {
        [TestMethod]
        public void NeuralNetConstructDefault()
        {
            var IDatasetReaderStub = new Mock<IDatasetReader>();
            IDatasetReaderStub
                .Setup(x => x.GetDataBatch(It.IsAny<uint>()))
                .Returns(
                    Tuple.Create(
                        torch.zeros(64, 28, 28, dtype: torch.float32),
                        torch.zeros(64, 10, dtype: torch.float32)
                    )
                );
            torch.Size Input_size = new torch.Size(new[] { 784, 256 });
            torch.Size Hidden_size = new torch.Size(new[] { 256, 128 });
            torch.Size Output_size = new torch.Size(new[] { 128, 10 });
            double learningRate = 0.001;
            uint epochNum = 5;

            var v1 = new torch.Size(IDatasetReaderStub.Object.GetDataBatch(0).Item1.shape);
            var v2 = new torch.Size(new[] { 64, 28, 28 });
            for (int i = 0; i < v1.Length && i < v2.Length; i++)
            {
                Assert.AreEqual(
                    v1[i], v2[i]
                );
            }
            var b1 = new torch.Size(IDatasetReaderStub.Object.GetDataBatch(0).Item2.shape);
            var b2 = new torch.Size(new[] { 64, 10 });
            for (int i = 0; i < b1.Length && i < b2.Length; i++)
            {
                Assert.AreEqual(
                    b1[i], b2[i]
                );
            }

            NeuralNet nn = new NeuralNet(
                new List<torch.Size> { Input_size },
                new List<torch.Size> { Hidden_size},
                new List<torch.Size> { Output_size },
                IDatasetReaderStub.Object, learningRate, epochNum
                );

            Assert.AreEqual(
                nn.learning_rate,
                learningRate
            );
            Assert.AreEqual(
                nn.epoch_num,
                epochNum
            );
        }

        [TestMethod]
        public void NeuralNetConstructLayerLinear()
        {
            var IDatasetReaderStub = new Mock<IDatasetReader>();
            IDatasetReaderStub
                .Setup(x => x.GetDataBatch(It.IsAny<uint>()))
                .Returns(
                    Tuple.Create(
                        torch.zeros(64, 28, 28, dtype: torch.float32),
                        torch.zeros(64, 10, dtype: torch.float32)
                    )
                );
            torch.Size Input_size = new torch.Size(new[] { 784, 256 });
            torch.Size Hidden_size = new torch.Size(new[] { 256, 128 });
            torch.Size Output_size = new torch.Size(new[] { 128, 10 });
            double learningRate = 0.001;
            uint epochNum = 5;

            NeuralNet nn = new NeuralNet(
                new List<torch.Size> { Input_size },
                new List<torch.Size> { Hidden_size },
                new List<torch.Size> { Output_size },
                IDatasetReaderStub.Object, learningRate, epochNum
                );

            Assert.AreEqual(
                (nn.layerSequence[0] as Linear).weights.shape,
                Input_size
            );
            Assert.AreEqual(
                (nn.layerSequence[0] as Linear)._input_size,
                784
            );
            Assert.AreEqual(
                (nn.layerSequence[0] as Linear)._input_size,
                256
            );

        }
    }
}