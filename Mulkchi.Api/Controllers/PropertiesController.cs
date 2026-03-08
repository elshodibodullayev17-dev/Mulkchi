using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mulkchi.Api.Models.Foundations.Common;
using Mulkchi.Api.Models.Foundations.Properties;
using Mulkchi.Api.Models.Foundations.Properties.Exceptions;
using Mulkchi.Api.Services.Foundations.Properties;

namespace Mulkchi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService propertyService;

    public PropertiesController(IPropertyService propertyService)
    {
        this.propertyService = propertyService;
    }

    [HttpPost]
    [Authorize(Roles = "Host,Admin")]
    public async ValueTask<ActionResult<Property>> PostPropertyAsync(Property property)
    {
        try
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim is null || !Guid.TryParse(userIdClaim, out Guid currentUserId))
                return Unauthorized();

            property.HostId = currentUserId;
            property.IsFeatured = false;
            property.IsVerified = false;
            property.AverageRating = 0;
            property.ViewsCount = 0;
            property.FavoritesCount = 0;

            Property addedProperty = await this.propertyService.AddPropertyAsync(property);
            return Created("property", addedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(new { message = propertyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (PropertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<PagedResult<Property>> GetAllProperties(
        [FromQuery] PaginationParams pagination,
        [FromQuery] string? city = null,
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] int? bedrooms = null,
        [FromQuery] UzbekistanRegion? region = null,
        [FromQuery] ListingType? listingType = null)
    {
        try
        {
            IQueryable<Property> query = this.propertyService.RetrieveAllProperties();

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(p => p.City == city);

            if (minPrice.HasValue)
                query = query.Where(p => p.MonthlyRent >= minPrice || p.SalePrice >= minPrice || p.PricePerNight >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(p => p.MonthlyRent <= maxPrice || p.SalePrice <= maxPrice || p.PricePerNight <= maxPrice);

            if (bedrooms.HasValue)
                query = query.Where(p => p.NumberOfBedrooms == bedrooms);

            if (region.HasValue)
                query = query.Where(p => p.Region == region.Value);

            if (listingType.HasValue)
                query = query.Where(p => p.ListingType == listingType.Value);

            int totalCount = query.Count();

            var items = query
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var result = new PagedResult<Property>
            {
                Items = items,
                TotalCount = totalCount,
                Page = pagination.Page,
                PageSize = pagination.PageSize
            };

            return Ok(result);
        }
        catch (PropertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (PropertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async ValueTask<ActionResult<Property>> GetPropertyByIdAsync(Guid id)
    {
        try
        {
            Property property = await this.propertyService.RetrievePropertyByIdAsync(id);
            return Ok(property);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(new { message = propertyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (PropertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpPut]
    [Authorize(Roles = "Host,Admin")]
    public async ValueTask<ActionResult<Property>> PutPropertyAsync(Property property)
    {
        try
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim is null || !Guid.TryParse(userIdClaim, out Guid currentUserId))
                return Unauthorized();

            bool isAdmin = User.IsInRole("Admin");
            if (!isAdmin)
            {
                Property existingProperty = await this.propertyService.RetrievePropertyByIdAsync(property.Id);
                if (existingProperty.HostId != currentUserId)
                    return Forbid();
            }

            Property modifiedProperty = await this.propertyService.ModifyPropertyAsync(property);
            return Ok(modifiedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(new { message = propertyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (PropertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Host,Admin")]
    public async ValueTask<ActionResult<Property>> DeletePropertyByIdAsync(Guid id)
    {
        try
        {
            Property deletedProperty = await this.propertyService.RemovePropertyByIdAsync(id);
            return Ok(deletedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(new { message = propertyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(new { message = propertyDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (PropertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (PropertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }
}
