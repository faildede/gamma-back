using Microsoft.EntityFrameworkCore;
using todogamma.Models;
using Microsoft.AspNetCore.Identity;
using todogamma.Service;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "MyPolicy",
     policy => 
     {  
        policy.WithOrigins("http://localhost:5173")
                .WithMethods("GET", "POST", "PUT")
               .AllowAnyHeader();
     });
});


builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DeviceContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("GammaDb"))
);

builder.Services.AddScoped<DeviceContext, DeviceContext>();

builder.Services.AddSingleton<IDevice, MockDevice>();

builder.Services.AddCors();


builder.Services.AddControllers();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
{
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<DeviceContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<IAuthServices, AuthService>();

var app = builder.Build();

app.UseRouting();


app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
