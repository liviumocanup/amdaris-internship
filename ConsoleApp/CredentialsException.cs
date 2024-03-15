public class CredentialsException : Exception
{
    public string? ParameterName { get; }

    public CredentialsException() : base() { }

    public CredentialsException(string message, string? paramName) : base(message)
    {
        ParameterName = paramName;
    }

    public CredentialsException(string message, string? paramName, Exception inner) : base(message, inner)
    {
        ParameterName = paramName;
    }
}
