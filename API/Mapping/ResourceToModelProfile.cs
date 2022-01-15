using API.Domain.Models;
using API.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapping
{
    public class ResourceToModelProfile : Profile
    {

        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }

    }
}