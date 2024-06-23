using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using eLearning.Data;
using eLearning.Helpers;
using eLearning.Services.Interfaces;
using eLearning.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddSingleton(builder.Environment);

builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IInformationIconService, InformationIconService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
