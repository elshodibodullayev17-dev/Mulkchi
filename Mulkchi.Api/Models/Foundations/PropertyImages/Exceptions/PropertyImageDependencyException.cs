using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class PropertyImageDependencyException : Xeptions.Xeption
{
    public PropertyImageDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
