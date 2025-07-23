using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using api_explorer_hub.Storage;
using Microsoft.AspNetCore.Mvc;

namespace api_explorer_hub.Controllers
{
    public class ContactManagementController : BaseController
    {
        private readonly ContactStorage contactStorage;
        
        public ContactManagementController(ContactStorage contactStorage)
        {
            this.contactStorage = contactStorage;
        }

        [HttpPost("contacts")]
        public IActionResult Create([FromBody]Contact contact)
        {
            bool res = contactStorage.Add(contact);
            if (res)
            {
                return Created(contact.Id.ToString(), contact);
            }
            return Conflict($"Contact with this id already exists: {contact.Id}, {contact.Name}");
        }

        [HttpGet("contacts")]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(contactStorage.GetContacts());
        }

        [HttpDelete("contacts/{id}")]
        public IActionResult DeleteContacts(Guid id)
        {
            bool res = contactStorage.Remove(id);
            if (res) return NoContent();
            return BadRequest();
        }

        [HttpPut("contacts/{id}")]
        public IActionResult UpdateContacts([FromBody] ContactDto contactDto, Guid id)
        {
            bool res = contactStorage.Update(contactDto, id);
            if (res) return Ok();
            return Conflict("Contact with this id is not found.");
        }

        [HttpGet("contacts/{id}")]
        public IActionResult FindContactById(Guid id)
        {
            
            Contact foundedContact = contactStorage.FindContactById(id);
            if (foundedContact.Id.Equals(Guid.Empty)) return NotFound($"Contact with id: {id} does not exist.");

            return Ok($"Contact has been founded - " +
                $"id: {foundedContact.Id}, " +
                $"Name: {foundedContact.Name}, " +
                $"Email: {foundedContact.Email}, " +
                $"Address: {foundedContact.Address}.");
        }
    }
}
