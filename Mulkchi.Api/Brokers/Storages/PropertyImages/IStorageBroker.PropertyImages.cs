using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<PropertyImage> InsertPropertyImageAsync(PropertyImage propertyImage);
    IQueryable<PropertyImage> SelectAllPropertyImages();
    ValueTask<PropertyImage> SelectPropertyImageByIdAsync(Guid propertyImageId);
    ValueTask<PropertyImage> UpdatePropertyImageAsync(PropertyImage propertyImage);
    ValueTask<PropertyImage> DeletePropertyImageByIdAsync(Guid propertyImageId);
}
