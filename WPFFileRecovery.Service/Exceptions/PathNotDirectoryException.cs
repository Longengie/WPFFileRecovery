using System.Runtime.Serialization;

namespace WPFFileRecovery.Service.Exceptions;

[Serializable]
public class PathNotDirectoryException : Exception
{
    public string? PathName { get; }
    public PathNotDirectoryException(string? pathName = null)
        => PathName = pathName;
    public PathNotDirectoryException(string message, string? pathName = null) : base(message)
        => PathName = pathName;
    protected PathNotDirectoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
