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
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
             CreateMap<Reviews, ReviewsDto>()
                .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.review_text, opt => opt.MapFrom(src => src.ReviewText))
                .ForMember(dest => dest.rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.review_date, opt => opt.MapFrom(src => src.ReviewDate))
                .ForMember(dest => dest.service_name, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.provider_name, opt => opt.MapFrom(src => src.ProviderName))
                .ReverseMap();
        
        }
    }
}
