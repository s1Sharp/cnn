using CnnModule;
using TorchSharp;
using UnitTest.utils;

namespace ReluTest
{
    [TestClass]
    public class ReluConstruct
    {
        [TestMethod]
        public void TestReluConstructDefault()
        {
            new Relu();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "A leaky_value cannot be apply for relu layer.")]
        public void TestReluConstructWithNegativeLeaky()
        {
            new Relu(-0.01);
        }

        [TestMethod]
        public void TestReluConstructWithPositiveLeaky()
        {
            new Relu(0.01);
        }
    }

    [TestClass]
    public class ReluForward
    {
        private const double dComparePrecision = 0.001;

        [DataRow(
            new long[] { 16, 10 }
        )]
        [DataRow(
            new long[] { 1, 10 }
        )]
        [DataTestMethod]
        public void TestReluForward(
                long[] X_Shape
            )
        {
            torch.random.manual_seed(0);

            var x = torch.rand(X_Shape);

            var expected_result = torch.nn.
                functional.relu(x);

            var r = new Relu();
            var output = r.forward(x);

            Assert.AreEqual(
                expected_result,
                output
            );

            for (uint i = 0; i < output.dim(); ++i)
            {
                Assert.AreEqual(
                    expected_result.shape[i],
                    output.shape[i]
                );
            }

            Assert.IsTrue(
                new IsTensorAsFloat(output)
            );

            Assert.AreEqual(
                0.0,
                (double)(expected_result - output).mean(),
                dComparePrecision
            );
        }


        [DataRow(
            new long[] { 16, 10 }
        )]
        [DataRow(
            new long[] { 1, 10 }
        )]
        [DataTestMethod]
        public void TestReluForwardWithPositiveLeaky(
                long[] X_Shape
            )
        {
            const double negative_slope = 0.1;
            var x = torch
                .distributions
                .Uniform(-10.0, 10.0)
                .sample(X_Shape);

            var expected_result = torch.nn
                .functional.leaky_relu(x, negative_slope);

            var l = new Relu(negative_slope);
            var output = l.forward(x);

            Assert.AreEqual(
                expected_result,
                output
            );

            for (uint i = 0; i < output.dim(); ++i)
            {
                Assert.AreEqual(
                    expected_result.shape[i],
                    output.shape[i]
                );
            }

            Assert.IsTrue(
                new IsTensorAsFloat(output)
            );

            Assert.AreEqual(
                0.0,
                (double)(expected_result - output).mean(),
                dComparePrecision
            );
        }
    }
}