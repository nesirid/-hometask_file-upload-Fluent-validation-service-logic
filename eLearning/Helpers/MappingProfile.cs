using AutoMapper;
using eLearning.DTOs.Abouts;
using eLearning.DTOs.Sliders;
using eLearning.Models;

namespace eLearning.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Slider
            CreateMap<Slider, SliderDto>();
            CreateMap<SliderDto, Slider>();
            CreateMap<SliderCreateDto, Slider>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<SliderEditDto, SliderDto>();
            CreateMap<SliderDto, SliderEditDto>();

            //About
            CreateMap<About, AboutDto>();
            CreateMap<AboutDto, About>();
            CreateMap<AboutCreateDto, About>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<AboutEditDto, AboutDto>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<About, AboutCreateDto>();
            CreateMap<AboutEditDto, AboutDto>();
            CreateMap<AboutDto, AboutEditDto>();


        }
    }
}
