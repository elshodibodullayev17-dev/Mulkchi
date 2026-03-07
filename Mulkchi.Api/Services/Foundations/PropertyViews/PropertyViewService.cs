using Mulkchi.Api.Models.Foundations.PropertyViews;
using Mulkchi.Api.Models.Foundations.PropertyViews.Exceptions;
using Mulkchi.Api.Brokers.DateTimes;
using Mulkchi.Api.Brokers.Loggings;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.PropertyViews;

public partial class PropertyViewService : IPropertyViewService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;
    private readonly IDateTimeBroker dateTimeBroker;

    public PropertyViewService(
        IStorageBroker storageBroker,
        ILoggingBroker loggingBroker,
        IDateTimeBroker dateTimeBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
        this.dateTimeBroker = dateTimeBroker;
    }

    public ValueTask<PropertyView> AddPropertyViewAsync(PropertyView propertyView) =>
        TryCatch(async () =>
        {
            ValidatePropertyViewOnAdd(propertyView);
            return await this.storageBroker.InsertPropertyViewAsync(propertyView);
        });

    public IQueryable<PropertyView> RetrieveAllPropertyViews() =>
        TryCatch(() => this.storageBroker.SelectAllPropertyViews());

    public ValueTask<PropertyView> RetrievePropertyViewByIdAsync(Guid propertyViewId) =>
        TryCatch(async () =>
        {
            ValidatePropertyViewId(propertyViewId);
            PropertyView maybePropertyView = await this.storageBroker.SelectPropertyViewByIdAsync(propertyViewId);

            if (maybePropertyView is null)
                throw new NotFoundPropertyViewException(propertyViewId);

            return maybePropertyView;
        });

    public ValueTask<PropertyView> ModifyPropertyViewAsync(PropertyView propertyView) =>
        TryCatch(async () =>
        {
            ValidatePropertyViewOnModify(propertyView);
            return await this.storageBroker.UpdatePropertyViewAsync(propertyView);
        });

    public ValueTask<PropertyView> RemovePropertyViewByIdAsync(Guid propertyViewId) =>
        TryCatch(async () =>
        {
            ValidatePropertyViewId(propertyViewId);
            return await this.storageBroker.DeletePropertyViewByIdAsync(propertyViewId);
        });
}
