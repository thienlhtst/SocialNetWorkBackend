using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostApplication.Interfaces;
using PostApplication.Services;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using PostInfrastructure;
using PostInfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostDbSC")));
builder.Services.AddTransient<IGenericRepository<Posts>, GenericRepository<Posts>>();
builder.Services.AddTransient<IGenericRepository<Media>, GenericRepository<Media>>();
builder.Services.AddTransient<IGenericService<Posts>, GenericService<Posts>>();
builder.Services.AddTransient<IGenericService<Media>, GenericService<Media>>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IMediaService, MediaService>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IReactionRepository, ReactionRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IMediaRepository, MediaRepository>();

//
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    var asb = typeof(Program).Assembly;
    x.AddConsumers(asb);
    x.AddSagaStateMachines(asb);
    x.AddSagas(asb);
    x.AddActivities(asb);
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(ctx);
    });
});
////
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();