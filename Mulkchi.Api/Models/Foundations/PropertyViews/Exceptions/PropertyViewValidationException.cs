using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class PropertyViewValidationException : Xeptions.Xeption
{
    public PropertyViewValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
