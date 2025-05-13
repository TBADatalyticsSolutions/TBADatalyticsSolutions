using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.IServices;

public interface IContactMessageService
{
    IEnumerable<ContactMessage> GetAllMessages();
    ContactMessage? GetMessageById(int id);
    void AddMessage(ContactMessage message);
    void DeleteMessage(int id);
}