using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using todogamma.Models;
using todogamma.Repositories;
using todogamma.Interface;
using todogamma;


internal class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddControllers();

		builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			}
		);
		builder.Services.AddScoped<TokenService, TokenService>();
		builder.Services.AddDbContext<DeviceContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("GammaDb"))
		);

		builder.Services.AddDbContext<UsersContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("GammaDb"))
		);

		builder.Services
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options => 
			{
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ClockSkew = TimeSpan.Zero,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = "apiWithAuthBackend",
					ValidAudience = "apiWithAuthBackend",
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes("!SomethingSecret!")
					),
				};
			});
		builder.Services
			.AddIdentityCore<IdentityUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.User.RequireUniqueEmail = true;
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			})
			.AddEntityFrameworkStores<UsersContext>();


		builder.Services.AddScoped <IRepository<Device>, DeviceRepository > ();
		builder.Services.AddScoped <IRepository<Category>, CategoryRepository>();


		builder.Services.AddCors();
		
		var  MyAllowSpecificOrigins = "MyPolicy";
		
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(name: "MyPolicy",
				policy =>
				{
					policy.WithOrigins("http://localhost:5173", 
							"http://localhost:3000")
						.WithMethods("GET", "POST", "PUT", "Delete")
						.AllowAnyHeader();
				});
		});


		builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
		builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 5;
			}).AddEntityFrameworkStores<DeviceContext>()
			.AddDefaultTokenProviders();



		var app = builder.Build();

		app.UseRouting();
		app.UseCors(MyAllowSpecificOrigins);
		if (app.Environment.IsDevelopment())
		{
			 app.UseSwagger();
			 app.UseSwaggerUI();
  
		}
		
		app.UseAuthorization();

		app.MapControllers(

		);

		app.Run();
	}
}
