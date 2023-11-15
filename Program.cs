using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Abstract;
using SchoolApp.Data.EfCore;
using SchoolApp.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolAppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("db_connection"));
});

builder.Services.AddScoped<IStudentRepository, EfStudentRepository>();
builder.Services.AddScoped<ILecturerRepository, EfLecturerRepository>();
builder.Services.AddScoped<ICourseRepository, EfCourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EfEnrollmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())

{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
AddDummyData.AddTestData(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
