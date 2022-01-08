using System.Net;

namespace DotnetCV.Exceptions;

public class SerializationException : DotnetCvException
{
    public SerializationException(string message) : base(message) 
    {
    }

    protected override HttpStatusCode StatusCode => HttpStatusCode.Moved;
}