using System.Net;

namespace DotnetCV.Exceptions;

public abstract class DotnetCvException : Exception
{
    protected abstract HttpStatusCode StatusCode { get; }
    protected DotnetCvException(string message) : base(message)
    {
    }
}