namespace CarStorage.Common;

public enum EntityErrorType
{
    Standard = 1
}

public static class EntityErrorTypeExtensions
{
    public static string AsString(this EntityErrorType entityErrorType)
    {
        return entityErrorType switch
        {
            EntityErrorType.Standard => "STANDARD",
            _ => string.Empty
        };
    }
}