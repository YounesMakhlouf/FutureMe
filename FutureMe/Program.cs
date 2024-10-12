using FutureMe.Areas.Identity.Data;
using FutureMe.BackgroundJobs;
using FutureMe.Models;
using FutureMe.Repositories;
using FutureMe.Services.EmailSender;
using FutureMe.Services.LetterGetter;
using FutureMe.Services.LetterSaver;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzHostedService = FutureMe.BackgroundJobs.QuartzHostedService;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register application services
builder.Services.AddScoped<ILetterRepository, LetterRepository>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<ILetterSaverService, LetterSaverService>();
builder.Services.AddTransient<ILetterGetter, LetterGetter>();

// Configure Quartz for background jobs
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<IJobFactory, JobFactory>();
builder.Services.AddSingleton<EmailSendingBackgroundJob>();
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddSingleton(new JobSchedule(
    jobType: typeof(EmailSendingBackgroundJob),
    cronExpression: "* * * * * ?" // Every day at midnight (Cron expression)
));

// Configure application cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
