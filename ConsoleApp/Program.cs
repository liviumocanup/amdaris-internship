#define LOG_EXCEPTIONS

class Program
{
    static void Main(string[] args)
    {
        try
        {
            LogIn("admin", "");
        }
        catch (CustomException ex)
        {
            #if LOG_EXCEPTIONS
            Console.WriteLine($"{ex.Message}: {ex.ParameterName}");
            #else
            Console.WriteLine(ex.Message);
            #endif
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void LogIn(string username, string password)
    {
        try
        {
            Console.WriteLine("Log In process started:");
            VerifyCredentials(username, password);
        }
        catch (ArgumentException ex)
            when (ex.ParamName == "password" || ex.ParamName == "username")
        {
            throw new CustomException("Invalid Credentials", ex.ParamName, ex);
        }
        catch (ArgumentException)
        {
            throw;
        }
        finally
        {
            Console.WriteLine("Log In process finalized.");
        }
    }

    static void VerifyCredentials(string username, string password)
    {
        if (username == "admin")
        {
            if (password == "admin")
            {
                Console.WriteLine("Log In successful.");
            }
            else
            {
                throw new ArgumentException("Wrong password.", nameof(password));
            }
        }
        else if (!string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("User not found.", nameof(username));
        }
        else
        {
            throw new ArgumentException("Error in processing.");
        }
    }

}