using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Services.Foundations.Messages;

public interface IMessageService
{
    ValueTask<Message> AddMessageAsync(Message message);
    IQueryable<Message> RetrieveAllMessages();
    ValueTask<Message> RetrieveMessageByIdAsync(Guid messageId);
    ValueTask<Message> ModifyMessageAsync(Message message);
    ValueTask<Message> RemoveMessageByIdAsync(Guid messageId);
}
