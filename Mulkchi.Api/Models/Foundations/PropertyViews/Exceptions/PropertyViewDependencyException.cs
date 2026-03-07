using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class PropertyViewDependencyException : Xeptions.Xeption
{
    public PropertyViewDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
