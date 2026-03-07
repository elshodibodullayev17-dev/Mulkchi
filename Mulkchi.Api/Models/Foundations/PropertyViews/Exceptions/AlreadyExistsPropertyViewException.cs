using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;

public class AlreadyExistsPropertyViewException : Xeptions.Xeption
{
    public AlreadyExistsPropertyViewException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
