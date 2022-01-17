namespace WPFFileRecovery.Data.Helpers
{
    internal static class RecoveryDirectoryModelHelper
    {
        internal static DateTime? GetDateTime(string? path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;
            try
            {
                return Directory.GetCreationTime(path);
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static bool GetLogFile(string? path)
        {
            if (!WinfrCommandModelHelper.CheckIsFolder(path))
                return false;
            try
            {
                return Directory.GetFiles(path ?? string.Empty, "RecoveryLog.txt").Any();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
