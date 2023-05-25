namespace CarStorage.Common;

public enum BodyType
{
    Coupe= 1,
    Sedan = 2,
    Combi = 3,
    Van = 4,
    Hatchback = 5,
    Cabrio = 6,
    SUV = 7,
    Compact = 8
}

public static class BodyTypeExtensions
{
    public static string AsString(this BodyType bodyType)
    {
        return bodyType switch
        {
            BodyType.Coupe => "Coupe",
            BodyType.Sedan => "Sedan",
            BodyType.Combi => "Combi",
            BodyType.Van => "Van",
            BodyType.Hatchback => "Hatchback",
            BodyType.Cabrio => "Cabrio",
            BodyType.SUV => "SUV",
            BodyType.Compact => "Compact",
            _ => string.Empty
        };
    }
}