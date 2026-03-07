using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Services.Foundations.Properties;

public interface IPropertyService
{
    ValueTask<Property> AddPropertyAsync(Property property);
    IQueryable<Property> RetrieveAllProperties();
    ValueTask<Property> RetrievePropertyByIdAsync(Guid propertyId);
    ValueTask<Property> ModifyPropertyAsync(Property property);
    ValueTask<Property> RemovePropertyByIdAsync(Guid propertyId);
}
