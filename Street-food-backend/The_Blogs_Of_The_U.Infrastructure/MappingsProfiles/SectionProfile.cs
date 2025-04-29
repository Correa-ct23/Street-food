using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.Mappings
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<SectionsDto, Sections>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.section_id))
              .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.section_name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
              .ReverseMap();

        }
    }
}
