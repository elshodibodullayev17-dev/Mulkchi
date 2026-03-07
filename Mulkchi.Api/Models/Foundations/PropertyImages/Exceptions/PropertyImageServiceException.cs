using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class PropertyImageServiceException : Xeptions.Xeption
{
    public PropertyImageServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
