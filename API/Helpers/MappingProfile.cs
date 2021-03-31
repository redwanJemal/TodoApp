using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoDetailDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Todo, TodoListDto>();
        }
    }
}
