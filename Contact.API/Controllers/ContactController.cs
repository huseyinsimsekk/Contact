using AutoMapper;
using Contact.Core.Contracts.Services;
using Contact.Core.DTOs;
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
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContacts(int ownerId)
        {
            var contacts = _contactService.GetContactsByOwner(ownerId);
            if (contacts is null || contacts.Count <= 0) return NotFound("This Owner Does Not Have Contacts");
            var model = _mapper.Map<List<ContactDto>>(contacts);
            return Ok(model);
        }
        [HttpGet("{ownerId}/{key}/{value}")]
        public IActionResult SearchContact(int ownerId, string key, string value)
        {
            var contact = _contactService.SearchByKey(ownerId, key, value);
            if (contact is null) return NotFound("Contact Is Not Found");
            var contactModel = _mapper.Map<ContactUpdateDto>(contact);
            return Ok(contactModel);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ContactDto model)
        {
            var contact = _mapper.Map<ContactModel>(model);
            _contactService.Add(contact);
            return Ok("Contact Created!");
        }

        [HttpPut]
        public IActionResult Update([FromBody] ContactUpdateDto model)
        {
            var contact = _mapper.Map<ContactModel>(model);
            _contactService.Update(contact);
            return Ok("Contact Updated!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok("Contact Deleted!");
        }

    }
}
