using eLearning.Services.Interfaces;
using eLearning.Services;
using eLearning.Data;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Helpers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {


            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IInformationIconService, InformationIconService>();
            services.AddScoped<ISocialService, SocialService>();

            return services;
        }
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddSingleton(environment);

            services.AddProjectServices();

            return services;
        }
    }
}
