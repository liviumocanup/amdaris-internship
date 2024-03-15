public class CustomException : Exception
{
    public string? ParameterName { get; }

    public CustomException() : base() { }

    public CustomException(string message, string? paramName) : base(message)
    {
        ParameterName = paramName;
    }

    public CustomException(string message, string? paramName, Exception inner) : base(message, inner)
    {
        ParameterName = paramName;
    }
}
