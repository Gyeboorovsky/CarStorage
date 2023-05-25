using CarStorage.DAL.DataModel;
using CarStorage.DAL.Infrastructure;
using CarStorage.DAL.ModelExtension.BodyType;
using CarStorage.DAL.ModelExtension.Vehicle;
using CarStorage.Repository;
using CarStorage.Service;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CarStorageDb");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

builder.Services.AddDbContext<CarStorageContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
     //.AddFluentValidation()
    //.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<IFluentValidator>());

builder.Services.AddCors(o =>
    o.AddPolicy("CarRentWeb", origin => {
        origin.WithOrigins(builder.Configuration.GetValue<string>("CarRentWebOrigin"))
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationCookie(o => {
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
    o.SlidingExpiration = true;
});

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
