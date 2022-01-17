using WPFFileRecovery.Data.Models;

namespace WPFFileRecovery.Test.Data.TestModel
{
    internal static class TestModelGenerate
    {
        internal static WinfrCommandModel CompleteTestModel()
            => new()
            {
                Source = @"E:\Project",
                Destination = @"D:\Recor"
            };
        internal static WinfrCommandModel MissingSourceTestModel()
            => new()
            {
                Source = string.Empty,
                Destination = @"D:\Recor"
            };
        internal static WinfrCommandModel MissingDestinationTestModel()
            => new()
            {
                Source = @"E:\Project",
                Destination = string.Empty
            };
    }
}
