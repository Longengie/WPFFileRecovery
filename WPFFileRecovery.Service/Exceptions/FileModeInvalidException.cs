using System.Runtime.Serialization;

namespace WPFFileRecovery.Service.Exceptions;

[Serializable]
public class FileModeInvalidException : Exception
{
    public string? FileMode { get; }
    public FileModeInvalidException(string? filemode = null)
        => FileMode = filemode;
    public FileModeInvalidException(string message, string? filemode = null) : base(message)
        => FileMode = filemode;
    protected FileModeInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
