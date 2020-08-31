using AutoMapper;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repositories;
using InsuranceEngine.Contracts;
using Engine = InsuranceEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InsuranceEngine;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Insurance.WebApi.Authorization;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Insurance.WebApi.Helpers;
using Microsoft.AspNetCore.Http;

namespace Insurance.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("DataAccess")));
            services.AddControllers();
            services.AddAutoMapper(typeof(UserEngine).Assembly);
            services.AddCors();

            //Registering services
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ICoverTypeRepository, CoverTypeRepository>();
            services.AddScoped<IRiskTypeRepository, RiskTypeRepository>();
            services.AddScoped<IInsuranceEngine, Engine.InsuranceEngine>();
            services.AddScoped<ILocationEngine, LocationEngine>();
            services.AddScoped<ICoverTypeEngine, CoverTypeEngine>();
            services.AddScoped<IRiskTypeEngine, RiskTypeEngine>();
            services.AddScoped<IUserEngine, UserEngine>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorizationHandler, RoleHandler>();

            //Validate Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policyBuilder => policyBuilder.RequireRole("Administrator"));
                options.AddPolicy("IT", policyBuilder => policyBuilder.RequireRole("IT"));
                options.AddPolicy("Service", policyBuilder => policyBuilder.RequireRole("CustomerService"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
