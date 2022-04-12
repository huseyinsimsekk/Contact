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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        public OwnerController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var owner = _service.GetOwnerByContact(id);
            if (owner is null) return NotFound("Owner Is Not Found");
            return Ok(owner);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OwnerModel model)
        {
            _service.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] OwnerModel model)
        {
            _service.Update(model);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
