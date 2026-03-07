using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class PropertyServiceException : Xeptions.Xeption
{
    public PropertyServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
