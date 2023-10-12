using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using todogamma.Models;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DeviceContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("GammaDb"))
);

builder.Services.AddScoped<DeviceContext, DeviceContext>();

builder.Services.AddSingleton<IDevice, MockDevice>();

builder.Services.AddCors();


builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(options => {
    options.WithOrigins("http://localhost:5173/");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
