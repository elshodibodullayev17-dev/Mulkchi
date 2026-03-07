using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class PropertyDependencyException : Xeptions.Xeption
{
    public PropertyDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
