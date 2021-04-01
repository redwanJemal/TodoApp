using AutoMapper;
using Services.Dto;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TestEntity, TestDto>();
        }
    }
}
