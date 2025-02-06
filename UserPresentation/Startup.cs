using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using UserApplication.Interfaces;
using UserCore.Entities;
using UserCore.InterfaceRepositories;
using UserInfrastructure;
using UserInfrastructure.Repositories;
using UserPresentation.DependencyInjection;

namespace UserPresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
            services.AddSingleton<IWebHostEnvironment>(sp => sp.GetRequiredService<IWebHostEnvironment>());

            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddApplicationServices();
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbSC")));

            //
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false; // Tắt yêu cầu ký tự đặc biệt
                options.Password.RequiredLength = 6; // (Tùy chọn) Đặt độ dài tối thiểu của mật khẩu
                options.Password.RequireUppercase = false; // (Tùy chọn) Không yêu cầu ký tự in hoa
                options.Password.RequireLowercase = false; // (Tùy chọn) Không yêu cầu ký tự in thường
                options.Password.RequireDigit = false; // (Tùy chọn) Không yêu cầu số
            })
     .AddEntityFrameworkStores<UserDbContext>()
     .AddDefaultTokenProviders();
            //
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(typeof(AllowanceMapper).Assembly);
            //

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });
            services.AddMassTransitHostedService();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = Configuration["Jwt:Issuer"],
                                ValidAudience = Configuration["Jwt:Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                            };
                            options.Events = new JwtBearerEvents
                            {
                                OnTokenValidated = context =>
                                {
                                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                                    if (claimsIdentity != null)
                                    {
                                        // Thêm claim tùy chỉnh từ token vào User.Claims
                                        var jwtToken = context.SecurityToken as JwtSecurityToken;
                                        if (jwtToken != null)
                                        {
                                            foreach (var claim in jwtToken.Claims)
                                            {
                                                claimsIdentity.AddClaim(claim);
                                            }
                                        }
                                    }
                                    return Task.CompletedTask;
                                }
                            };
                        });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "User Solution", Version = "v1" });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddCors(o => o.AddPolicy("CorsPolicy", b =>
            {
                b.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));
            //services.AddSignalR(options => { options.KeepAliveInterval = TimeSpan.FromSeconds(5); }).AddMessagePackProtocol();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    var emailClaim = context.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    if (!string.IsNullOrEmpty(emailClaim))
                    {
                        ((ClaimsIdentity)context.User.Identity).AddClaim(new Claim(ClaimTypes.Name, emailClaim));
                    }
                }
                await next();
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseWebSockets();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger T2Pro V1");
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                   pattern: "{controller=Account}/{action=Index}/{id?}");
                //  endpoints.MapHub<SignalrHub>("/signar");
                endpoints.MapControllers();
            });
        }
    }
}