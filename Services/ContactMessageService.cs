using TBADatalyticsSolutions.Data;
using TBADatalyticsSolutions.IServices;
using TBADatalyticsSolutions.Models;

namespace TBADatalyticsSolutions.Services;

public class ContactMessageService : IContactMessageService
{
    private readonly AppDbContext _context;

    public ContactMessageService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ContactMessage> GetAllMessages()
    {
        return _context.ContactMessages.ToList();
    }

    public ContactMessage? GetMessageById(int id)
    {
        return _context.ContactMessages.Find(id);
    }

    public void AddMessage(ContactMessage message)
    {
        _context.ContactMessages.Add(message);
        _context.SaveChanges();
    }

    public void DeleteMessage(int id)
    {
        var message = _context.ContactMessages.Find(id);
        if (message != null)
        {
            _context.ContactMessages.Remove(message);
            _context.SaveChanges();
        }
    }
}