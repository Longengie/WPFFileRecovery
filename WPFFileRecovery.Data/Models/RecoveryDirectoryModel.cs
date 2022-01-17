using WPFFileRecovery.Data.Helpers;

namespace WPFFileRecovery.Data.Models
{
    public class RecoveryDirectoryModel
    {
        public string? DirectoryPath { get; set; }
        public DateTime? DirectoryPathDateTime => RecoveryDirectoryModelHelper.GetDateTime(DirectoryPath);
        public bool HaveRecoveryLog => RecoveryDirectoryModelHelper.GetLogFile(DirectoryPath);
    }
}
