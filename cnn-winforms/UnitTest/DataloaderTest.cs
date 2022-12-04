using CnnModule;
using TorchSharp;
using UnitTest.utils;

namespace DataloaderTest
{
    // set as unused for a while implementing class
    // [TestClass]
    public class DataloaderTest
    {
        private const uint DataBacth_ = 64;
        private const long TrainDataSize_ = 60000;
        private const long TestDataSize_ = 10000;

        [TestMethod]
        public void TestConstructorShape1()
        {
            // remove return for debug

            Dataloader dataloader = new Dataloader(0, true);
            var a1 = dataloader.Restart();
            var a2 = dataloader.IsDataAvailableTest(2);
            var a3 = dataloader.IsDataAvailableTrain(6004);
            var a4 = dataloader.IsDataAvailable();
            var a5 = dataloader.GetDataBatchTest(2);
            var a6 = dataloader.GetDataBatch(50000);
        }

        private void MakeDataloaderDataNotAvailable(ref Dataloader dl)
        {
            while (dl.IsDataAvailable())
            {
                var tmp = dl.GetDataBatch(DataBacth_);
            }
            return;
        }

        private void MakeDataloaderDataNotAvailable(ref IDatasetReader dl)
        {
            while(dl.IsDataAvailable())
            {
                var tmp = dl.GetDataBatch(DataBacth_);
            }
            return;
        }


        [TestMethod]
        public void TestConstructorTrainData()
        {
            /// public Dataloader(bool train=true, bool shuffle = false)
            Dataloader dataloader = new Dataloader(0, true);

            Assert.AreEqual(
                dataloader.shape,
                (long)TrainDataSize_
            );
        }

        [TestMethod]
        public void TestConstructorTestData()
        {
            /// public Dataloader(bool train=true, bool shuffle = false)
            Dataloader dataloader = new Dataloader(false);

            Assert.AreEqual(
                dataloader.shape,
                (long)TestDataSize_
            );
        }


        [TestMethod]
        public void TestDataAvailable()
        {
            IDatasetReader dataloader = new Dataloader(true);

            Assert.IsTrue(
                dataloader.IsDataAvailable()
            );
        }


        [TestMethod]
        public void TestDataNotAvailable()
        {
            IDatasetReader dataloader = new Dataloader(true);
            MakeDataloaderDataNotAvailable(ref dataloader);

            Assert.IsFalse(
                dataloader.IsDataAvailable()
            );
        }


        [TestMethod]
        public void TestRestart()
        {
            IDatasetReader dataloader = new Dataloader(true);
            MakeDataloaderDataNotAvailable(ref dataloader);

            Assert.IsFalse(
                dataloader.IsDataAvailable()
            );

            dataloader.Restart();

            Assert.IsTrue(
                dataloader.IsDataAvailable()
            );
        }


        [TestMethod]
        public void TestNotAvaliableAfterRestart()
        {
            IDatasetReader dataloader = new Dataloader(true);
            MakeDataloaderDataNotAvailable(ref dataloader);

            Assert.IsFalse(
                dataloader.IsDataAvailable()
            );

            dataloader.Restart();

            Assert.IsTrue(
                dataloader.IsDataAvailable()
            );

            MakeDataloaderDataNotAvailable(ref dataloader);

            Assert.IsFalse(
                dataloader.IsDataAvailable()
            );
        }
    }
}