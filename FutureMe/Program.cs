using FutureMe.Models;
using FutureMe.Repositories;
using FutureMe.Services.EmailSender;
using FutureMe.Services.LetterSaver;
using Microsoft.EntityFrameworkCore;
using FutureMe.BackgroundJobs;
using Microsoft.EntityFrameworkCore;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using QuartzHostedService = FutureMe.BackgroundJobs.QuartzHostedService;
using FutureMe.Services.LetterGetter;
using FutureMe.Services.LetterSaver;
using FutureMe.Data;
using FutureMe.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<LetterRepository, LetterRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<ILetterSaverService, LetterSaverService>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<ILetterSaverService, LetterSaverService>();
builder.Services.AddScoped<LetterRepository, LetterRepository>();
builder.Services.AddTransient<ILetterGetter, LetterGetter>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
