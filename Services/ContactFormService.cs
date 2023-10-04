using Crito.Contexts;
using Crito.Models;
using Microsoft.EntityFrameworkCore;

namespace Crito.Services;

public class ContactFormService
{
    private readonly DataContext _context;

    public ContactFormService(DataContext context)
    {
        _context = context;
    }

    public async Task AddContactAsync(ContactForm form)
    {
        var existingContact = await _context.ContactForms.FirstOrDefaultAsync(c => c.Email == form.Email);

        if (existingContact == null)
        {
            var contactFormEntity = new ContactFormEntity
            {
                Email = form.Email,
                Name = form.Name,
                Message = form.Message,
            };

            _context.ContactForms.Add(contactFormEntity);
            await _context.SaveChangesAsync();

        }
        else { }
        
    }

}
