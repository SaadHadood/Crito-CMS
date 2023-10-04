using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactsController : SurfaceController
    {
        private readonly ContactFormService _formService;
        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactFormService formService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _formService = formService;
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            await _formService.AddContactAsync(contactForm);

            using var mail = new MailService("no-reply@crito.com", "smtp01.binero.se", 587, "saad@domain.com", "BytMig123!");

            // to sender
            await mail.SendAsync(contactForm.Email, "Your contact request was received.", "Hi your request was received and we will be in contact with you as soon as possible.").ConfigureAwait(false);

            // to us
            await mail.SendAsync("saad-96-08@hotmail.com", $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false);


            return LocalRedirect(contactForm.RedirectUrl ?? "/");
        }
    }
}
