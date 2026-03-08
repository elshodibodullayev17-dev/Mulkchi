using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mulkchi.Api.Models.Foundations.Common;
using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Models.Foundations.Discounts.Exceptions;
using Mulkchi.Api.Services.Foundations.Discounts;

namespace Mulkchi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService discountService;

    public DiscountsController(IDiscountService discountService)
    {
        this.discountService = discountService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Host")]
    public async ValueTask<ActionResult<Discount>> PostDiscountAsync(Discount discount)
    {
        try
        {
            Discount addedDiscount = await this.discountService.AddDiscountAsync(discount);
            return Created("discount", addedDiscount);
        }
        catch (DiscountValidationException discountValidationException)
        {
            return BadRequest(new { message = discountValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
        {
            return BadRequest(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (DiscountServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<PagedResult<Discount>> GetAllDiscounts([FromQuery] PaginationParams pagination)
    {
        try
        {
            IQueryable<Discount> query = this.discountService.RetrieveAllDiscounts()
                .Where(d => d.IsActive);
            int totalCount = query.Count();

            var items = query
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var result = new PagedResult<Discount>
            {
                Items = items,
                TotalCount = totalCount,
                Page = pagination.Page,
                PageSize = pagination.PageSize
            };

            return Ok(result);
        }
        catch (DiscountDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (DiscountServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async ValueTask<ActionResult<Discount>> GetDiscountByIdAsync(Guid id)
    {
        try
        {
            Discount discount = await this.discountService.RetrieveDiscountByIdAsync(id);
            return Ok(discount);
        }
        catch (DiscountValidationException discountValidationException)
        {
            return BadRequest(new { message = discountValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
            when (discountDependencyValidationException.InnerException is NotFoundDiscountException)
        {
            return NotFound(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
        {
            return BadRequest(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (DiscountServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin,Host")]
    public async ValueTask<ActionResult<Discount>> PutDiscountAsync(Discount discount)
    {
        try
        {
            Discount modifiedDiscount = await this.discountService.ModifyDiscountAsync(discount);
            return Ok(modifiedDiscount);
        }
        catch (DiscountValidationException discountValidationException)
        {
            return BadRequest(new { message = discountValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
            when (discountDependencyValidationException.InnerException is NotFoundDiscountException)
        {
            return NotFound(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
        {
            return BadRequest(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (DiscountServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Host")]
    public async ValueTask<ActionResult<Discount>> DeleteDiscountByIdAsync(Guid id)
    {
        try
        {
            Discount deletedDiscount = await this.discountService.RemoveDiscountByIdAsync(id);
            return Ok(deletedDiscount);
        }
        catch (DiscountValidationException discountValidationException)
        {
            return BadRequest(new { message = discountValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
            when (discountDependencyValidationException.InnerException is NotFoundDiscountException)
        {
            return NotFound(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyValidationException discountDependencyValidationException)
        {
            return BadRequest(new { message = discountDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (DiscountDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (DiscountServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }
}
