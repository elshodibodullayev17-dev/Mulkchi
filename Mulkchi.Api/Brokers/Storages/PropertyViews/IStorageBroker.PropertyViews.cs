using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<PropertyView> InsertPropertyViewAsync(PropertyView propertyView);
    IQueryable<PropertyView> SelectAllPropertyViews();
    ValueTask<PropertyView> SelectPropertyViewByIdAsync(Guid propertyViewId);
    ValueTask<PropertyView> UpdatePropertyViewAsync(PropertyView propertyView);
    ValueTask<PropertyView> DeletePropertyViewByIdAsync(Guid propertyViewId);
}
