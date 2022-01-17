using System.Runtime.Serialization;

namespace WPFFileRecovery.Service.Exceptions;

[Serializable]
public class DriveRootIsInvalidException : Exception
{
    public string? PathName { get; }
    public DriveRootIsInvalidException(string? pathName = null)
        => PathName = pathName;
    public DriveRootIsInvalidException(string message, string? pathName = null) : base(message)
        => PathName = pathName;
    protected DriveRootIsInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
