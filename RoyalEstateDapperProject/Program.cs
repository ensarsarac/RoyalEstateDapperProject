using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Services.Category;
using RoyalEstateDapperProject.Services.Location;
using RoyalEstateDapperProject.Services.Property;
using FluentValidation.AspNetCore;
using System.Globalization;
using RoyalEstateDapperProject.Services.Features;
using RoyalEstateDapperProject.Services.Agent;
using RoyalEstateDapperProject.Services.Testimonial;
using RoyalEstateDapperProject.Services.Newsletter;
using RoyalEstateDapperProject.Services.SendMail;
using RoyalEstateDapperProject.Services.Tag;
using RoyalEstateDapperProject.Services.RealEstateData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    opt.DisableDataAnnotationsValidation = true;
    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
});

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IProperyService,PropertyService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ILocationService,LocationService>();
builder.Services.AddScoped<IFeaturesService,FeaturesService>();
builder.Services.AddScoped<IAgentService,AgentService>();
builder.Services.AddScoped<ITestimonialService,TestimonialService>();
builder.Services.AddScoped<INewsletterService,NewsletterService>();
builder.Services.AddScoped<ISendMailService,SendMailService>();
builder.Services.AddScoped<ITagService,TagService>();
builder.Services.AddScoped<IRealEstateDataService,RealEstateDataService>();

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
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
