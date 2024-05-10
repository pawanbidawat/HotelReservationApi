using HotelApi.Models.DTO;
using HotelApi.Repository.Interfaces;
using HotelApi.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connectionString
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
builder.Services.AddScoped<IHotelData, HotelDataService>();
//adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            // builder.WithOrigins("https://localhost:44316") // frontend origin
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .WithExposedHeaders("Content-Disposition")
            //        .SetIsOriginAllowed((host) => true); // any origin
                      builder.WithOrigins("*")
      .AllowAnyMethod()
      .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
