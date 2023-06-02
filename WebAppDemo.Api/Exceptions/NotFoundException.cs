namespace WebAppDemo.Api.Exceptions;

/// <summary>
/// Represents an exception for when a resource is not found.
/// </summary>
/// <param name="message">The message that describes the error.</param>
/// <returns>
/// An instance of NotFoundException.
/// </returns>
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }
}
 