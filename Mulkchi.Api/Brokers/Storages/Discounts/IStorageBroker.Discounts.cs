using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Discount> InsertDiscountAsync(Discount discount);
    IQueryable<Discount> SelectAllDiscounts();
    ValueTask<Discount> SelectDiscountByIdAsync(Guid discountId);
    ValueTask<Discount> UpdateDiscountAsync(Discount discount);
    ValueTask<Discount> DeleteDiscountByIdAsync(Guid discountId);
}
