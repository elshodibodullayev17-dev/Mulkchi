using Mulkchi.Api.Models.Foundations.PropertyImages;

namespace Mulkchi.Api.Services.Foundations.PropertyImages;

public interface IPropertyImageService
{
    ValueTask<PropertyImage> AddPropertyImageAsync(PropertyImage propertyImage);
    IQueryable<PropertyImage> RetrieveAllPropertyImages();
    ValueTask<PropertyImage> RetrievePropertyImageByIdAsync(Guid propertyImageId);
    ValueTask<PropertyImage> ModifyPropertyImageAsync(PropertyImage propertyImage);
    ValueTask<PropertyImage> RemovePropertyImageByIdAsync(Guid propertyImageId);
}
