using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class PropertyViewDependencyValidationException : Xeptions.Xeption
{
    public PropertyViewDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
