using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class NullPropertyViewException : Xeptions.Xeption
{
    public NullPropertyViewException(string message)
        : base(message)
    { }
}
