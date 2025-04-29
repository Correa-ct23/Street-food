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
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<Users, UserDto>()
           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.STATUS, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.ROLE_ID, opt => opt.MapFrom(src => src.RolId))
           .ForMember(dest => dest.USER_ACCESS_ID, opt => opt.MapFrom(src => src.UserAccesId))
           .ReverseMap();

        }
    }
}
