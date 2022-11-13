using CnnModule;
using TorchSharp;

namespace LinearTest
{
    [TestClass]
    public class LinearConstruct
    {
        [TestMethod]
        public void TestConstructorShape1()
        {
            torch.Size Input_size = new torch.Size(new[] { 10 });
            torch.Size Output_size = new torch.Size(new[] { 5 });
            Assert.AreEqual(
                new Linear(Input_size, Output_size).Shape(),
                new torch.Size(new long[] { 10, 5 })
            );
        }

        [TestMethod]
        public void TestConstructorShape2()
        {
            int Input_size = 10;
            int Output_size = 5;
            Assert.AreEqual(
                new Linear(Input_size, Output_size).Shape(),
                new torch.Size(new long[] { 10, 5 })
            );
        }
    }

    [TestClass]
    public class LinearInitData
    {
        private const double dComparePrecision = 0.001;

        [TestMethod]
        public void TestInitWeight()
        {
            torch.random.manual_seed(0);

            int Input_size = 1000;
            int Output_size = 500;
            double expected_max = Math.Sqrt(1.0 / Input_size);
            double expected_min = -Math.Sqrt(1.0 / Input_size);
            double expected_mean = 0.0;

            var l = new Linear(Input_size, Output_size);

            Assert.IsTrue(
                (double)l.weights.max() <= expected_max
            );

            Assert.IsTrue(
                (double)l.weights.min() >= expected_min
            );

            Assert.AreEqual(
                expected_mean,
                (double)l.weights.mean(),
                dComparePrecision
            );
        }

        [TestMethod]
        public void TestInitBias()
        {
            torch.random.manual_seed(0);

            int Input_size = 1000;
            int Output_size = 500;
            double expected_max = Math.Sqrt(1.0 / Input_size);
            double expected_min = -Math.Sqrt(1.0 / Input_size);
            double expected_mean = 0.0;

            var l = new Linear(Input_size, Output_size);

            Assert.IsTrue(
                (double)l.bias.max() <= expected_max
            );

            Assert.IsTrue(
                (double)l.bias.min() >= expected_min
            );

            Assert.AreEqual(
                expected_mean,
                (double)l.bias.mean(),
                dComparePrecision
            );
        }


        [DataRow(
            10, 5,
            new long[] { 10, 5 }, new long[] { 1, 5 }
            )]
        [DataRow(
            1, 1,
            new long[] { 1, 1 }, new long[] { 1, 1 }
            )]
        [DataRow(
            5, 10,
            new long[] { 5, 10 }, new long[] { 1, 10 }
            )]
        [DataTestMethod]
        public void TestInitParamShape(int Input_size, int Output_size,
            long[] W_Shape, long[] B_Shape)
        {
            torch.Size expected_W_Shape = new torch.Size(W_Shape);
            torch.Size expected_B_Shape = new torch.Size(B_Shape);
            var l = new Linear(Input_size, Output_size);

            Assert.AreEqual(
                expected_W_Shape,
                l.weights.shape
            );

            Assert.AreEqual(
                expected_B_Shape,
                l.bias.shape
            );
        }
    }

    [TestClass]
    public class LinearForward
    {
        private const double dComparePrecision = 0.001;

        [DataRow(
            new long[] { 16, 5 },
            new long[] { 5, 10 },
            new long[] { 1, 10 }
            )]
        [DataRow(
            new long[] { 16, 784 },
            new long[] { 784, 10 },
            new long[] { 1, 10 }
            )]
        [DataTestMethod]
        public void TestForward(
                long[] X_Shape,
                long[] W_Shape,
                long[] B_Shape
            )
        {
            torch.random.manual_seed(0);

            var x = torch.rand(X_Shape);
            var w = torch.rand(W_Shape);
            var b = torch.rand(B_Shape);
            uint Input_size = (uint)W_Shape[0];
            uint Output_size = (uint)W_Shape[1];

            var expected_result = torch.matmul(x, w) + b;

            var l = new Linear(Input_size, Output_size);
            var output = l.forward(x);

            Assert.AreEqual(
                expected_result,
                output
            );

            torch.eq(
                expected_result,
                output
            );
        }
    }
}