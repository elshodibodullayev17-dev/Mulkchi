using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class PropertyDependencyValidationException : Xeptions.Xeption
{
    public PropertyDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
