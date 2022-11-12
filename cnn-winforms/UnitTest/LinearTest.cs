using CnnModule;
using TorchSharp;

namespace UnitTest
{
    [TestClass]
    public class LinearTest
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
}