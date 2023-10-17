using Appoinment.Repository;
using Appoinment.Repository.Implimentation;
using Appointment.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppointmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
},
    ServiceLifetime.Transient);

builder.Services.AddTransient<IUserAccount, UserAccountRepository>(p => new UserAccountRepository(builder.Services.BuildServiceProvider().GetService<AppointmentContext>()));
builder.Services.AddTransient<IUser, UserRepository>(p => new UserRepository(builder.Services.BuildServiceProvider().GetService<AppointmentContext>()));
builder.Services.AddTransient<IHospital, HospitalRepository>(p => new HospitalRepository(builder.Services.BuildServiceProvider().GetService<AppointmentContext>()));


// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
