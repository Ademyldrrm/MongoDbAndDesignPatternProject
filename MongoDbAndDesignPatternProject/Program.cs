using Microsoft.Extensions.Options;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;
using MongoDbAndDesignPatternProject.DAL.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GetTeamQueryHandler>();
builder.Services.AddScoped<CreateTeamQueryHandler>();
builder.Services.AddScoped<GetTeamByIdQueryHandler>();
builder.Services.AddScoped<UpdateTeamCommandHandler>();
builder.Services.AddScoped<DeleteTeamCommandHandler>();


builder.Services.AddScoped<GetAllServiceQueryHandler>();
builder.Services.AddScoped<CreateServiceQueryHandler>();
builder.Services.AddScoped<DeleteServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<UpdateServiceQueryHandler>();

builder.Services.AddScoped<CreateContactQueryHandler>();
builder.Services.AddScoped<GetAllContactQueryHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

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
