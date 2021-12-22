using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6WebAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly DataContext _context;

        public IncidentController(DataContext context)
        {
            _context = context;
        }
            

        [HttpPost]
        public async Task<ActionResult<List<Incident>>> CreateIncident(CreateIncidentDto request)
        {
            var account = await _context.Accounts.FindAsync(request.AccountName);
            if (account == null)
                return NotFound();
            var contact = await _context.Contacts.FindAsync(request.Email);
            if (contact == null)
            {
                var newContact = createNewContact(request.FirstName, request.LastName, request.Email, request.AccountName);
                
                _context.Contacts.Add(newContact);
            }
            else
            {
                contact.FirstName = request.FirstName;
                contact.LastName = request.LastName;                
                contact.AccountName = request.AccountName;

                _context.Contacts.Update(contact);
            }
             
            var newIncident = createNewIncident(request.AccountName, request.Email, request.IncidentDescription);
            _context.Incidents.Add(newIncident);
                        
            await _context.SaveChangesAsync();

            return Ok($"IncidentName : {newIncident.IncidentName}");
        }

        private Incident createNewIncident(string AccountName, string Email, string IncidentDescription)
        {
            return new Incident
            {                
                AccountName = AccountName,
                ContactEmail = Email,
                IncidentDescription = IncidentDescription
            };
        }

        private Contact createNewContact(string FirstName, string LastName, string Email, string AccountName)
        {
            return new Contact
            {
                FirstName = FirstName,  
                LastName = LastName,
                Email = Email,
                AccountName = AccountName                
            };
        }
                

    }
}
