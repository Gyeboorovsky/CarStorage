using System.Text;
using System.Text.Json.Serialization;

namespace CarStorage.Common.Model;

public class EntityError
{
    [JsonIgnore]
    public int Id { get; set; }
    public string ErrorType { get; set; }
    public string? ErrorMessage { get; set; }
    public string? PropertyName { get; set; }

    public EntityError()
    {
        ErrorType = EntityErrorType.Standard.AsString();
    }

    public EntityError(string message)
    {
        ErrorMessage = message;

        ErrorType = EntityErrorType.Standard.AsString();
    }

    public EntityError(EntityErrorType errorType, string errorMessage, string propertyName)
    {
        ErrorType = errorType.AsString();
        ErrorMessage = errorMessage;
        PropertyName = propertyName;
    }

    public override string ToString()
    {
        return $"{PropertyName ?? "UNKNOWN PROPERTY"}: {ErrorMessage ?? String.Empty}";
    }
}
