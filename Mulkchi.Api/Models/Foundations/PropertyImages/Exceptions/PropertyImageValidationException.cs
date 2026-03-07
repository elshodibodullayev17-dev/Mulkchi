using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class PropertyImageValidationException : Xeptions.Xeption
{
    public PropertyImageValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
