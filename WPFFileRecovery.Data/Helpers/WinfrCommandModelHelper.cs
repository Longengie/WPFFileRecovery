namespace WPFFileRecovery.Data.Helpers
{
    internal static class WinfrCommandModelHelper
    {
        /// <summary>
        /// Check Is Valid Folder
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static bool CheckIsFolder(string? path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            if (!Directory.Exists(path))
                return false;
            try
            {
                // get the file attributes for file or directory
                FileAttributes attr = File.GetAttributes(path);
                return attr.HasFlag(FileAttributes.Directory);
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal static string GetDirectionSourceDrive(string? path)
        {
            if (!CheckIsFolder(path))
                return string.Empty;

            var fullPath = Path.GetFullPath(path ?? "");
            var pathRoot = Path.GetPathRoot(fullPath) ?? string.Empty;

            return string.IsNullOrEmpty(pathRoot) && Path.IsPathFullyQualified(fullPath) ? fullPath : pathRoot;
        }
        /// <summary>
        /// Get Relative Direction
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static string GetRelativeDirection(string? path)
        {
            if (!CheckIsFolder(path))
                return string.Empty;

            List<string> directionSplit;
            try
            {
                var fullPath = Path.GetFullPath(path ?? "");
                directionSplit = fullPath.Split(@"\").ToList();

                if (directionSplit.Count < 1)
                    return string.Empty;

                directionSplit.RemoveAt(0);
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
            return string.Join(@"\", directionSplit);
        }
        internal static string GetDriveType(string? driveName)
        {
            try
            {
                return DriveInfo.GetDrives().FirstOrDefault(s => s.Name == driveName)?.DriveFormat ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
