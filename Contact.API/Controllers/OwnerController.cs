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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var owner = _service.GetOwnerByContact(id);
            if (owner is null) return NotFound("Owner Is Not Found");
            var ownerModel = _mapper.Map<OwnerDto>(owner);
            return Ok(ownerModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OwnerDto model)
        {
            var owner = _mapper.Map<OwnerModel>(model);
            _service.Add(owner);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] OwnerUpdateDto model)
        {
            var owner = _mapper.Map<OwnerModel>(model);
            owner.EffectedDate = DateTime.Now;
            _service.Update(owner);
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
