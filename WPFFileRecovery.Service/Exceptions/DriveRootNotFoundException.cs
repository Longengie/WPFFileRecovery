using System.Runtime.Serialization;

namespace WPFFileRecovery.Service.Exceptions;

[Serializable]
public class DriveRootNotFoundException : Exception
{
    public string? ErrorDrive { get; }
    public DriveRootNotFoundException(string? errorDrive = null)
        => ErrorDrive = errorDrive;
    public DriveRootNotFoundException(string message, string? errorDrive = null) : base(message)
        => ErrorDrive = errorDrive;
    protected DriveRootNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
