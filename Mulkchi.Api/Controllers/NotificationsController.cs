using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mulkchi.Api.Models.Foundations.Common;
using Mulkchi.Api.Models.Foundations.Notifications;
using Mulkchi.Api.Models.Foundations.Notifications.Exceptions;
using Mulkchi.Api.Services.Foundations.Notifications;

namespace Mulkchi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    [HttpPost]
    [Authorize]
    public async ValueTask<ActionResult<Notification>> PostNotificationAsync(Notification notification)
    {
        try
        {
            Notification addedNotification = await this.notificationService.AddNotificationAsync(notification);
            return Created("notification", addedNotification);
        }
        catch (NotificationValidationException notificationValidationException)
        {
            return BadRequest(new { message = notificationValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
        {
            return BadRequest(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (NotificationServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet]
    [Authorize]
    public ActionResult<PagedResult<Notification>> GetAllNotifications([FromQuery] PaginationParams pagination)
    {
        try
        {
            IQueryable<Notification> query = this.notificationService.RetrieveAllNotifications();
            int totalCount = query.Count();

            var items = query
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var result = new PagedResult<Notification>
            {
                Items = items,
                TotalCount = totalCount,
                Page = pagination.Page,
                PageSize = pagination.PageSize
            };

            return Ok(result);
        }
        catch (NotificationDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (NotificationServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async ValueTask<ActionResult<Notification>> GetNotificationByIdAsync(Guid id)
    {
        try
        {
            Notification notification = await this.notificationService.RetrieveNotificationByIdAsync(id);
            return Ok(notification);
        }
        catch (NotificationValidationException notificationValidationException)
        {
            return BadRequest(new { message = notificationValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
            when (notificationDependencyValidationException.InnerException is NotFoundNotificationException)
        {
            return NotFound(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
        {
            return BadRequest(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (NotificationServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpPut]
    [Authorize]
    public async ValueTask<ActionResult<Notification>> PutNotificationAsync(Notification notification)
    {
        try
        {
            Notification modifiedNotification = await this.notificationService.ModifyNotificationAsync(notification);
            return Ok(modifiedNotification);
        }
        catch (NotificationValidationException notificationValidationException)
        {
            return BadRequest(new { message = notificationValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
            when (notificationDependencyValidationException.InnerException is NotFoundNotificationException)
        {
            return NotFound(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
        {
            return BadRequest(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (NotificationServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async ValueTask<ActionResult<Notification>> DeleteNotificationByIdAsync(Guid id)
    {
        try
        {
            Notification deletedNotification = await this.notificationService.RemoveNotificationByIdAsync(id);
            return Ok(deletedNotification);
        }
        catch (NotificationValidationException notificationValidationException)
        {
            return BadRequest(new { message = notificationValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
            when (notificationDependencyValidationException.InnerException is NotFoundNotificationException)
        {
            return NotFound(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyValidationException notificationDependencyValidationException)
        {
            return BadRequest(new { message = notificationDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (NotificationDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (NotificationServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }
}
