namespace Pets.Platform.Permissions.EFCore.Utilities;

public interface IDateTimeProvider
{
    DateTime NowUtc { get; }
}

public class DefaultDateTimeProvider : IDateTimeProvider
{
    public DateTime NowUtc => DateTime.UtcNow;
}