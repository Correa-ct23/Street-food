using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Infrastructure.Dtos;

namespace The_Blogs_Of_The_U.Infrastructure.MappingsProfiles
{
    public class RolProfile:Profile
    {
        public RolProfile()
        {
            CreateMap<RolesDto, Roles>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.ROLE_NAME))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.DESCRIPTION))
            .ReverseMap();
        }
    }
}
