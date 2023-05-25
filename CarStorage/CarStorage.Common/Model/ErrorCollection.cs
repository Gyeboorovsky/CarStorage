namespace CarStorage.Common.Model;

public class ErrorCollection : List<EntityError>
{
    public ErrorCollection()
    {

    }

    public ErrorCollection(ICollection<EntityError> errors)
    {
        foreach(var error in errors)
        {
            Add(error);
        }
    }

    public void Add(string errorMessage, string propertyName)
    {
        this.Add(errorMessage, EntityErrorType.Standard, propertyName);
    }

    private void Add(string errorMessage, EntityErrorType type, string propertyName)
    {
        this.Add(new EntityError(type, errorMessage, propertyName));
    }

    public string ToString(string delimiter)
    {
        return string.Join(delimiter, this.OrderBy(x => x.ErrorType));
    }
}
