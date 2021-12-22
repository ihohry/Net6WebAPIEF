using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6WebAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }
                       

        [HttpPost]
        public async Task<ActionResult<List<Account>>> CreateAccount(CreateAccountDto request)
        {
            if (request.Name == string.Empty)
                return BadRequest("Account name can't be empty");
            var accounts = await _context.Accounts.Where(c => c.Name == request.Name).ToListAsync();
            if (accounts.Count != 0)
                return BadRequest("Account is in the system");

            var newAccount = new Account
            {
                Name = request.Name                
            };

            _context.Accounts.Add(newAccount);
                        
            var requestContact = new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                AccountName = request.Name
            };

            var contact = await _context.Contacts.FindAsync(request.Email);
            if (contact == null)
            _context.Contacts.Add(requestContact);
            else
            _context.Contacts.Update(requestContact);

            await _context.SaveChangesAsync();
            return Ok();                
        }
              


    }
}
