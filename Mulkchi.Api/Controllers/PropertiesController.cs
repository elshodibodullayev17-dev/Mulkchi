using Microsoft.AspNetCore.Mvc;
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
    public async ValueTask<ActionResult<Property>> PostPropertyAsync(Property property)
    {
        try
        {
            Property addedProperty = await this.propertyService.AddPropertyAsync(property);
            return Created("property", addedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(propertyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyException propertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyDependencyException.InnerException);
        }
        catch (PropertyServiceException propertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyServiceException.InnerException);
        }
    }

    [HttpGet]
    public ActionResult<IQueryable<Property>> GetAllProperties()
    {
        try
        {
            IQueryable<Property> propertys = this.propertyService.RetrieveAllProperties();
            return Ok(propertys);
        }
        catch (PropertyDependencyException propertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyDependencyException.InnerException);
        }
        catch (PropertyServiceException propertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyServiceException.InnerException);
        }
    }

    [HttpGet("{id}")]
    public async ValueTask<ActionResult<Property>> GetPropertyByIdAsync(Guid id)
    {
        try
        {
            Property property = await this.propertyService.RetrievePropertyByIdAsync(id);
            return Ok(property);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(propertyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyException propertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyDependencyException.InnerException);
        }
        catch (PropertyServiceException propertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyServiceException.InnerException);
        }
    }

    [HttpPut]
    public async ValueTask<ActionResult<Property>> PutPropertyAsync(Property property)
    {
        try
        {
            Property modifiedProperty = await this.propertyService.ModifyPropertyAsync(property);
            return Ok(modifiedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(propertyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyException propertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyDependencyException.InnerException);
        }
        catch (PropertyServiceException propertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyServiceException.InnerException);
        }
    }

    [HttpDelete("{id}")]
    public async ValueTask<ActionResult<Property>> DeletePropertyByIdAsync(Guid id)
    {
        try
        {
            Property deletedProperty = await this.propertyService.RemovePropertyByIdAsync(id);
            return Ok(deletedProperty);
        }
        catch (PropertyValidationException propertyValidationException)
        {
            return BadRequest(propertyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
            when (propertyDependencyValidationException.InnerException is NotFoundPropertyException)
        {
            return NotFound(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyValidationException propertyDependencyValidationException)
        {
            return BadRequest(propertyDependencyValidationException.InnerException);
        }
        catch (PropertyDependencyException propertyDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyDependencyException.InnerException);
        }
        catch (PropertyServiceException propertyServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, propertyServiceException.InnerException);
        }
    }
}
