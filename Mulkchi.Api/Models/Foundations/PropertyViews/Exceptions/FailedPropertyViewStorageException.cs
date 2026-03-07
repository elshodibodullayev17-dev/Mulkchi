using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class FailedPropertyViewStorageException : Xeptions.Xeption
{
    public FailedPropertyViewStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
