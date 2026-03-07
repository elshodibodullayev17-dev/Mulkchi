using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Models.Foundations.Discounts.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.Discounts;

public partial class DiscountService : IDiscountService
{
    private readonly IStorageBroker storageBroker;

    public DiscountService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<Discount> AddDiscountAsync(Discount discount) =>
        TryCatch(async () =>
        {
            ValidateDiscountOnAdd(discount);
            return await this.storageBroker.InsertDiscountAsync(discount);
        });

    public IQueryable<Discount> RetrieveAllDiscounts() =>
        TryCatch(() => this.storageBroker.SelectAllDiscounts());

    public ValueTask<Discount> RetrieveDiscountByIdAsync(Guid discountId) =>
        TryCatch(async () =>
        {
            ValidateDiscountId(discountId);
            Discount maybeDiscount = await this.storageBroker.SelectDiscountByIdAsync(discountId);

            if (maybeDiscount is null)
                throw new NotFoundDiscountException(discountId);

            return maybeDiscount;
        });

    public ValueTask<Discount> ModifyDiscountAsync(Discount discount) =>
        TryCatch(async () =>
        {
            ValidateDiscountOnModify(discount);
            return await this.storageBroker.UpdateDiscountAsync(discount);
        });

    public ValueTask<Discount> RemoveDiscountByIdAsync(Guid discountId) =>
        TryCatch(async () =>
        {
            ValidateDiscountId(discountId);
            return await this.storageBroker.DeleteDiscountByIdAsync(discountId);
        });
}
