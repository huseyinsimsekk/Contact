using AutoMapper;
using Contact.Core.Models;
using Contact.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OwnerDto, OwnerModel>().ReverseMap();
            CreateMap<ContactDto, ContactModel>().ReverseMap();
        }
    }
}
