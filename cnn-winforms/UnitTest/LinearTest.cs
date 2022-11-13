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
                new torch.Size(new[] { 10, 5 })
            );
        }

        [TestMethod]
        public void TestConstructorShape2()
        {
            int Input_size = 10;
            int Output_size = 5;
            Assert.AreEqual(
                new Linear(Input_size, Output_size).Shape(),
                new torch.Size(new[] { 10, 5 })
            );
        }
    }

    [TestClass]
    public class LinearInitData
    {
        private const double dComparePrecision = 0.01;

        [TestMethod]
        public void TestInitWeight()
        {
            int Input_size = 1000;
            int Output_size = 500;
            double expected_max = Math.Sqrt(1.0 / Input_size);
            double expected_min = -Math.Sqrt(1.0 / Input_size);
            double expected_mean = (expected_max + expected_min) / 2.0;

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
            int Input_size = 1000;
            int Output_size = 500;
            double expected_max = Math.Sqrt(1.0 / Input_size);
            double expected_min = -Math.Sqrt(1.0 / Input_size);
            double expected_mean = 0;

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

        [DataTestMethod]
        [DataRow(
            10, 5,
            new[] { 5, 10 }, new[] { 5, 1 }
            )]
        [DataRow(
            1, 1,
            new[] { 1, 1 }, new[] { 1, 1 }
            )]
        [DataRow(
            5, 10,
            new[] { 10, 5 }, new[] { 10, 1 }
            )]
        public void TestInitParamShape(int Input_size, int Output_size,
            torch.Size expected_W_Shape, torch.Size expected_B_Shape)
        {
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
        private const double dComparePrecision = 0.01;

        [DataTestMethod]
        [DataRow(
            10, 5,
            new[] { 5, 10 }, new[] { 5, 1 }
            )]
        [DataRow(
            1, 1,
            new[] { 1, 1 }, new[] { 1, 1 }
            )]
        [DataRow(
            5, 10,
            new[] { 10, 5 }, new[] { 10, 1 }
            )]
        public void TestForward(int Input_size, int Output_size,
            torch.Size expected_W_Shape, torch.Size expected_B_Shape)
        {
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
}