using WPFFileRecovery.Data.Models;
using WPFFileRecovery.Service.Exceptions;

namespace WPFFileRecovery.Service.Folders.Interfaces;
public interface IDirectoryRepository
{
    /// <summary>
    /// Get Drive Info from Drive Name
    /// </summary>
    /// <param name="driveName">Drive Name</param>
    /// <returns>Drive Info</returns>
    public DriveInfo? GetDriveInfo(string driveName);
    /// <summary>
    /// Get Recovery Folder from Path
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>List of Recovery Folder</returns>
    public List<RecoveryDirectoryModel> GetRecoveryFolder(string path);
    /// <summary>
    /// Get Sub-directory from Directory
    /// </summary>
    /// <param name="path">Path</param>
    /// <param name="searchpattern">Search Pattern</param>
    /// <returns>List of directories</returns>
    /// <exception cref="PathNotDirectoryException">Path is not Directory</exception>
    public List<string> GetSubDirectory(string path, string searchpattern = "");
    /// <summary>
    /// Check Is Valid Folder
    /// </summary>
    /// <param name="path">Path</param>
    /// <returns>Is Folder</returns>
    public bool CheckIsFolder(string? path);
}
