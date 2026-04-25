namespace IPmcp.App.Exceptions;

public class DatabaseException : Exception
{
    private const string DefaultMessage = "Failed to establish a connection to the database";

    public DatabaseException() : base($"{DefaultMessage}.") { }

    public DatabaseException(Exception? innerException) : base($"{DefaultMessage}.", innerException) { }

    public DatabaseException(string message) : base($"{DefaultMessage} {message}.") { }

    public DatabaseException(string message, Exception? innerException) : base($"{DefaultMessage} {message}.", innerException) { }
}
