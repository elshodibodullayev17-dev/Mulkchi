using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Services.Foundations.PropertyViews;

public interface IPropertyViewService
{
    ValueTask<PropertyView> AddPropertyViewAsync(PropertyView propertyView);
    IQueryable<PropertyView> RetrieveAllPropertyViews();
    ValueTask<PropertyView> RetrievePropertyViewByIdAsync(Guid propertyViewId);
    ValueTask<PropertyView> ModifyPropertyViewAsync(PropertyView propertyView);
    ValueTask<PropertyView> RemovePropertyViewByIdAsync(Guid propertyViewId);
}
