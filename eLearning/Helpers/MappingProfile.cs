using AutoMapper;
using eLearning.DTOs.Abouts;
using eLearning.DTOs.Categories;
using eLearning.DTOs.Sliders;
using eLearning.Models;
using eLearning.DTOs.Courses;
using eLearning.DTOs.Instructors;
using eLearning.DTOs.SocialInstructors;
using eLearning.DTOs.Students;
using eLearning.DTOs.CourseStudents;
using eLearning.DTOs.Contacts;
using eLearning.DTOs.InformationIcons;
using eLearning.DTOs.Socials;

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
            //Categories
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<CategoryEditDto, Category>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<CategoryEditDto, CategoryDto>();
            //Corse
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseEditDto, Course>();
            //Instructors
            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorDto, Instructor>();
            CreateMap<InstructorCreateDto, Instructor>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<InstructorEditDto, Instructor>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            //SocialInstructors
            CreateMap<InstructorSocial, InstructorSocialDto>();
            CreateMap<InstructorSocialDto, InstructorSocial>();
            CreateMap<InstructorSocialCreateDto, InstructorSocial>();
            CreateMap<InstructorSocialEditDto, InstructorSocial>();
            //Students
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<StudentCreateDto, Student>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<StudentEditDto, Student>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<StudentEditDto, StudentDto>();
            //Courses
            CreateMap<CourseStudent, CourseStudentDto>();
            CreateMap<CourseStudentDto, CourseStudent>();
            //Contacts
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
            CreateMap<ContactCreateDto, Contact>();
            CreateMap<ContactEditDto, Contact>();
            //InformationIcon
            CreateMap<InformationIcon, InformationIconDto>();
            CreateMap<InformationIconDto, InformationIcon>();
            CreateMap<InformationIconCreateDto, InformationIcon>();
            CreateMap<InformationIconEditDto, InformationIcon>();
            //Social
            CreateMap<Social, SocialDto>();
            CreateMap<SocialDto, Social>();
            CreateMap<SocialCreateDto, Social>();
            CreateMap<SocialEditDto, Social>();
        }
    }
}
