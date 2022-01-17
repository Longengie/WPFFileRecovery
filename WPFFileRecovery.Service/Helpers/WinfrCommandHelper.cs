using WPFFileRecovery.Data.Models;
using WPFFileRecovery.Service.Exceptions;

namespace WPFFileRecovery.Service.Helpers;

public static class WinfrCommandHelper
{
    public static string[] GenerateWinfrCommand(WinfrCommandModel model)
    {
        List<string> commandList = new();
        commandList.AddRange(GenerateSourceParams(model));
        commandList.AddRange(GenerateRecoveryParams(model));
        commandList.AddRange(GenerateFileModeAcceptParams(model));
        return commandList.ToArray();
    }
    #region Source Destination
    private static List<string> GenerateSourceParams(WinfrCommandModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Source) || !model.SourceIsFolder)
            throw new PathNotDirectoryException(pathName: nameof(model.Source));

        if (string.IsNullOrWhiteSpace(model.Destination) || !model.DestinationIsFolder)
            throw new PathNotDirectoryException(pathName: nameof(model.Destination));

        if (string.IsNullOrWhiteSpace(model.SourceDrive))
            throw new DriveRootNotFoundException(errorDrive: nameof(model.Source));

        return new List<string>()
            {
                $"\"{model.SourceDrive}\"",
                $"\"{model.Destination}\"",
            };
    }
    #endregion
    #region Recovery Params
    private static List<string> GenerateRecoveryParams(WinfrCommandModel model)
    {
        List<string> paramsList = new();
        paramsList.AddRange(GenerateAdvancedOptions(model));
        paramsList.AddRange(GenerateSearchParam(model));
        return paramsList;
    }
    private static List<string> GenerateAdvancedOptions(WinfrCommandModel model)
    {
        List<string> paramsList = new();
        // Extensive Mode
        if (model.IsExtensive)
        {
            paramsList.Add("-extensive");
            // Add advanced options here
            return paramsList;
        }
        if (model.SourceDriveType != "NTFS")
        {
            throw new RecoveryModeInvalidException("regular");
        }
        // The add regular is not neccesary so removed
        return paramsList;
    }
    private static List<string> GenerateSearchParam(WinfrCommandModel model)
    {
        List<string> paramsList = new();

        if (string.IsNullOrEmpty(model.SourceRelative))
            paramsList.Add($"-n \"{ model.SourceRelative}\"");

        if (model.Search != null)
            paramsList.AddRange(model.Search.Select(s => $"-n \"{s}\"").ToList());

        return paramsList;
    }
    #endregion
    #region File Mode Accept
    private static List<string> GenerateFileModeAcceptParams(WinfrCommandModel model)
        => new()
        {
            GenerateFileMode(model.FileMode),
            "-a" // accept all
        };
    private static string GenerateFileMode(string? filemode)
        => filemode switch
        {
            "a" => $"-o:{filemode}", // always overwrite
            "b" => $"-o:{filemode}", // never overwrite
            "n" => $"-o:{filemode}", // keep both
            _ => throw new FileModeInvalidException(filemode ?? "null"),
        };
    #endregion
}
