using Contactly_API.Data;
using Contactly_API.Models;
using Contactly_API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbcontext dbcontext;  // variable 

        public ContactsController(ContactlyDbcontext dbcontext ) 
        {
            this.dbcontext = dbcontext;  // injected Dbcontext class
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbcontext.Contacts.ToList();
            return Ok( contacts );   // return as Ok response
        }

        [HttpPost]

        public IActionResult AddContact(AddContactRequestDTO request)
        {

            // first map the DTO to the domain model 
            // the framework only knows domain model 
            var domainModelContact = new Contact  
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite,
            };

            dbcontext.Contacts.Add( domainModelContact );
            dbcontext.SaveChanges();

            return Ok( domainModelContact );
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {

            var contact = dbcontext.Contacts.Find(id); // getting the id if its exists in our DB else null

            if (contact is not null)
            {
                dbcontext.Contacts.Remove(contact);
                dbcontext.SaveChanges();
            }

            return Ok();

        }

    }
}
