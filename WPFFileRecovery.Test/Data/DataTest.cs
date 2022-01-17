using NUnit.Framework;
using WPFFileRecovery.Data.Models;
using WPFFileRecovery.Test.Data.TestModel;

namespace WPFFileRecovery.Test.Data
{
    [TestFixture]
    public class DataTest
    {
        private WinfrCommandModel _testModel1;
        [SetUp]
        public void Setup()
        {
            _testModel1 = TestModelGenerate.CompleteTestModel();
        }

        [Test]
        public void TestSourceDriveCompleteTestModel()
        {
            string sourceDrive = _testModel1?.SourceDrive;
            if (!string.IsNullOrEmpty(sourceDrive))
                Assert.Pass($"Source Drive Success! Source Drive is {sourceDrive}");
            Assert.Fail($"Source Drive Error!");
        }
        [Test]
        public void TestSourceRelativeCompleteTestModel()
        {
            string sourceRelative = _testModel1?.SourceRelative;
            if (!string.IsNullOrEmpty(sourceRelative))
                Assert.Pass($"Source Relative Success! Source Relative is {sourceRelative}");
            Assert.Fail($"Source Relative Error!");
        }
        [Test]
        public void TestSourceCheckCompleteTestModel()
        {
            bool sourceRelative = _testModel1.SourceIsFolder;
            if (sourceRelative)
                Assert.Pass($"Source Check Success!");
            Assert.Fail($"Source Check Error!");
        }
        [Test]
        public void TestSourceTypeCheckCompleteTestModel()
        {
            string sourceType = _testModel1?.SourceDriveType;
            if (!string.IsNullOrEmpty(sourceType))
                Assert.Pass($"Source Type Success! Source Type is {sourceType}");
            Assert.Fail($"Source Type Error!");
        }
    }
}
