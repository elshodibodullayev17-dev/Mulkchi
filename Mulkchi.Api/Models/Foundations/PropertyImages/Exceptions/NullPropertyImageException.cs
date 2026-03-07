using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class NullPropertyImageException : Xeptions.Xeption
{
    public NullPropertyImageException(string message)
        : base(message)
    { }
}
