using System.Runtime.Serialization;

namespace WPFFileRecovery.Service.Exceptions;

[Serializable]
public class RecoveryModeInvalidException : Exception
{
    public string? RecoveryMode { get; }
    public RecoveryModeInvalidException(string? recoverymode = null)
        => RecoveryMode = recoverymode;
    public RecoveryModeInvalidException(string message, string? recoverymode = null) : base(message)
        => RecoveryMode = recoverymode;
    protected RecoveryModeInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
