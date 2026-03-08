using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mulkchi.Api.Models.Foundations.Common;
using Mulkchi.Api.Models.Foundations.Messages;
using Mulkchi.Api.Models.Foundations.Messages.Exceptions;
using Mulkchi.Api.Services.Foundations.Messages;

namespace Mulkchi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageService messageService;

    public MessagesController(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    [HttpPost]
    [Authorize]
    public async ValueTask<ActionResult<Message>> PostMessageAsync(Message message)
    {
        try
        {
            Message addedMessage = await this.messageService.AddMessageAsync(message);
            return Created("message", addedMessage);
        }
        catch (MessageValidationException messageValidationException)
        {
            return BadRequest(new { message = messageValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
        {
            return BadRequest(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (MessageServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet]
    [Authorize]
    public ActionResult<PagedResult<Message>> GetAllMessages([FromQuery] PaginationParams pagination)
    {
        try
        {
            IQueryable<Message> query = this.messageService.RetrieveAllMessages();
            int totalCount = query.Count();

            var items = query
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var result = new PagedResult<Message>
            {
                Items = items,
                TotalCount = totalCount,
                Page = pagination.Page,
                PageSize = pagination.PageSize
            };

            return Ok(result);
        }
        catch (MessageDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (MessageServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async ValueTask<ActionResult<Message>> GetMessageByIdAsync(Guid id)
    {
        try
        {
            Message message = await this.messageService.RetrieveMessageByIdAsync(id);
            return Ok(message);
        }
        catch (MessageValidationException messageValidationException)
        {
            return BadRequest(new { message = messageValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
            when (messageDependencyValidationException.InnerException is NotFoundMessageException)
        {
            return NotFound(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
        {
            return BadRequest(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (MessageServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpPut]
    [Authorize]
    public async ValueTask<ActionResult<Message>> PutMessageAsync(Message message)
    {
        try
        {
            Message modifiedMessage = await this.messageService.ModifyMessageAsync(message);
            return Ok(modifiedMessage);
        }
        catch (MessageValidationException messageValidationException)
        {
            return BadRequest(new { message = messageValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
            when (messageDependencyValidationException.InnerException is NotFoundMessageException)
        {
            return NotFound(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
        {
            return BadRequest(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (MessageServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async ValueTask<ActionResult<Message>> DeleteMessageByIdAsync(Guid id)
    {
        try
        {
            Message deletedMessage = await this.messageService.RemoveMessageByIdAsync(id);
            return Ok(deletedMessage);
        }
        catch (MessageValidationException messageValidationException)
        {
            return BadRequest(new { message = messageValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
            when (messageDependencyValidationException.InnerException is NotFoundMessageException)
        {
            return NotFound(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyValidationException messageDependencyValidationException)
        {
            return BadRequest(new { message = messageDependencyValidationException.InnerException?.Message ?? "An error occurred." });
        }
        catch (MessageDependencyException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
        catch (MessageServiceException)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal server error." });
        }
    }
}
