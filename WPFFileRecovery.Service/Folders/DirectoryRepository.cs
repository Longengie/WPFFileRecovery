using WPFFileRecovery.Data.Models;
using WPFFileRecovery.Service.Exceptions;
using WPFFileRecovery.Service.Folders.Interfaces;

namespace WPFFileRecovery.Service.Folders;

public class DirectoryRepository : IDirectoryRepository
{
    /// <summary>
    /// Get Drive Info from Drive Name
    /// </summary>
    /// <param name="driveName">Drive Name</param>
    /// <returns>Drive Info</returns>
    public DriveInfo? GetDriveInfo(string driveName)
        => DriveInfo.GetDrives().FirstOrDefault(s => s.Name == driveName);
    /// <summary>
    /// Get Recovery Folder from Path
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>List of Recovery Folder</returns>
    public List<RecoveryDirectoryModel> GetRecoveryFolder(string path)
        => GetSubDirectory(path, "Recovery_*")
        .Select(
            s => new RecoveryDirectoryModel()
            {
                DirectoryPath = s
            })
            .ToList();

    /// <summary>
    /// Get Sub-directory from Directory
    /// </summary>
    /// <param name="path">Path</param>
    /// <param name="searchpattern">Search Pattern</param>
    /// <returns>List of directories</returns>
    /// <exception cref="PathNotDirectoryException">Path is not Directory</exception>
    public List<string> GetSubDirectory(string path, string searchpattern = "")
    {
        if (!CheckIsFolder(path))
            throw new PathNotDirectoryException(path);
        if (string.IsNullOrEmpty(searchpattern))
            return Directory.GetDirectories(path).ToList();
        return Directory.GetDirectories(path, searchpattern).ToList();
    }
    /// <summary>
    /// Check Is Valid Folder
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>Is Folder</returns>
    public bool CheckIsFolder(string? path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        if (!Directory.Exists(path))
            return false;
        // get the file attributes for file or directory
        FileAttributes attr = File.GetAttributes(path);
        return attr.HasFlag(FileAttributes.Directory);
    }
}
