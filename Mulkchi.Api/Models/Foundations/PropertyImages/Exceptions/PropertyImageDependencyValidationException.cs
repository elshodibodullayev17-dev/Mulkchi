using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class PropertyImageDependencyValidationException : Xeptions.Xeption
{
    public PropertyImageDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
