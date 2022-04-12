using Contact.Core.Contracts.Services;
using Contact.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContacts(int ownerId)
        {
            var contacts = _contactService.GetContactsByOwner(ownerId);
            return Ok(contacts);
        }
        [HttpGet("{key}/{value}")]
        public IActionResult SearchContact(string key, string value)
        {
            var contact = _contactService.SearchByKey(key,value);
            if (contact is null) return NotFound("Contact Is Not Found");
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ContactModel model)
        {
            _contactService.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ContactModel model)
        {
            _contactService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok();
        }
    }
}
