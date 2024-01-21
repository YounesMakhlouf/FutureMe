using FutureMe.Models;
using FutureMe.Services.EmailSender;
using FutureMe.BackgroundJobs;
using Microsoft.EntityFrameworkCore;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using QuartzHostedService = FutureMe.BackgroundJobs.QuartzHostedService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton<EmailSendingBackgroundJob>();
builder.Services.AddSingleton<IJobFactory, JobFactory>();
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton(new JobSchedule(
    jobType: typeof(EmailSendingBackgroundJob)));
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