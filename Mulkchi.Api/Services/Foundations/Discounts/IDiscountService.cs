using Mulkchi.Api.Models.Foundations.Discounts;

namespace Mulkchi.Api.Services.Foundations.Discounts;

public interface IDiscountService
{
    ValueTask<Discount> AddDiscountAsync(Discount discount);
    IQueryable<Discount> RetrieveAllDiscounts();
    ValueTask<Discount> RetrieveDiscountByIdAsync(Guid discountId);
    ValueTask<Discount> ModifyDiscountAsync(Discount discount);
    ValueTask<Discount> RemoveDiscountByIdAsync(Guid discountId);
}
