using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class PropertyValidationException : Xeptions.Xeption
{
    public PropertyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
