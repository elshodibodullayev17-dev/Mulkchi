using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class FailedPropertyViewServiceException : Xeptions.Xeption
{
    public FailedPropertyViewServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
