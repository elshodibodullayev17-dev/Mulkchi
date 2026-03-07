using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class PropertyViewServiceException : Xeptions.Xeption
{
    public PropertyViewServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
