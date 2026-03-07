using Mulkchi.Api.Models.Foundations.Properties;
using Mulkchi.Api.Models.Foundations.Properties.Exceptions;
using Xeptions;

namespace Mulkchi.Api.Services.Foundations.Properties;

public partial class PropertyService
{
    private void ValidatePropertyOnAdd(Property property)
    {
        ValidatePropertyIsNotNull(property);
        Validate(
        (Rule: IsInvalid(property.Id), Parameter: nameof(Property.Id)),
        (Rule: IsInvalid(property.Title), Parameter: nameof(Property.Title)),
        (Rule: IsInvalid(property.Description), Parameter: nameof(Property.Description)),
        (Rule: IsInvalid(property.City), Parameter: nameof(Property.City)),
        (Rule: IsInvalid(property.Address), Parameter: nameof(Property.Address)));
    }

    private void ValidatePropertyOnModify(Property property)
    {
        ValidatePropertyIsNotNull(property);
        Validate(
        (Rule: IsInvalid(property.Id), Parameter: nameof(Property.Id)),
        (Rule: IsInvalid(property.Title), Parameter: nameof(Property.Title)),
        (Rule: IsInvalid(property.Description), Parameter: nameof(Property.Description)),
        (Rule: IsInvalid(property.City), Parameter: nameof(Property.City)),
        (Rule: IsInvalid(property.Address), Parameter: nameof(Property.Address)));
    }

    private static void ValidatePropertyId(Guid propertyId)
    {
        if (propertyId == Guid.Empty)
        {
            throw new InvalidPropertyException(
                message: "Property id is invalid.");
        }
    }

    private static void ValidatePropertyIsNotNull(Property property)
    {
        if (property is null)
            throw new NullPropertyException(message: "Property is null.");
    }

    private static dynamic IsInvalid(Guid id) => new
    {
        Condition = id == Guid.Empty,
        Message = "Id is required."
    };

    private static dynamic IsInvalid(string text) => new
    {
        Condition = string.IsNullOrWhiteSpace(text),
        Message = "Value is required."
    };

    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidPropertyException =
            new InvalidPropertyException(message: "Property data is invalid.");

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
                invalidPropertyException.UpsertDataList(parameter, rule.Message);
        }

        invalidPropertyException.ThrowIfContainsErrors();
    }
}
