using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR.Registration;
using TriMania.Application.UserContext.Commands.Register;
using TriMania.Domain.Shopping.Repositories;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Services;
using TriMania.Infra.Auth;
using TriMania.Infra.Database.Context;
using TriMania.Infra.Database.Repository;
using TriMania.Infra.Hash;
using TriMania.Infra.Mediatr;
using Trimania.Shared.Exceptions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System;
using TriMania.Application.Mappings;
using TriMania.Infra.Database;
using TriMania.Application.ShoppingContext.AddItems.Service;
using TriMania.Application.Contracts;
using TriMania.Infra.UnitOfWork;

namespace Trimania
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
            services.AddHttpContextAccessor();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<RegisterCommand>();
                fv.AutomaticValidationEnabled = false;
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trimania", Version = "v1" });

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

            });

            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySql");
            var sqlConnectionStringDapper = Configuration.GetConnectionString("DataAccessMySqlDapper");

            services.AddDbContext<AppDbContext>(options =>
                    options.UseMySQL(sqlConnectionString)
                );

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                //x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(typeof(UserRegistrationToUserMappingProfile));

            services.AddMediatR(typeof(RegisterCommand));
            services.Scan(
                scan => scan
                    .FromAssembliesOf(typeof(RegisterCommand))
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .As(
                        type => type.GetInterfaces()
                            .Where(
                                i => i.IsGenericType &&
                                     !i.IsOpenGeneric() &&
                                     i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                    .WithTransientLifetime());


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProducRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IMySqlConnection>(n => new SqlConnection(sqlConnectionString));

            services.AddScoped(typeof(IRequestPreProcessor<>), typeof(ValidationDecorator<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trimania v1"));
            }

            app.UseHttpsRedirection();

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}