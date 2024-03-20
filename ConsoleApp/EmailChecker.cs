class EmailChecker
{
    public static bool IsValid(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            Console.Write("Email address cannot be empty. ");
            return false;
        }

        int atIndex = email.IndexOf('@');
        if (atIndex == -1)
        {
            Console.Write("Email address must contain an '@' symbol. ");
            return false;
        }

        string localPart = email.Substring(0, atIndex);
        string domainPart = email.Substring(atIndex + 1);

        if (string.IsNullOrWhiteSpace(localPart))
        {
            Console.Write("Email address must contain characters before the '@' symbol. ");
            return false;
        }

        if (string.IsNullOrWhiteSpace(domainPart))
        {
            Console.Write("Email address must contain characters after the '@' symbol. ");
            return false;
        }

        int dotIndex = domainPart.IndexOf('.');
        if (dotIndex == -1)
        {
            Console.Write("Email domain must contain a '.' (dot). ");
            return false;
        }

        if (domainPart.EndsWith('.'))
        {
            Console.Write("Email domain cannot end with a '.' (dot). ");
            return false;
        }

        if (dotIndex == 0)
        {
            Console.Write("Email domain must contain characters before the '.' (dot). ");
            return false;
        }

        if (localPart.Length > 64)
        {
            Console.Write("Email local part (before '@') is too long. ");
            return false;
        }

        if (domainPart.Length > 255)
        {
            Console.Write("Email domain part (after '@') is too long. ");
            return false;
        }

        return true;
    }
}