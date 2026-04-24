namespace IPmcp.App.Exceptions;

public class DatabaseException : Exception
{
    public const string DefaultMessage = "Failed to establish a connection to the database.";

    public DatabaseException() : base(DefaultMessage)
    {
    }

    public DatabaseException(string message) : base(message)
    {
    }

    public DatabaseException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}
