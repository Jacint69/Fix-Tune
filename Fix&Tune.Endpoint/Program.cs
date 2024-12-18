
using Fix_Tune.Logic;
using Fix_Tune.Models;
using Fix_Tune.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fix_Tune.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTransient<IRepository<Car>, CarRepository>();
            builder.Services.AddTransient<ICarLogic, CarLogic>();

            builder.Services.AddTransient<IRepository<Issue>, IssueRepository>();
            builder.Services.AddTransient<IIssueLogic, IssueLogic>();

            builder.Services.AddTransient<IRepository<CarIssue>, CarIssueRepository>();
            builder.Services.AddTransient<ICarIssueLogic, CarIssueLogic>();
            builder.Services.AddTransient<IMechanicLogic, MechanicLogic>();
            builder.Services.AddTransient<IRepository<Service>,  ServiceRepository>();
            builder.Services.AddTransient<IServiceLogic, ServiceLogic>();

            builder.Services.AddTransient<IRepository<Discount>, DiscountRepository>();
            builder.Services.AddTransient<IDiscountLogic, DiscountLogic>();

            builder.Services.AddTransient<IRepository<Workshop>, WorkshopRepository>();
            builder.Services.AddTransient<IWorkshopLogic, WorkshopLogic>();

            builder.Services.AddTransient<IRepository<TuningPart>, TuningPartRepository>();
            builder.Services.AddTransient<ITuningPartLogic, TuningPartLogic>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));



            //sql, identity
            string conn = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_develop.json", optional: false, reloadOnChange: true)
                .Build()
                .GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<FixTuneDbContext>(opt =>
            {
                opt.UseMySql(conn, new MySqlServerVersion("8.0.30")).UseLazyLoadingProxies();
            });

            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<FixTuneDbContext>()
            .AddDefaultTokenProviders();

            //JWT token

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://www.security.org",
                    ValidIssuer = "http://www.security.org",
                    IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelyeasdasdasd"))
                };
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLiveServer", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500")  // A Live Server URL-je
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors(opt => opt.AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://127.0.0.1:5500"));
            app.UseCors("AllowLiveServer");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
