using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Message> InsertMessageAsync(Message message);
    IQueryable<Message> SelectAllMessages();
    ValueTask<Message> SelectMessageByIdAsync(Guid messageId);
    ValueTask<Message> UpdateMessageAsync(Message message);
    ValueTask<Message> DeleteMessageByIdAsync(Guid messageId);
}
