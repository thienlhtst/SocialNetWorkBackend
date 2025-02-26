using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostApplication.CommunicateServices;
using PostApplication.Interfaces;
using PostApplication.Services;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using PostInfrastructure;
using PostInfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var rabbitConfig = builder.Configuration.GetSection("rabitmq");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<PostDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PostDbSC")));
//builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostDbSC")));
builder.Services.AddTransient<IGenericRepository<Posts>, GenericRepository<Posts>>();
builder.Services.AddTransient<IGenericRepository<Media>, GenericRepository<Media>>();
builder.Services.AddTransient<IGenericRepository<Comment>, GenericRepository<Comment>>();
builder.Services.AddTransient<IGenericRepository<Topic>, GenericRepository<Topic>>();
builder.Services.AddTransient<IGenericRepository<TopicUser>, GenericRepository<TopicUser>>();
builder.Services.AddTransient<IGenericRepository<TopicPost>, GenericRepository<TopicPost>>();

builder.Services.AddTransient<IGenericService<Posts>, GenericService<Posts>>();
builder.Services.AddTransient<IGenericService<Media>, GenericService<Media>>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ITopicServices, TopicServices>();

builder.Services.AddTransient<IReactionService, ReactionService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();

builder.Services.AddTransient<IMediaService, MediaService>();
builder.Services.AddTransient<IPostUserServices, PostUserServices>();
builder.Services.AddTransient<ICommentService, CommentServices>();

builder.Services.AddTransient<ITopicRepository, TopicRepository>();
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
        cfg.Host(rabbitConfig["host"], "/", h =>
        {
            h.Username(rabbitConfig["username"]);
            h.Password(rabbitConfig["password"]);
        });
        cfg.ConfigureEndpoints(ctx);
    });
});
////
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

var app = builder.Build();
using (var scope = app.Services.CreateScope()) // Tạo scope mới
{
    var services = scope.ServiceProvider; // Lấy service provider từ scope
    try
    {
        var dbContextFactory = services.GetRequiredService<IDbContextFactory<PostDbContext>>();
        using var context = dbContextFactory.CreateDbContext(); // Lấy DbContext từ scope
        context.Database.Migrate(); // Chạy migration
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseCors("CorsPolicy");
app.UseWebSockets();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger T2Pro V1");
});
app.UseSwagger();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();