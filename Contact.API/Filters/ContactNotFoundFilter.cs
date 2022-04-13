using Contact.API.Dtos;
using Contact.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Filters
{
    public class ContactNotFoundFilter : ActionFilterAttribute
    {
        private IContactService _service;
        public ContactNotFoundFilter(IContactService service)
        {
            _service = service;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameters = context.ActionArguments.Values.ToArray();
            if (parameters is null || parameters.Length != 3)
            {
                var errorDto = new ResponseDto();
                errorDto.Success = false;
                errorDto.Message = "Invalid Parameters";
                context.Result = new NotFoundObjectResult(errorDto);
            }

            int ownerId = (int)parameters[0];
            string value = (string)parameters[1];
            string key = (string)parameters[2];
            var book = _service.SearchByKey(ownerId, key, value);
         
            if (book != null)
            {
                await next();
            }
            else
            {
                var errorDto = new ResponseDto();
                errorDto.Success = false;
                errorDto.Message = "Contact Not Found!";
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
