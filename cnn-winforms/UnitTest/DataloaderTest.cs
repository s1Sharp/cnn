using CnnModule;
using TorchSharp;
using UnitTest.utils;

namespace DataloaderTest
{
    [TestClass]
    public class DataloaderTest
    {
        [TestMethod]
        public void TestConstructorShape1()
        {
            Dataloader dataloader = new Dataloader();
            var a1 = dataloader.Restart();
            var a2 = dataloader.IsDataAvailableTest(2);
            var a3 = dataloader.IsDataAvailableTrain(6004);
            var a4 = dataloader.IsDataAvailable();
            var a5 = dataloader.GetDataBatchTest(2);
            var a6 = dataloader.GetDataBatch(50000);
        } 
    }
}