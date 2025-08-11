using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using api_explorer_hub.Storage;
using Microsoft.AspNetCore.Mvc;

namespace api_explorer_hub.Controllers
{
    public class ContactManagementController : BaseController
    {
        private readonly IPaginationStorage contactStorage;

        public ContactManagementController(IPaginationStorage contactStorage)
        {
            this.contactStorage = contactStorage;
        }

        [HttpPost("contacts")]
        public IActionResult Create([FromBody] Contact contact)
        {
            Contact res = contactStorage.Add(contact);
            if (res != null)
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
        public IActionResult DeleteContacts(int id)
        {
            bool res = contactStorage.Remove(id);
            if (res) return NoContent();
            return BadRequest();
        }

        [HttpPut("contacts/{id}")]
        public IActionResult UpdateContacts([FromBody] ContactDto contactDto, int id)
        {
            bool res = contactStorage.Update(contactDto, id);
            if (res) return Ok();
            return Conflict("Contact with this id is not found.");
        }

        [HttpGet("contacts/{id}")]
        public IActionResult FindContactById(int id)
        {

            if (id < 0)
            {
                return BadRequest("Invalid format of id");
            }

            var contact = contactStorage.FindContactById(id);
            
            if (contact == null) return NotFound($"Contact with id: {id} does not exist.");

            return Ok(contact);
        }

        [HttpGet("contacts/page")]
        public IActionResult GetContacts(int pageNumber = 1, int pageSize = 5)
        {
            var (contacts, total) = contactStorage.GetContacts(pageNumber, pageSize);

            var response = new
            {
                Contacts = contacts,
                TotalCount = total,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };

            return Ok(response);
        }
    }
}
